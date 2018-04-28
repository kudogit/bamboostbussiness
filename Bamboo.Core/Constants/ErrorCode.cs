using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bamboo.Core.Constants
{
    public enum ErrorCode
    {
        [Display(Name = "User is invalid")]
        NotFoundUser = 100,

        [Display(Name = "Password is invalid")]
        PasswordInvalid = 200,

        [Display(Name = "Path is invalid")]
        PathInvalid = 300,

        [Display(Name = "Element is not found")]
        ElementNotFound = 400,

        [Display(Name = "Oops! Something went wrong, please try again later")]
        Unknown = 500,
    }
}
