using Lab_7_2_Net_4.Models;

using Microsoft.EntityFrameworkCore;

namespace Lab_7_2_Net_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            var Configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");

            builder.Services.AddDbContext<ShopBanCamContext>(options =>
                    options.UseSqlServer(Configuration.Build().GetConnectionString("ShopBanCam")));

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Home}/{action=Index}/{catagory?}");
            });

            app.Run();
        }
    }
}