using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Model;
using blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : ApiController
    {
        private ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        
        [HttpPost("post/{postId}/comment")]
        public IActionResult CreateComment(Guid postId, CreateCommentRequest request)
        {
            var comment = _commentService.Create(request, postId);
            return Ok(comment);
        }

        [HttpGet("post/{postId}/comment")]
        public IActionResult GetAllComment(Guid postId)
        {
            var comments = _commentService.GetAll(postId);
            return Ok(comments);
        }

        [HttpGet("post/{postId}/comment/{id}")]
        public IActionResult GetCommentById(Guid postId, Guid id)
        {
            var comment = _commentService.GetById(id);
            return Ok(comment);
        }

        [HttpPut("post/{postId}/comment/{id}")]
        public IActionResult UpdateComment(Guid postId, Guid id, UpdateCommentRequest request)
        {
            var comment = _commentService.Update(id, request);
            return Ok(comment);
        }

        [HttpDelete("post/{postId}/comment/{id}")]
        public IActionResult DeleteComment(Guid postId, Guid id)
        {
            _commentService.Delete(id);
            return Ok();
        }
    }
}