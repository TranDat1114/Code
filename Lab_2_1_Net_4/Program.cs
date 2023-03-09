using Lab_2_1_Net_4;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Book> books = new List<Book>();
        var configuration = new ConfigurationBuilder()
     .AddJsonFile($"appsettings.json");

        ConfigurationRoot config = (ConfigurationRoot)configuration.Build();

        var builder = WebApplication.CreateBuilder(args);
        for(int i = 0 ; i < 2 ; i++)
        {
            books.Add(new Book()
            {
                id = Convert.ToInt32(config.GetSection($"Book:{i}:id").Value),
                author = config.GetSection($"Book:{i}:author").Value,
                edition = config.GetSection($"Book:{i}:edition").Value,
                language = config.GetSection($"Book:{i}:language").Value
            });
        }
        var app = builder.Build();


        app.Run(async context =>
        {
            foreach(var item in books)
            {
                await context.Response.WriteAsync($"{item.id}\n");
                await context.Response.WriteAsync($"{item.author}\n");
                await context.Response.WriteAsync($"{item.edition}\n");
                await context.Response.WriteAsync($"{item.language}\n");
                await context.Response.WriteAsync($"\n");
            }
        });

        app.Run();
    }
}