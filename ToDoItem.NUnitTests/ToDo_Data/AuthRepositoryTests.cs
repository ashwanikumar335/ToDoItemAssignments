using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Core.Helpers;
using ToDoItem.Data;
using ToDoItem.Data.Repositories;
using NUnit.Framework;
using Todo.Core.Models.Dtos;
using ToDoItems.Entities.Models;
using ToDoItems.Entities;

namespace Todo.UnitTests.Data
{
    public class AuthRepositoryTests
    {
        private readonly AuthDbOps _userDbOps;
        /// <summary>
        /// Test for regisering user with valid values.
        /// </summary>
        [Test]
        public async Task Invalid_RegisterUser()
        {
            int result = await _userDbOps.Register(new RegisterModel { Email = "Demo@nagarro.com", UserName = "demo", FullName = "demotest", Password = "123", ConfirmPassword = "123" });

            Assert.IsTrue(Convert.ToBoolean(result));
        }
        /// <summary>
        /// Test for authentication of user.
        /// </summary>
        [Test]
        public async Task AuthenticateUser()
        {
            User entity = await _userDbOps.AuthenticateUser(new LoginModel { UserName = "ashwani", Password = "Pass@2k0" });

            Assert.NotNull(entity);
        }

        /// <summary>
        /// Test for registering users with invalid values.
        /// </summary>
        [Test]
        public async Task Valid_RegisterUser()
        {
            int result = await _userDbOps.Register(new RegisterModel { Email = "ashwani.kumar01@nagarro.com", UserName = "ashwani", FullName = "ashwanikumar", Password = "Pass@2k0", ConfirmPassword = "Pass@2k0" });

            Assert.IsTrue(Convert.ToBoolean(result));
        }

        private TodoDbContext SetupDatabase(string dbname)
        {
            var builder = new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase(databaseName: dbname);

            var dbContext = new TodoDbContext(builder.Options);

            dbContext.Users.Add(new ToDoItems.Entities.User
            {
                 UserId   = 1,
                 UserName = "ashwani",
                 FullName = "ashwanikumar",
                 Email    = "ashwani.kumar01@nagarro.com",
                 Password = "Pass@2k0",
                 UserRole = "admin"
           });

            dbContext.SaveChanges();

            return dbContext;
        }
    }
}
