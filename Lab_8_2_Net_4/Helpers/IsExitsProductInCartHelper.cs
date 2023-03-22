using Lab_8_2_Net_4.Models;

namespace Lab_8_2_Net_4.Helpers
{
    public static class IsExitsProductInCartHelper
    {
        public static bool IsExits(int idProduct, List<CartItem> cartItems)
        {
            return cartItems.Find(p => p.ProductId == idProduct) != null;
        }
    }
}
