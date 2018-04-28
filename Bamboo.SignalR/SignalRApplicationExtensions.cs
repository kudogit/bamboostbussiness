using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.SignalR
{
    public static class SignalRApplicationExtensions
    {
        public static IApplicationBuilder UseSignalRService(this IApplicationBuilder app)
        {
            app.UseSignalR(routes => {
                routes.MapHub<ChatHub>("/chathub");
            });
            return app;
        }
    }
}
