using System.Globalization;

namespace Lab_3_2_Net_4.Models
{
    public class SanPham
    {
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Sale { get; set; }
        public int Discount { get; set; }
        public int Review { get; set; }
        public Star StarReview { get; set; }
        public MoTa Description { get; set; }


        public string GetVNDPrice(int amount)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return amount.ToString("C0", cul);
        }

    }
}
