using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bamboo.WebApplication.Filters.Exception;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bamboo.WebApplication.Controllers
{
    [ServiceFilter(typeof(ApiExceptionFilter))]
    public class ApiController : Controller
    {
        public const string AreaName = "api";
    }
}