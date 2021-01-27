using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Todo.Core.Interface.Data;
using Todo.Core.Models.Request;
using Todo.Core.Models.Response;
using Todo.Core.Models.Sql;


namespace ToDoItems.API.GraphQL
{
    [Authorize]
    public class Query : Base
    {
        public Query(IHttpContextAccessor httpContextAccessor, ITodoItemRepository todoItemRepository)
            : base(httpContextAccessor, todoItemRepository)
        {
        }
               
        public TodoItem GetItem(int id)
        {
            var userId = CheckAuthentication();
            return todoItemRepository.GetItem(userId, id);
        }

        public PagedResult<TodoItem> GetItems(PagingParameters pagingParameters)
        {
            var userId = CheckAuthentication();
            return todoItemRepository.GetItems(userId, pagingParameters);
        }

        public List<Label> GetItemLabels(int itemId)
        {
            var userId = CheckAuthentication();
            return todoItemRepository.GetItemLabels(userId, itemId);
        }
    }
}
