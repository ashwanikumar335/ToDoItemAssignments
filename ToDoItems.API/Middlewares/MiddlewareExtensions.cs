using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Todo.API.Middlewares;

namespace ToDoItems.API.Middlewares
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingExtension>();
        }

       public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingExtension>();
        }
        public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorrelationIdMiddleware>();
        }
        public static IApplicationBuilder UseContentLocation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ContentLocationExtension>();
        }

       public static void RegisterMiddlewares(this IServiceCollection services)
        {
            services.AddSingleton<RequestLoggingExtension>();
            services.AddSingleton<ExceptionHandlingExtension>();
            services.AddSingleton<ContentLocationExtension>();
        }
    }

}
