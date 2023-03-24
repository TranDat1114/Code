using Microsoft.EntityFrameworkCore;

using NET_4_ASM_API.Models;

namespace NET_4_ASM_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options => options.AddPolicy(name: "myOrigin", policy =>
            {
                policy.WithOrigins("https://localhost:7013",
                                    "http://localhost:5173");
            }));

            var Configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");

            builder.Services.AddDbContext<ShopBanCamContext>(options =>
                      options.UseSqlServer(Configuration.Build().GetConnectionString("ShopBanCam")));


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("myOrigin");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}