using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.DTOs
{
    public class PostResponseDTO
    {
        public Guid PostId {get; set;}
        public string Title {get; set;}
        public string Content {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public ICollection<CommentResponsDTO> Comments {get; set;}
    }
}