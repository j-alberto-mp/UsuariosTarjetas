using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Core.Middlewares
{
    public class URLMiddleware
    {
        private readonly ILogger<URLMiddleware> _logger;
        private readonly RequestDelegate _next;

        public URLMiddleware(ILogger<URLMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            _logger.LogInformation("Solicitud");
            _logger.LogInformation($"Accept: {httpContext.Request.Headers["accept"]}");
            _logger.LogInformation($"Navegador: {httpContext.Request.Headers["user-agent"]}");
            _logger.LogInformation($"Método: {httpContext.Request.Method}");
            _logger.LogInformation($"url: {UriHelper.GetDisplayUrl(httpContext.Request)}");
            _logger.LogInformation("Respuesta");
            _logger.LogInformation($"{httpContext.Response.ContentType} ({httpContext.Response.ContentLength ?? 0} bytes)");

            await this._next(httpContext);
        }
    }
}
