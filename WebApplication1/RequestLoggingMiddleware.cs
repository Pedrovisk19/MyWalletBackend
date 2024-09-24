using Microsoft.Extensions.Logging;

namespace MyWallet
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path;
            var method = context.Request.Method;
            var queryString = context.Request.QueryString;

            _logger.LogInformation($"Método: {method}, Rota chamada: {path}, Query String: {queryString}");

            await _next(context);
        }
    }
}
