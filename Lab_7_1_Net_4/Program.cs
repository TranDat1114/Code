using Lab_7_1_Net_4.Models;

using Microsoft.EntityFrameworkCore;

namespace Lab_7_1_Net_4
{
    public class Program
    {

        //Scaffold-DbContext "Server=HOANG-TRAN\MOONSERVER; Database= Inventory; Trusted_Connection=True; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -f
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
.AddJsonFile($"appsettings.json");

            ConfigurationRoot config = (ConfigurationRoot)configuration.Build();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<InventoryContext>(options => options.UseSqlServer(config.GetConnectionString("InventoryDatabase")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if(!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Products}/{action=Index}/{id?}");

            app.Run();
        }
    }
}