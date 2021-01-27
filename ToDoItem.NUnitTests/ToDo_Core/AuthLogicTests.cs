using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Todo.Core.Interface.Data;
using Todo.Core.Helpers;
using Todo.Core.Logic;
using Todo.Core.Models.Dtos;
using Todo.Core.Models.Sql;
using NUnit.Framework;
using ToDoItems.Interfaces;
using Moq;
using ToDoItem.Data.Repositories;
using ToDoItem.Data;
using ToDoItems.Entities.Models;
using ToDoItems.Entities;

namespace Todo.UnitTests.Core
{
    public class AuthLogicTests
    {
        private readonly AuthDbOps userRepository;
        private readonly IConfiguration configuration;
        private readonly AuthLogic userLogic;
        private readonly TodoDbContext dbContext;
        readonly UserDto userDto = new UserDto
        {
            UserId = 1,
            UserName = "ashwani",
            FullName = "ashwanikumar",
            Email = "ashwani.kumar01@nagarro.com",
            Password = "Pass@2k0",
            UserRole = "admin"
        };
        public AuthLogicTests()
        {
            configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string> { { Todo.Core.Constants.AppSettingsJwtKey, "key12345623456789876543" }, { Todo.Core.Constants.AppSettingsJwtIssuer, "issuer" } })
                .Build();
            userRepository = new AuthDbOps(dbContext);
            userLogic = new AuthLogic(userRepository);
        }

        /// <summary>
        /// Auth valid test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Authenticate_ValidUserNameAndPassword()
        {
            User user = await userRepository.AuthenticateUser(new LoginModel { UserName = "ashwani", Password = "Pass@2k0" });
            Assert.IsTrue(user.UserId == 1);
            Assert.AreEqual(1, user.UserId);
        }

        /// <summary>
        /// Auth invalid test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Authenticate_InvalidUserNameAndPassword()
        {
            User user = await userRepository.AuthenticateUser(new LoginModel { UserName = string.Empty, Password = string.Empty });
            Assert.IsTrue(user.UserId != 1);
        }
        [Test]
        public async Task RegisterUser()
        {
            int result = await userRepository.Register(new RegisterModel { Email = "ashwani.kumar01@nagarro.com", UserName = "ashwani", FullName = "ashwanikumar", Password = "Pass@2k0", ConfirmPassword = "Pass@2k0" });
            Assert.AreEqual(true, result);
        }
    }
}
