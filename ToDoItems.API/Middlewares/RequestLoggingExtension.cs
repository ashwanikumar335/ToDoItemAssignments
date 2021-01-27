﻿using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ToDoItems.API.Middlewares
{
    /// <summary>
    /// ModelExtension to log execution time of the incoming request
    /// </summary>
    public class RequestLoggingExtension : IMiddleware
    {
        private readonly ILogger logger;

        public RequestLoggingExtension(ILogger<RequestLoggingExtension> logger)
        {
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var method = context.Request.Method;

            if (method != "OPTIONS")
            {               
                var stopWatch = Stopwatch.StartNew();

                var url = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";

                var referer = context.Request.Headers["Referer"].FirstOrDefault();

                var userAgentValues = context.Request.Headers["User-Agent"];
                var originValues = context.Request.Headers["Origin"];
                var ipAddress = context.Connection.RemoteIpAddress.ToString();
                var userAgent = userAgentValues.Count > 0 ? userAgentValues.Aggregate((i, j) => $"{i},{j}") : string.Empty;
                var origin = originValues.Count > 0 ? originValues.Aggregate((i, j) => $"{i},{j}") : string.Empty;

                // read body contents
                context.Request.EnableBuffering();
                var requestBodyReader = new StreamReader(context.Request.Body);
                var requestBody = await requestBodyReader.ReadToEndAsync();
                // reset body position
                context.Request.Body.Seek(0, SeekOrigin.Begin);

                logger.LogInformation($"Request => method {method}, url: {url}, origin: {origin}, referer: {referer}, agent: {userAgent}, ip: {ipAddress}, body: {requestBody}");

                await next(context);

                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var responseBodyReader = new StreamReader(context.Response.Body);
                var responseBody = await responseBodyReader.ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                logger.LogInformation($"Response => status {context.Response.StatusCode}, body: {responseBody}");
            }
            else
            {
                await next(context);
            }
        }
    }

}
