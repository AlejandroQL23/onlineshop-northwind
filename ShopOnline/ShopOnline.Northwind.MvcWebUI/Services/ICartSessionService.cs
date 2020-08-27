using ShopOnline.Northwind.Entities.Concrete;

namespace ShopOnline.Northwind.MvcWebUI.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
