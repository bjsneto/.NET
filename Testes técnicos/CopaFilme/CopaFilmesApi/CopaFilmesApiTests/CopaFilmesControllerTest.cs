
using CopaFilmesApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Xunit;

namespace CopaFilmesApiTests
{
    public class CopaFilmesControllerTest
    {
        public CopaFilmeController controller;
        private readonly IFilmeService _filmeService;

        public CopaFilmesControllerTest()
        {
           
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = controller.ObterTodos();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}
