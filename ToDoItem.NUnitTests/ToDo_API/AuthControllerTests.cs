using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.API.Controllers.v1;
using Todo.Core.Interface.Logic;
using Todo.Core.Models.Response;
using NUnit.Framework;
using ToDoItem.NUnitTests.Data;
using ToDoItems.Entities.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using ToDoItems.Interfaces;
using Microsoft.Extensions.Configuration;
using ToDoItem.Data;

namespace Todo.UnitTests.API
{
    public class AuthControllerTests
    {
        private AuthController controller;
        private IOptions<AppSettings> options;
        public IAuthOps _authOps;
        private readonly IConfiguration _config;
        public ControllerContext Context { get; }
        public AuthControllerTests(IConfiguration config, IAuthOps authOps)
        {
            _config = config;
            _authOps = authOps;
        }
        /// <summary>
        /// Setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            options = Options.Create(new AppSettings { Secret = "this is my custom Secret key for authnetication" });
            controller = new AuthController(_config, _authOps)
            {
                ControllerContext = Context
            };
        }

        /// <summary>
        /// Authentication test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task AuthenticateTest()
        {
            IActionResult result = await controller.Login(new LoginModel { UserName = "Ashwani", Password = "Pass@2k0" });
            OkObjectResult response = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, (int)response.StatusCode);
        }

        /// <summary>
        /// Authentication test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task RegistrationTest()
        {
            int result = await controller.Register(new RegisterModel { Email = "ashwani.kumar01@nagarro.com", UserName = "ashwani", FullName = "ashwanikumar", Password = "Pass@2k0", ConfirmPassword = "Pass@2k0" });
            var response = result;
            Assert.AreEqual(StatusCodes.Status200OK, (int)response);
        }
    }
}
