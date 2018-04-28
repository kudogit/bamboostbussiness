using Bamboo.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Data.EF.Map
{
    public class FileEntityMap : BaseEntityMap<FileEntity>
    {
        public FileEntityMap(EntityTypeBuilder<FileEntity> entityBuilder) : base(entityBuilder)
        {
        }
    }
}
