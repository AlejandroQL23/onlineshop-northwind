using ShopOnline.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace ShopOnline.Northwind.MvcWebUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; internal set; }
        public int CurrentCategory { get; internal set; }
        public int CurrentPage { get; set; }
    }
}
