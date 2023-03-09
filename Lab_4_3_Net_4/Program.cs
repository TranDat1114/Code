namespace Lab_4_3_Net_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            app.UseRouting();

            //Tạo routing
            app.UseEndpoints(endpoints =>
            {
                //Câu a
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id:int?}");

                //Câu b
                //Dùng mapRoute để route nhưng thích dùng attribute routes hơn kkkk : 3
                //endpoints.MapControllerRoute(
                //    name: "student",
                //    pattern: "{controller}/{action}/{id}",
                //    new { controller = "Home", action = "Index" }, new { id = new IntRouteConstraint() });
            });

            app.Run();
        }
    }
}