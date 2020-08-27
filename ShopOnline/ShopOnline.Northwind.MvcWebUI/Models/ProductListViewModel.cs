using ShopOnline.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace ShopOnline.Northwind.MvcWebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; internal set; }
        public int Page { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; internal set; }
        public int CurrentCategory { get; internal set; }
        public int CurrentPage { get; internal set; }
    }
}
