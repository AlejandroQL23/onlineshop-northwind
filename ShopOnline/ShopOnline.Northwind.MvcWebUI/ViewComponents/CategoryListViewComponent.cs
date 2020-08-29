using Microsoft.AspNetCore.Mvc;
using ShopOnline.Northwind.Business.Interfaces;
using ShopOnline.Northwind.MvcWebUI.Models;
using System;
using System.Threading.Tasks;

namespace ShopOnline.Northwind.MvcWebUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new CategoryListViewModel
            {
                Categories = _categoryService.GetAll(),
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["category"]),
                CurrentPage = Convert.ToInt32(HttpContext.Request.Query["page"])
            };

            return await Task.Run(() => View(model));
        }
    }
}
