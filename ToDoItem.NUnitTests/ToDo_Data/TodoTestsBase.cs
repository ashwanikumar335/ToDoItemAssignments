using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Todo.Core.Helpers;
using Todo.Core.Models.Sql;
using ToDoItem.Data;
using ToDoItems.Entities;

namespace ToDoItem.NUnitTests.Data
{
    public class TodoTestsBase 
    {
        protected TodoDbContext SetupDatabase(string dbname)
        {
            var builder = new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase(databaseName: dbname);

            var dbContext = new TodoDbContext(builder.Options);

            var saltAndHash = CryptographyHelper.GetSaltAndHash("asdf");
            var user = new User
            {
                UserId=1,
                UserName = "testname",
                FullName = "testuser",
                Email = "ashwani.kumar01@nagarro.com",
                Password = "Pass@2k0",
                UserRole="admin"
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return dbContext;
        }
    }
}
