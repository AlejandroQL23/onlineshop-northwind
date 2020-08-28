using Microsoft.AspNetCore.Mvc;
using ShopOnline.Northwind.MvcWebUI.Models;
using ShopOnline.Northwind.MvcWebUI.Services;
using System.Threading.Tasks;

namespace ShopOnline.Northwind.MvcWebUI.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly ICartSessionService _cartSessionService;
        public CartSummaryViewComponent(ICartSessionService cartSessionService)
        {
            _cartSessionService = cartSessionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartSummaryViewModel = new CartSummaryViewModel
            {
                Cart = _cartSessionService.GetCart()
            };

            return await Task.Run(() => View(cartSummaryViewModel));
        }
    }
}
