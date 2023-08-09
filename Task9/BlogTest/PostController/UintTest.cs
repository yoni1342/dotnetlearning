using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class BlogControllerTests
    {
        [Fact]
        public void CreatePost_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var postServiceMock = new Mock<IPostService>();

            var controller = new BlogController(postServiceMock.Object, mapperMock.Object);
            var request = new CreatePostRequest { /* Initialize request properties */ };

            postServiceMock.Setup(ps => ps.Create(It.IsAny<CreatePostRequest>()))
                           .Returns(new PostResponseDTO { /* Initialize post response properties */ });

            // Act
            var result = controller.CreatePost(request);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetPost_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var postServiceMock = new Mock<IPostService>();

            var controller = new BlogController(postServiceMock.Object, mapperMock.Object);
            var postId = Guid.NewGuid(); // Replace with a valid post ID

            postServiceMock.Setup(ps => ps.GetById(It.IsAny<Guid>()))
                           .Returns(new PostResponseDTO { /* Initialize post response properties */ });

            // Act
            var result = controller.GetPostById(postId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdatePost_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var postServiceMock = new Mock<IPostService>();

            var controller = new BlogController(postServiceMock.Object, mapperMock.Object);
            var postId = Guid.NewGuid(); // Replace with a valid post ID
            var updateRequest = new UpdatePostRequest { /* Initialize update request properties */ };

            postServiceMock.Setup(ps => ps.Update(It.IsAny<Guid>(), It.IsAny<UpdatePostRequest>()))
                           .Returns(new PostResponseDTO { /* Initialize updated post response properties */ });

            // Act
            var result = controller.UpdatePost(postId, updateRequest);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact]
        public void DeletePost_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var postServiceMock = new Mock<IPostService>();

            var controller = new BlogController(postServiceMock.Object, mapperMock.Object);
            var postId = Guid.NewGuid(); // Replace with a valid post ID

            postServiceMock.Setup(ps => ps.Delete(It.IsAny<Guid>()));

            // Act
            var result = controller.DeletePost(postId);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
