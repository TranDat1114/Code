namespace Lab_8_1_Net_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(60);
            });

            var app = builder.Build();


            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
              name: "Default",
              pattern: "{controller=Home}/{action=Index}");
            });

            app.Run();
        }
    }
}