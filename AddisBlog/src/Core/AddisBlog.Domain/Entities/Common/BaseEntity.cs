using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddisBlog.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        public Guid id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }
}