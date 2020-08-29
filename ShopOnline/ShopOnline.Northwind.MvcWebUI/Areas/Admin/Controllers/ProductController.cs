using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopOnline.Northwind.Business.Interfaces;
using ShopOnline.Northwind.Entities.Concrete;
using ShopOnline.Northwind.MvcWebUI.Areas.Admin.Models;
using ShopOnline.Northwind.MvcWebUI.Models;
using System.Collections.Generic;

namespace ShopOnline.Northwind.MvcWebUI.Areas.Admin.Controllers
{
    public class ProductController : BaseAdminController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [NonAction]
        public List<SelectListItem> PrepareProductCategorySelectListItems(int productCategoryId = 0)
        {
            var selectListCategories = new List<SelectListItem>();

            var categories = _categoryService.GetAll();

            foreach (var category in categories)
            {
                var selectListItem = new SelectListItem
                {
                    Text = category.CategoryName,
                    Value = $"{category.CategoryId}"
                };

                if (productCategoryId > 0)
                    selectListItem.Selected = productCategoryId == category.CategoryId;

                selectListCategories.Add(selectListItem);
            }

            return selectListCategories;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var productListViewModel = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };

            return View(productListViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var productAddViewModel = new ProductViewModel
            {
                Categories = PrepareProductCategorySelectListItems()
            };

            return View(productAddViewModel);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (!ModelState.IsValid)
                return View();

            _productService.Add(product);
            TempData["message"] = "Product was successfully added!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int productId)
        {
            if (0 >= productId)
                return RedirectToAction(nameof(Index));

            var product = _productService.GetById(productId);

            var productUpdateViewModel = new ProductViewModel
            {
                Product = product,
                Categories = PrepareProductCategorySelectListItems(product.CategoryId)
            };

            return View(productUpdateViewModel);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View();

            _productService.Update(product);
            TempData["message"] = "Product was successfully updated!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int productId)
        {
            if (0 >= productId)
                return RedirectToAction(nameof(Index));

            _productService.Delete(productId);
            TempData["message"] = "Product was successfully deleted!";

            return RedirectToAction(nameof(Index));
        }
    }
}
