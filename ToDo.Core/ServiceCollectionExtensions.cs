using Microsoft.Extensions.DependencyInjection;
using Todo.Core.Logic;
using Todo.Core.Interface.Logic;
using ToDoItems.Interfaces;

namespace Todo.Core
{
    /// <summary>
    /// Extensions for service collection registrations
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers dependencies for the logic layer
        /// </summary>
        /// <param name="services">Service Collection object</param>
        public static void RegisterLogicDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITodoItemLogic, TodoItemLogic>();
            services.AddScoped<IAuthOps, AuthLogic>();
        }
    }
}
