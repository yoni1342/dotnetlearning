using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.DTOs;
using blog.Entities;
using blog.Model;

namespace blog.Services
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetAll(Guid postId);
        Comment GetById(Guid id);
        CommentResponsDTO Create(CreateCommentRequest request, Guid postId);
        CommentResponsDTO Update(Guid CommentId, UpdateCommentRequest request);
        void Delete(Guid id);
    }
}