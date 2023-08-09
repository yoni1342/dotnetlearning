using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Entities;
using blog.Model;
using blog.Helpers;
using AutoMapper;
using blog.Mapping;
using blog.Data;
using blog.DTOs;
using Microsoft.EntityFrameworkCore;

namespace blog.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private ApiDbContext _context;
        private IMapper _mapper;

        public CommentService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public CommentResponsDTO Create(CreateCommentRequest request, Guid postId)
        {
            // check if post exists
            var post = _context.posts.Find(postId);
            if (post == null)
                throw new AppException("Post not found");

            // map request to comment
            var comment = _mapper.Map<Comment>(request);
            comment.PostId = postId;

            _context.comments.Add(comment);
            if (_context.SaveChanges() == 0)
            {
                throw new AppException("Comment not created");
            }

            return _mapper.Map<CommentResponsDTO>(comment);


        }

        public IEnumerable<Comment> GetAll(Guid postId)
        {
            try
            {
                return _context.comments.Where(x => x.PostId == postId);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public Comment GetById(Guid id)
        {
            try
            {
                return _context.comments.Find(id);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public CommentResponsDTO Update(Guid CommentId, UpdateCommentRequest request)
        {

            var comment = _context.comments.Find(CommentId);

            if (comment == null)
                throw new AppException("Comment not found");

            // update comment properties
            _mapper.Map(request, comment);

            // update the time
            comment.UpdateAt = DateTime.UtcNow;

            _context.comments.Update(comment);
            if (_context.SaveChanges() == 0)
            {
                throw new AppException("Comment not updated");
            }

            return _mapper.Map<CommentResponsDTO>(comment);

        }
        void ICommentService.Delete(Guid id)
        {
            var comment = _context.comments.Find(id);
            if (comment == null)
                throw new AppException("Comment not found");

            _context.comments.Remove(comment);
            if (_context.SaveChanges() == 0)
                throw new AppException("Delete failed");
        }
    }
}