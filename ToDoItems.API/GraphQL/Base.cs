using System;
using Microsoft.AspNetCore.Http;
using Todo.Core;
using Todo.Core.Interface.Data;

namespace ToDoItems.API.GraphQL
{
    public class Base
    {
        protected readonly IHttpContextAccessor httpContextAccessor;
        protected readonly ITodoItemRepository todoItemRepository;

        public Base(IHttpContextAccessor httpContextAccessor, ITodoItemRepository todoItemRepository)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.todoItemRepository = todoItemRepository;
        }

        protected int CheckAuthentication()
        {
            var userIdClaim = httpContextAccessor.HttpContext.Items[Constants.UserIdClaim]?.ToString();
            if (string.IsNullOrEmpty(userIdClaim))
            {
                throw new UnauthorizedAccessException("User is not authenticated!");
            }
            return int.Parse(userIdClaim);
        }
    }
}
