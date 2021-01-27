using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Todo.Core;
using Todo.Core.Interface.Data;
using Todo.Core.Helpers;
using Todo.Core.Models.Dtos;
using Todo.Core.Models.Sql;
using Microsoft.AspNetCore.Authorization;
using ToDoItems.Interfaces;
using ToDoItems.Entities.Models;
using ToDoItems.Entities;

namespace ToDoItems.API.GraphQL
{
    public class Mutation : Base
    {
        private readonly IAuthDbOps _userDbOps;
        private readonly IConfiguration configuration;

        public Mutation(IHttpContextAccessor httpContextAccessor, ITodoItemRepository todoItemRepository, IAuthDbOps userRepository, IConfiguration configuration)
            : base(httpContextAccessor, todoItemRepository)
        {
            this._userDbOps = userRepository;
            this.configuration = configuration;
        }

        
        public TodoItem CreateItem(CreateTodoItemDto createItemDto)
        {
            var userId = CheckAuthentication();
            return todoItemRepository.CreateItem(userId, createItemDto);
        }

       public TodoItem UpdateItem(TodoItemDto updateItemDto)
        {
            var userId = CheckAuthentication();
            return todoItemRepository.UpdateItem(userId, updateItemDto);
        }

        public bool DeleteItem(int itemId)
        {
            var userId = CheckAuthentication();
            return todoItemRepository.DeleteItem(userId, itemId);
        }

       public Label AssignLabelToItem(CreateLabelDto createLabelDto)
        {
            var userId = CheckAuthentication();
            return todoItemRepository.CreateLabel(userId, createLabelDto);
        }

        public Label UpdateItemLabel(UpdateLabelDto updateLabelDto)
        {
            var userId = CheckAuthentication();
            return todoItemRepository.UpdateLabel(userId, updateLabelDto);
        }

        public bool DeleteItemLabel(DeleteLabelDto deleteDto)
        {
            var userId = CheckAuthentication();
            return todoItemRepository.DeleteLabel(userId, deleteDto);
        }
               
        public async Task<User> AuthenticateUser(LoginModel loginModel)
        {
            return await _userDbOps.AuthenticateUser(loginModel);
        }
        /// <summary>
        /// register user.
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns> success/failure result.</returns>
       public async Task<int> Register(RegisterModel registerModel)
        {
            return await _userDbOps.Register(registerModel);
        }
    }
}
