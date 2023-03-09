using System.ComponentModel.DataAnnotations;

namespace Lab_6_3_Net_4.Models
{
    public class ProductEditModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được bỏ trống")]
        [Display(Name = "Product")]
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
