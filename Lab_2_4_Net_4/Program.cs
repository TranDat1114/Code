using Lab_2_4_Net_4.Models;

namespace Lab_2_4_Net_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            List<Fruit> fruits = new List<Fruit>();
            var configuration = new ConfigurationBuilder()
         .AddJsonFile($"appsettings.json");

            ConfigurationRoot config = (ConfigurationRoot)configuration.Build();

            var fruitSections = config.GetSection("fruit").GetChildren();

            int i = 1;
            foreach(var item in fruitSections)
            {
                fruits.Add(new Fruit()
                {
                    Name = (config.GetSection($"fruit:{i}:name").Value),
                    Price = Convert.ToInt32(config.GetSection($"fruit:{i}:price").Value),
                });
            }


            var app = builder.Build();


            app.Run(async context =>
            {
                await context.Response.WriteAsync($"{fruits.Sum(p => p.Price)}\n ");

            });
            app.Run();
        }
    }
}