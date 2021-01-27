using Microsoft.EntityFrameworkCore;
using ToDoItems.Entities;
using ToDoItems.Entities.Models;
using ToDoItems.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using ToDoItem.Data;

namespace ToDoItem.Data.Repositories
{
    public class AuthDbOps : IAuthDbOps
    {
        private readonly TodoDbContext dbContext;

        public AuthDbOps(TodoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<User> AuthenticateUser(LoginModel loginModel)
        {
            User user = await dbContext.Users.Where(u => u.UserName == loginModel.UserName && u.Password == loginModel.Password).FirstOrDefaultAsync();
            return user;
        }

        public async Task<int> Register(RegisterModel registerModel)
        {
           
            User user = new User
            {
                Email = registerModel.Email,
                UserRole = "User",
                UserName = registerModel.UserName,
                Password = registerModel.Password,
                FullName = registerModel.FullName
            };
            dbContext.Users.Add(user);
            return await dbContext.SaveChangesAsync();
        }

    }
}
