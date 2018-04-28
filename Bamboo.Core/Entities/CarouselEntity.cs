using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core.Entities
{
    public class CarouselEntity : BaseEntity
    {
        public bool IsSelected  { get; set; }

        public int FileId { get; set; }

        public virtual FileEntity File { get; set; }
    }
}
