using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Entities;
using blog.Model;
using AutoMapper;
using blog.Helpers;
using blog.Mapping;
using blog.Data;
using blog.DTOs;
using Microsoft.EntityFrameworkCore;

namespace blog.Services.PostService
{
    public class PostService : IPostService
    {
        private ApiDbContext _context;
        private IMapper _mapper;
        public PostService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public PostResponseDTO Create(CreatePostRequest request)
        {
            try
            {
                var post = _mapper.Map<Post>(request);

                // save post
                _context.posts.Add(post);
                _context.SaveChanges();

                return _mapper.Map<PostResponseDTO>(post);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public async Task<List<PostResponseDTO>> GetAll()
        {
            // var res = await _context.posts.FindAsync();
            var res = await _context.posts.Include(x => x.Comments).ToListAsync();
            Console.WriteLine(res);
            return _mapper.Map<List<PostResponseDTO>>(res);
        }

        public PostResponseDTO GetById(Guid id)
        {
            var res = _context.posts.Where(x => x.PostId == id).Include(x => x.Comments).FirstOrDefault();
            return _mapper.Map<PostResponseDTO>(res);
        }

        public PostResponseDTO Update(Guid id, UpdatePostRequest request)
        {
            var post = _context.posts.Find(id);

            if (post == null)
                throw new AppException("Post not found");

            // update post properties
            _mapper.Map(request, post);

            // update the time
            post.UpdatedAt = DateTime.UtcNow;

            _context.posts.Update(post);
            if (_context.SaveChanges() == 0)
                throw new AppException("Update failed");

            return _mapper.Map<PostResponseDTO>(post);
        }

        public void Delete(Guid id)
        {
            var post = _context.posts.Find(id);
            if (post == null)
                throw new AppException("Post not found");

            _context.posts.Remove(post);
            if (_context.SaveChanges() == 0)
                throw new AppException("Delete failed");
        }
    }
}