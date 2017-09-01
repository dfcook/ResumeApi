namespace ResumeApi.xTests
{
    using Microsoft.AspNetCore.Mvc;    
    using Moq;
    using ResumeApi.Common;
    using ResumeApi.Model;
    using ResumeApi.RepositoryInterfaces;
    using ResumeApi.Web.Controllers;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class ResumeControllerTests
    {
        private async Task TestFound<T>(Func<Mock<T>> mockFactory, Func<T, Task<IActionResult>> controllerAction) where T: class
        {
            var mock = mockFactory().Object;
            var response = await controllerAction(mock);

            Assert.IsType<OkObjectResult>(response);
        }

        private async Task TestNotFound<T>(Func<Mock<T>> mockFactory, Func<T, Task<IActionResult>> controllerAction) where T : class
        {
            var mock = mockFactory().Object;
            var response = await controllerAction(mock);

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async Task TestRetrieveResume_Found()
        {
            await TestFound(() =>
            {
                var mock = new Mock<IResumeRepository>();
                mock.Setup(repository => repository
                    .GetResumeByUserNameAsync(It.IsAny<string>()))
                    .Returns(Task.FromResult(Maybe.Some(new Resume())));

                return mock;
            }, async mock =>
            {
                var controller = new ResumeController(mock);
                return await controller.Get("foo");
            });                        
        }

        [Fact]
        public async Task TestRetrieveResume_NotFound()
        {
            await TestNotFound(() =>
            {
                var mock = new Mock<IResumeRepository>();
                mock.Setup(repository => repository
                    .GetResumeByUserNameAsync(It.IsAny<string>()))
                    .Returns(Task.FromResult(Maybe.None<Resume>()));

                return mock;
            }, async mock =>
            {
                var controller = new ResumeController(mock);
                return await controller.Get("foo");
            });                       
        }
    }
}
