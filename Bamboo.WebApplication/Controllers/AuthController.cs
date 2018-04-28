using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bamboo.Core.Models.Auth;
using Bamboo.Service.Auth;
using Bamboo.Util.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bamboo.WebApplication.Controllers
{
    [Route(Endpoint)]
    public class AuthController : ApiController
    {
        private const string Endpoint = AreaName + "/auth";
        private const string CreateEndpoint = "create";
        private const string LoginEndpoint = "login";

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route(CreateEndpoint)]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateAuthModel model)
        {
            if(!ModelState.IsValid)
                return Json("Incorrect confirm password");
            var result = await _authService.CreateAsync(model).ConfigureAwait(true);
            return Json(result.Succeeded);
        }

        [Route(LoginEndpoint)]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            var result = await _authService.CreateTokenAsync(model).ConfigureAwait(true);

            return Ok(result);
        }
    }
}