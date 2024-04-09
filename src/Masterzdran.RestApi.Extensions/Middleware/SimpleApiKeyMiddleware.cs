using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Masterzdran.RestApi.Extensions.Middleware
{
    public sealed class SimpleApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _expectedApiKey;
        public SimpleApiKeyMiddleware(RequestDelegate next, string expectedApiKey)
        {
            _next = next;
            _expectedApiKey = expectedApiKey;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("X-API-KEY", out var header))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            var apiKey = header.FirstOrDefault()?.ToLower();
            if (apiKey != _expectedApiKey)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            await _next(context);
        }
    }
}
