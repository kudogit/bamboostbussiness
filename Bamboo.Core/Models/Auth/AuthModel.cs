using Bamboo.Core.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core.Models.Auth
{
    [Validator(typeof(AuthModelValidator.CreateAuthModelValidator))]
    public class CreateAuthModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public bool Success { get; set; }
    }
}
