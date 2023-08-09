using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.DTOs
{
    public class CommentResponsDTO
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;

    }
}