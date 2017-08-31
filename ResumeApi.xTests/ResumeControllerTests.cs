namespace ResumeApi.xTests
{
    using Microsoft.AspNetCore.Mvc;    
    using Moq;
    using ResumeApi.Model;
    using ResumeApi.RepositoryInterfaces;
    using ResumeApi.Web.Controllers;
    using System.Threading.Tasks;
    using Xunit;

    public class ResumeControllerTests
    {
        [Fact]
        public async Task TestRetrieveResume_Found()
        {
            var mock = new Mock<IResumeRepository>();
            mock.Setup(repository => repository
                .GetResumeByUserNameAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(Maybe.Some(new Resume())));

            var controller = new ResumeController(mock.Object);
            var response = await controller.Get("foo");

            Assert.IsType<OkObjectResult>(response);            
        }

        [Fact]
        public async Task TestRetrieveResume_NotFound()
        {
            var mock = new Mock<IResumeRepository>();
            mock.Setup(repository => repository
                .GetResumeByUserNameAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(Maybe.None<Resume>()));

            var controller = new ResumeController(mock.Object);
            var response = await controller.Get("foo");

            Assert.IsType<NotFoundResult>(response);            
        }
    }
}
