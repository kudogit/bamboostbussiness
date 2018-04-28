using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Bamboo.Core.Constants;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bamboo.Util.Exceptions
{
    public static class ExceptionHelper
    {

        public static ErrorModel GetErrorModel(ExceptionContext context)
        {
            ErrorModel errorModel;

            if (context.Exception is BambooException exception)
            {
                context.Exception = null;
                errorModel = new ErrorModel(exception.Code, exception.Message);

                context.HttpContext.Response.StatusCode = (int) exception.Code;
            }
            else
            {
                var message = context.Exception.Message ?? ErrorCode.Unknown.GetDisplayName();
                errorModel = new ErrorModel(ErrorCode.Unknown, message);

                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            }

            return errorModel;
        }

    }
}
