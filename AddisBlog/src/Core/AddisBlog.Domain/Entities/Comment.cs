using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddisBlog.Domain.Entities.Common;

namespace AddisBlog.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string CommentBody { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}