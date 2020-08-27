using ShopOnline.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace ShopOnline.Northwind.Business.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}
