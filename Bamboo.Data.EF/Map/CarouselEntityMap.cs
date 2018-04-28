using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bamboo.Data.EF.Map
{
    public class CarouselEntityMap : BaseEntityMap<CarouselEntity>
    {
        public CarouselEntityMap(EntityTypeBuilder<CarouselEntity> entityBuilder) : base(entityBuilder)
        {
        }
    }
}
