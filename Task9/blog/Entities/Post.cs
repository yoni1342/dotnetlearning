using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Entities
{
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }
        public Guid PostId {get; set;}
        public string Title {get; set;}
        public string Content {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
        public DateTime UpdatedAt {get; set;} = DateTime.UtcNow;
        
        public ICollection<Comment> Comments {get; set;}
    }
}