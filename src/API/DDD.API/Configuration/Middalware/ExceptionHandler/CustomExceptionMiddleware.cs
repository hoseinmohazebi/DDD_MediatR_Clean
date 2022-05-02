using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DDD.API.Configuration.Middalware.ExceptionHandler
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JsonSerializerSettings _jsonSettings;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));

            _jsonSettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                if (context.Response.HasStarted)
                {
                    throw;
                }

                context.Response.StatusCode = 400;
                var message = "Error";
                if (exception.Message != null)
                {
                    message = exception.Message;
                }
                context.Response.Headers.Add("exception", message);
                await context.Response.WriteAsync(message);

            }
        }
    }
}
