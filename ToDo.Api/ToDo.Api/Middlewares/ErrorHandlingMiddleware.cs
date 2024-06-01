using System.Text.Json;
using ToDo.Domain.Exceptions;

namespace ToDo.Api.Middlewares;

public class ErrorHandlingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context).ConfigureAwait(true);
        }
        catch (Exception ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            response.StatusCode = (ex switch
            {
                ArgumentNullException => StatusCodes.Status400BadRequest,
                AuthenticationException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError,
            });

            await response.WriteAsync(JsonSerializer.Serialize(new { ErrorMessage = ex.Message }));
        }
    }
}
