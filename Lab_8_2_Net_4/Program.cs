using Lab_8_2_Net_4.Models;

using Microsoft.EntityFrameworkCore;

namespace Lab_8_2_Net_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var Configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");

            builder.Services.AddDbContext<ShopBanCamContext>(options =>
                      options.UseSqlServer(Configuration.Build().GetConnectionString("ShopBanCam")));

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{catagory?}");
            app.Run();
        }
    }
}