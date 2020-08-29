using Microsoft.AspNetCore.Mvc.Rendering;
using ShopOnline.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace ShopOnline.Northwind.MvcWebUI.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public List<SelectListItem> Categories { get; set; }
        public Product Product { get; set; }
    }
}
