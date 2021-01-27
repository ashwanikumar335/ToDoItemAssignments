using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Core.Interface.Data;
using ToDoItem.Data.Repositories;
using ToDoItems.Interfaces;

namespace ToDoItem.Data
{
    /// <summary>
    /// Extensions for service collection registrations
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers dependencies for the data layer
        /// </summary>
        /// <param name="services">Service Collection object</param>
        public static void RegisterDataDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TodoDbContext>(opts => opts.UseSqlServer(connectionString));
            services.AddScoped<IAuthDbOps,AuthDbOps> ();
            services.AddScoped<ITodoItemRepository, TodoItemRepository>();
        }
    }
}
