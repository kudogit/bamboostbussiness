using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Core.Models.File;

namespace Bamboo.Core.Models.Carousel
{
    public class AddCarouselModel : AddFileModel
    {
        public int FileId { get; set; }
        public bool IsSelected { get; set; }
    }

    public class EditCarouselModel : AddCarouselModel
    {
        public int Id { get; set; }
    }

    public class CarouselModel : EditCarouselModel { }
}
