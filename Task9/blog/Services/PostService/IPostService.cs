using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Model;
using blog.Entities;
using blog.DTOs;

namespace blog.Services
{
    public interface IPostService
    {
        Task<List<PostResponseDTO>> GetAll();
        PostResponseDTO GetById(Guid id);
        PostResponseDTO Create(CreatePostRequest request);
        PostResponseDTO Update(Guid id, UpdatePostRequest request);
        void Delete(Guid id);
    }
}