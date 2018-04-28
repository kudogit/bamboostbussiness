using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bamboo.Core.Models.Carousel;
using Bamboo.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bamboo.WebApplication.Controllers
{
    [Route(Endpoint)]
    public class CarouselController : ApiController
    {
        private const string Endpoint = AreaName + "carousel";
        private const string CreateEndpoint = "create";
        private readonly ICarouselService _carouselService;

        public CarouselController(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }

        [Route(CreateEndpoint)]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddCarouselModel model)
        {
            var res = await _carouselService.AddAsync(model).ConfigureAwait(true);
            return Ok(res);
        }
    }
}