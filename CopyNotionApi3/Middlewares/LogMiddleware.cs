namespace CopyNotionApi3.Middlewares;

// need static class
public class LogMiddleware
{
    private readonly RequestDelegate _next;

    public LogMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke (HttpContext context)
    {
        Stream req = context.Request.Body;


        await _next(context);
    }
}