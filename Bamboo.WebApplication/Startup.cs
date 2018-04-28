using System.Reflection;
using System.Text;
using Bamboo.Core.Validators;
using Bamboo.Data.EF;
using Bamboo.DependencyInjection;
using Bamboo.SignalR;
using Bamboo.WebApplication.Filters.Exception;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using DbContext = Bamboo.Data.EF.DbContext;

namespace Bamboo.WebApplication
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "MyPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
               sqlOptions => sqlOptions.MigrationsAssembly("Bamboo.Data.EF")));
            services.AddIdentity<UserEntity, RoleEntity>()
                .AddEntityFrameworkStores<DbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o => {
                o.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = Configuration["JwtSecurityToken:Issuer"],
                    ValidAudience = Configuration["JwtSecurityToken:Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityToken:Key"])),
                    ValidateLifetime = true
                };
            });

            services.AddDependencyScanning().ScanFromAssembly(new AssemblyName(nameof(Bamboo)));

            services.AddSignalRService();

            services.AddCors(options => options.AddPolicy(_defaultCorsPolicyName,
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials()));

            services.AddMvc(options =>
            {
                //  Add exception filter
                options.Filters.Add(typeof(ApiExceptionFilter));
            })
            .AddModelValidator();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(_defaultCorsPolicyName);

            app.UseAuthentication();

            app.UseSignalRService();

            app.UseMvc();
            
        }
    }
}
