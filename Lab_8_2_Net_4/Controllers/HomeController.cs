using Lab_8_2_Net_4.Helpers;
using Lab_8_2_Net_4.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Lab_8_2_Net_4.Controllers
{
    public class HomeController: Controller
    {

        private readonly ShopBanCamContext _context;


        public HomeController(ShopBanCamContext context)
        {
            _context = context;
        }

        [Route("/")]
        [Route("/Home")]
        [Route("/Home/Index")]
        public async Task<ActionResult> Index(string catagory = "")
        {
            var danhMucSanPham = await _context.Categories.ToListAsync();

            if(catagory.IsNullOrEmpty())
            {
                catagory = "camera";
            }
            var shopBanCamContext = await _context.Products.Where(p => p.Category.CategoryName == catagory).Include(p => p.Brand).Include(p => p.Category).Include(p => p.ProductImages).ToListAsync();



            ViewBag.catagories = danhMucSanPham;
            ViewBag.products = shopBanCamContext;

            return View();
        }


        [Route("/Home/ProductDetails")]
        [Route("/Home/ProductDetails/productId")]

        public async Task<ActionResult> ProductDetails(int productId)
        {

            var productDetails = await _context.Products.Where(p => p.ProductId == productId).Include(p => p.Brand).Include(p => p.Category).Include(p => p.ProductImages).Include(p => p.Reviews).FirstOrDefaultAsync();


            ViewBag.productDetails = productDetails;


            return View();
        }

        [Route("/Home/CartDetails")]
        public async Task<ActionResult> CartDetails()
        {

            var test = SessionNJsonHelper.GetObjectAsJson<List<CartItem>>(HttpContext.Session, "CartItem");

            return View();
        }


        [Route("Home/Buy/{idProduct}")]
        public async Task<IActionResult> Buy(int idProduct)
        {
            if(SessionNJsonHelper.GetObjectAsJson<Account>(HttpContext.Session, "Account") == null)
            {
                //Xử lý khi chưa đăng nhập
            }
            else
            {

                var cart = await _context.Carts.Where(p => p.AccountId == SessionNJsonHelper.GetObjectAsJson<Account>(HttpContext.Session, "Account").AccountId && p.Status != "Đã thanh toán").FirstOrDefaultAsync();
                if(cart == null)
                {
                    cart = new()
                    {
                        AccountId = SessionNJsonHelper.GetObjectAsJson<Account>(HttpContext.Session, "Account").AccountId,
                        Status = @"Chưa thanh toán",
                        UpdatedAt = DateTime.Now,
                        CreatedAt = DateTime.Now,
                    };
                    _context.Carts.Add(cart);
                    _context.SaveChanges();
                }

                if(SessionNJsonHelper.GetObjectAsJson<List<CartItem>>(HttpContext.Session, "CartItem") == null)
                {
                    CartItem cartItem = new()
                    {
                        ProductId = idProduct,
                        Product = _context.Products.Find(idProduct),
                        Quantity = 1,
                        CartId = cart.CartId
                    };

                    List<CartItem> cartItems = new List<CartItem>();
                    cartItems.Add(cartItem);
                    SessionNJsonHelper.SetObjectAsJson(HttpContext.Session, "CartItem", cartItems);
                }
                else
                {
                    List<CartItem> cartItems = SessionNJsonHelper.GetObjectAsJson<List<CartItem>>(HttpContext.Session, "CartItem");
                    if(IsExitsProductInCartHelper.IsExits(idProduct, cartItems))
                    {
                        cartItems.Find(p => p.ProductId == idProduct).Quantity += 1;
                    }
                    else
                    {
                        cartItems.Add(new CartItem()
                        {
                            ProductId = idProduct,
                            Product = _context.Products.Find(idProduct),
                            Quantity = 1,
                            CartId = cart.CartId
                        });
                    }
                    SessionNJsonHelper.SetObjectAsJson(HttpContext.Session, "CartItem", cartItems);
                }
            }

            return RedirectToAction("Index");
        }

        //Working
        [Route("Home/Remove/{idInCart}")]
        public async Task<IActionResult> Remove(int idInCart)
        {
            List<CartItem> cartItems = SessionNJsonHelper.GetObjectAsJson<List<CartItem>>(HttpContext.Session, "CartItem");
            if(cartItems != null)
            {
                cartItems.RemoveAt(idInCart - 1);
                SessionNJsonHelper.SetObjectAsJson(HttpContext.Session, "CartItem", cartItems);
            }

            return RedirectToAction("CartDetails");
        }


        [Route("Home/SaveCartsToDatabase")]
        public async Task<IActionResult> SaveCartsToDatabase()
        {
            List<CartItem> cartItems = SessionNJsonHelper.GetObjectAsJson<List<CartItem>>(HttpContext.Session, "CartItem");
            if(cartItems != null)
            {
                foreach(var item in cartItems)
                {

                    _context.CartItems.Add(new CartItem()
                    {
                        CartId = item.CartId,
                        ProductId = item.Product.ProductId,
                        Quantity = item.Quantity,
                    });
                }
                _context.Carts.Find(cartItems[0].CartId).Status = "Đã thanh toán";
                await _context.SaveChangesAsync();
                cartItems = new();
                SessionNJsonHelper.SetObjectAsJson(HttpContext.Session, "CartItem", cartItems);

            }

            return RedirectToAction("CartDetails");
        }

    }
}

