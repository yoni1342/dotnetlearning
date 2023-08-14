using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddisBlog.Domain.Entities.Common;

namespace AddisBlog.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Comment> Comments { get; set; }
        
    }
}