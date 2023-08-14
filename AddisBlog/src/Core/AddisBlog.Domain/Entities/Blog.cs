using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddisBlog.Domain.Entities.Common;

namespace AddisBlog.Domain.Entities
{
    public class Blog : BaseEntity
    {   
        public string BlogTitle { get; set; }
        public string BlogBody { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}