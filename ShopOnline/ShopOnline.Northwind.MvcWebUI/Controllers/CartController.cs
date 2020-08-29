using Microsoft.AspNetCore.Mvc;
using ShopOnline.Northwind.Business.Interfaces;
using ShopOnline.Northwind.Entities.Concrete;
using ShopOnline.Northwind.MvcWebUI.Models;
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
        public IActionResult List()
        {
            var cart = _cartSessionService.GetCart();

            var cartListViewModel = new CartListViewModel
            {
                Cart = cart
            };

            return View(cartListViewModel);
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

        [HttpGet]
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);

            TempData["message"] = $"Your product was successfully removed from the cart!";

            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public IActionResult Complete()
        {
            var shippingDetailViewModel = new ShippingDetailViewModel
            {
                ShippingDetails = new ShippingDetails()
            };

            return View(shippingDetailViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Complete(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
                return View();

            TempData["message"] = $"Thank you {shippingDetails.FirstName}, you order is in process";

            return View();
        }
    }
}
