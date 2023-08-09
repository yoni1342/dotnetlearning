using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using blog.Model;
using blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    public class BlogController : ApiController
    {
        private IPostService _postService;
        private IMapper _mapper;
        public BlogController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }
        
        [HttpPost("post")]
        public IActionResult CreatePost( CreatePostRequest request)
        {
            var post = _postService.Create(request);
            return Ok(post);
        }

        [HttpGet("post")]
        public async Task<IActionResult> GetAllPost()
        {
            var posts = await _postService.GetAll();
            return Ok(posts);
        }
        
        [HttpGet("post/{id}")]
        public IActionResult GetPostById(Guid id)
        {
            var post = _postService.GetById(id);
            return Ok(post);
        }

        [HttpPut("post/{id}")]
        public IActionResult UpdatePost(Guid id, UpdatePostRequest request)
        {
            var post = _postService.Update(id, request);
            return Ok(post);
        }

        [HttpDelete("post/{id}")]
        public IActionResult DeletePost(Guid id)
        {
            _postService.Delete(id);
            return Ok();
        }

    }
}