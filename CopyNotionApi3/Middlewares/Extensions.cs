namespace CopyNotionApi3.Middlewares;

// NOTE: require static class
public static class Extensions
{
    // NOTE: using template method to add use middleware to app 
    public static IApplicationBuilder UseSimpleLog(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LogMiddleware>();
    }
}
