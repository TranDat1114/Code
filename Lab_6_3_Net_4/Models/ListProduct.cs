namespace Lab_6_3_Net_4.Models
{
    public class ListProduct
    {
        public static List<Product> Products = new List<Product>()
        {
            new()
        {
            Id=Guid.NewGuid(),
            Name="Sản phẩm",
             Price=2,
             Quantity= 3
        },
            new()
            {

        Id=Guid.NewGuid(),
            Name="Sẩm phản",
             Price=2,
             Quantity= 3
            }
        };
    }
}
