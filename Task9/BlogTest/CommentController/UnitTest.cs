using System;
using AutoMapper;
using blog.Controllers;
using blog.Model;
using blog.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using blog.DTOs;
namespace BlogTest.Controllers
{
    public class CommentControllerTests
    {
        [Fact]
        public void CreateComment_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var commentServiceMock = new Mock<ICommentService>();
            var controller = new CommentController(commentServiceMock.Object);
            var postId = Guid.NewGuid(); // Replace with a valid post ID
            var request = new CreateCommentRequest { /* Initialize request properties */ };

            commentServiceMock.Setup(cs => cs.Create(It.IsAny<CreateCommentRequest>(), It.IsAny<Guid>()))
                              .Returns(new CommentResponsDTO { /* Initialize comment response properties */ });

            // Act
            var result = controller.CreateComment(postId, request);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        
        // Similar tests for other methods can be written similarly.
    }
}
