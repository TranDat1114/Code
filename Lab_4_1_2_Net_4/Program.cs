namespace Lab_4_1_2_Net_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            //Hỗ trợ route
            app.UseRouting();

            //Cách sử dụng route phù hợp trên .net 6
            //Thêm nữa không dùng được ATTRIBUTE ROUTES nếu không khai báo ông nội bên dưới, chưa hiểu lý do tại sao, nhớ hỏi thầy
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");

                //Dùng mapRoute để route nhưng thích dùng attribute routes hơn kkkk : 3
                //endpoints.MapControllerRoute(
                //    name: "student",
                //    pattern: "{controller}/{action}/{id}",
                //    new { controller = "Home", action = "Details" }, new { id = new IntRouteConstraint() });
            });
            app.Run();
        }
    }
}