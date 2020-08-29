using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ShopOnline.Core.Settings;
using ShopOnline.Northwind.Business.Interfaces;
using ShopOnline.Northwind.MvcWebUI.Models;
using System;

namespace ShopOnline.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOptions<ProductControllerSettings> _productControllerSettings;
        public ProductController(IProductService productService, IOptions<ProductControllerSettings> productControllerSettings)
        {
            _productService = productService;
            _productControllerSettings = productControllerSettings;
        }

        [HttpGet]
        public IActionResult Index(int page = 1, int category = 0)
        {
            var products = _productService.GetListPaged(out int totalCount, page, category);

            var productListViewModel = new ProductListViewModel
            {
                Products = products,
                PageCount = (int)Math.Ceiling((double)totalCount / _productControllerSettings.Value.IndexPageSize),
                PageSize = _productControllerSettings.Value.IndexPageSize,
                CurrentCategory = category,
                CurrentPage = page
            };

            return View(productListViewModel);
        }
    }
}
