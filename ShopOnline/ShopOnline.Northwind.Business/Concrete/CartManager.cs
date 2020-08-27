using ShopOnline.Northwind.Business.Interfaces;
using ShopOnline.Northwind.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace ShopOnline.Northwind.Business.Concrete
{
    public class CartManager : ICartService
    {
        public void AddtoCart(Cart cart, Product product)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(p => p.Product.ProductId == product.ProductId);

            //Ürün sepette varsa;
            if (cartLine != null)
            {
                cartLine.Quantity++;
                return;
            }

            cart.CartLines.Add(new CartLine { Product = product, Quantity = 1 });
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(p => p.Product.ProductId == productId);

            if (cartLine != null)
                cart.CartLines.Remove(cartLine);
        }
    }
}
