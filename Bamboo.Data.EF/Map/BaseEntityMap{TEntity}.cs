using Bamboo.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Data.EF.Map
{
    public class BaseEntityMap<TEntity> where TEntity : BaseEntity
    {
        public BaseEntityMap(EntityTypeBuilder<TEntity> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
        }
    }
}
