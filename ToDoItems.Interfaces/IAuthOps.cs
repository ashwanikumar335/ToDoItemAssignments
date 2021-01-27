using System.Threading.Tasks;
using ToDoItems.Entities.Models;
using ToDoItems.Entities;

namespace ToDoItems.Interfaces
{
    public interface IAuthOps
    {
        Task<int> Register(RegisterModel registerModel);
        Task<User> AuthenticateUser(LoginModel loginModel);
    }
}
