using ShopOnline.Core.DataAccess.EntityFrameworkCore;
using ShopOnline.Northwind.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using ShopOnline.Northwind.DataAccess.Interfaces;
using ShopOnline.Northwind.Entities.Concrete;

namespace ShopOnline.Northwind.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCategoryRepository : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
    }
}
