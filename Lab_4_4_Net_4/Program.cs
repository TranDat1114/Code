namespace Lab_4_4_Net_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //Câu c
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: @"{controller}/{action}",
                    new { controller = "Home", action = "Index" });
                //Câu a
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: @"{controller}/{action}/{year:regex(^\d{{4}}$)?}",
                //    new { controller = "Home", action = "Index" });

                //Câu b
                //endpoints.MapControllerRoute(
                //        name: "default",
                //        pattern: @"{controller}/{action}/{year?}",
                //        new { controller = "Home", action = "Index" }, new { year = new RegexRouteConstraint(@"^\d{4}$") });
            });
            app.Run();
        }
    }
}