using Bamboo.Core.Models.Auth;
using Bamboo.Data.EF;
using Bamboo.Service.Auth;
using Bamboo.Util.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Bamboo.DependencyInjection.Attributes;

namespace Bamboo.Service.Facade.Auth
{
    [ScopeDependency(ServiceType = typeof(IAuthService))]
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly RoleManager<RoleEntity> _roleManager;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager,
            RoleManager<RoleEntity> roleManager, IPasswordHasher<UserEntity> passwordHasher,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public Task<IdentityResult> CreateAsync(CreateAuthModel model)
        {
            var user = new UserEntity
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            var result = _userManager.CreateAsync(user, model.Password);

            return result;
        }

        public async Task<TokenModel> CreateTokenAsync(LoginModel model)
        {
                var user = await _userManager.FindByNameAsync(model.UserName).ConfigureAwait(true);

                if (user == null)
                    throw new BambooException(Core.Constants.ErrorCode.NotFoundUser);

            if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) !=
                PasswordVerificationResult.Success) throw new BambooException(Core.Constants.ErrorCode.PasswordInvalid);

            var userClaims = await _userManager.GetClaimsAsync(user).ConfigureAwait(true);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            }.Union(userClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityToken:Key"]));

            var signingcredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(issuer: _configuration["JwtSecurityToken:Issuer"],
                audience: _configuration["JwtSecurityToken:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signingcredentials);

            return new TokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Expiration = jwtSecurityToken.ValidTo
            };
        }
    }
}
