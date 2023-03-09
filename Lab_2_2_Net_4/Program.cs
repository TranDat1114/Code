public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("<div> Hello Fpoly from the middleware 1 </div>");
            await next.Invoke();
            await context.Response.WriteAsync("<div> Hello Fpoly from the middleware 1 </div>");

        });
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("<div> Hello Fpoly from the middleware 2 </div>");
            await next.Invoke();
            await context.Response.WriteAsync("<div> Hello Fpoly from the middleware 2 </div>");

        });
        app.Run(async (context) =>
        {
            context.Response.WriteAsync("<div> Hello Fpoly from the middleware 3 </div>");
        });

        app.Run();
    }
}