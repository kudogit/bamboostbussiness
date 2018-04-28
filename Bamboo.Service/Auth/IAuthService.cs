using Bamboo.Core.Models.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo.Service.Auth
{
    public interface IAuthService
    {
        Task<IdentityResult> CreateAsync(CreateAuthModel model);
        Task<TokenModel> CreateTokenAsync(LoginModel model);
    }
}
