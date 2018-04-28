using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core.Entities
{
    public class FileEntity : BaseEntity
    {
        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public string ContentBase64 { get; set; }

        public string EncodeFileName { get; set; }

        public ICollection<CarouselEntity> Carousels { get; set; }
    }
}
