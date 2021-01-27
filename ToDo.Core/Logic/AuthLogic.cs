using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Interface.Data;
using ToDoItems.Entities.Models;
using ToDoItems.Entities;
using ToDoItems.Interfaces;

namespace Todo.Core.Logic
{
    public class AuthLogic : IAuthOps
    {
        public IAuthDbOps _authDbOps;
        public AuthLogic(IAuthDbOps authDbOps)
        {
            _authDbOps = authDbOps;
        }

        public Task<User> AuthenticateUser(LoginModel loginModel)
        {
            return _authDbOps.AuthenticateUser(loginModel);
        }

        public async Task<int> Register(RegisterModel registerModel)
        {
            return await _authDbOps.Register(registerModel);
        }
    }
}
