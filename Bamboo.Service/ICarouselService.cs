using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bamboo.Core.Models.Carousel;

namespace Bamboo.Service
{
    public interface ICarouselService
    {
        Task<int> AddAsync(AddCarouselModel model);

        Task<EditCarouselModel> GetAsync(int id);

        Task EditAsync(EditCarouselModel model);

        Task<List<CarouselModel>> GetsAsync();

        Task<List<CarouselModel>> GetSelectedAsync();
    }
}
