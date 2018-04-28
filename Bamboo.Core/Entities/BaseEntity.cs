using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTimeOffset CreatedDateTime { get; set; }
        public int CreatedBy { get; set; }

        public DateTimeOffset? DeletedDateTime { get; set; }
        public int? DeletedBy { get; set; }

        public DateTimeOffset? LastUpdatedDateTime { get; set; }
        public int? LastUpdatedBy { get; set; }
    }
}
