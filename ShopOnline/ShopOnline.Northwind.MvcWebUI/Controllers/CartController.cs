using Microsoft.AspNetCore.Mvc;
using ShopOnline.Northwind.Business.Interfaces;
using ShopOnline.Northwind.MvcWebUI.Services;

namespace ShopOnline.Northwind.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartSessionService _cartSessionService;
        private readonly ICartService _cartService;
        private readonly IProductService _productService;

        public CartController(ICartSessionService cartSessionService, ICartService cartService, IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult AddToCart(int productId)
        {
            var productToBeAdded = _productService.GetById(productId);

            //Session'daki sepet'i çek.
            var cart = _cartSessionService.GetCart();

            //Sepete'e ürün ekle.
            _cartService.AddtoCart(cart, productToBeAdded);

            //Session'daki sepeti güncelle.
            _cartSessionService.SetCart(cart);

            TempData["message"] = $"Your product, {productToBeAdded.ProductName}, was successfully added to the cart!";

            return RedirectToAction("Index", "Product");
        }
    }
}
