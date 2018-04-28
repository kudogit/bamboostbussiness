using Bamboo.DependencyInjection.Attributes;
using Bamboo.Util.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bamboo.WebApplication.Filters.Exception
{
    [SingletonDependency]
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var errorModel = ExceptionHelper.GetErrorModel(context);

            context.Result = new JsonResult(errorModel);
            context.ExceptionHandled = true;

            base.OnException(context);
        }

    }
}
