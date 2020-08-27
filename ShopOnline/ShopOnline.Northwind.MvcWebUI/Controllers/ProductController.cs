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
        public IActionResult Index(int page = 1, int categoryId = 0)
        {
            int totalCount = 0;
            var products = _productService.GetListPaged(out totalCount, page, categoryId);

            var productListViewModel = new ProductListViewModel
            {
                Page = page,
                PageSize = totalCount / 10,
                Products = products
            };

            return View(productListViewModel);
        }
    }
}
