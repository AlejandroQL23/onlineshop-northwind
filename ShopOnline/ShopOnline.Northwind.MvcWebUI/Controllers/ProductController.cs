using Microsoft.AspNetCore.Mvc;
using ShopOnline.Northwind.Business.Interfaces;
using ShopOnline.Northwind.MvcWebUI.Models;

namespace ShopOnline.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        { 
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _productService.GetAll();

            ProductListViewModel productListViewModel = new ProductListViewModel
            {
                Products = products
            };

            return View(productListViewModel);
        }
    }
}
