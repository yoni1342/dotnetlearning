using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Entities
{
    public class Comment
    {
        public Guid CommentId {get; set;}
        public Guid PostId {get; set;}
        public Post Post {get; set;}
        public string Content {get; set;}
        public DateTime CreatedAt {get; set;}=DateTime.UtcNow;
        public DateTime UpdateAt {get; set;}=DateTime.UtcNow;
    }
}