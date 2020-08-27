using ShopOnline.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace ShopOnline.Northwind.MvcWebUI.Models
{
    public class ProductListViewModel
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public List<Product> Products { get; internal set; }
    }
}
