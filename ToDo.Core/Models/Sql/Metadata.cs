using System;
using ToDoItems.Entities;

namespace Todo.Core.Models.Sql
{
    public class Metadata
    {
        public User user { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
