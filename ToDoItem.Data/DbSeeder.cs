using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Core.Helpers;
using Todo.Core.Models.Sql;
using ToDoItems.Entities;

namespace ToDoItem.Data
{
    /// <summary>
    /// Database seeder to be used at the application startup
    /// </summary>
    public static class DbSeeder
    {
        /// <summary>
        /// Extension method to seed database.
        /// Does nothing if there is already some data in the database.
        /// </summary>
        /// <param name="dbContext"></param>
        public static void Seed(this TodoDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
  
            var user = new User
            {
                UserId = 1,
                UserName = "ashwani",
                FullName = "Ashwani",
                Email = "ashwani.kumar01@nagarro.com",
                Password = "Pass@2k0",
                UserRole = "Admin"
            };
            dbContext.SaveChanges();
        }
    }
}
