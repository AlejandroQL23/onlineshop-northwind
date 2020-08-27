using ShopOnline.Core.DataAccess.EntityFrameworkCore;
using ShopOnline.Northwind.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using ShopOnline.Northwind.DataAccess.Interfaces;
using ShopOnline.Northwind.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace ShopOnline.Northwind.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfProductRepository : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<Product> GetListPaged(out int totalCount, int page, int categoryId)
        {
            using var context = new NorthwindContext();
            var query = context.Products.AsQueryable();

            if (categoryId > 0)
                query = query.Where(p => p.CategoryId == categoryId);

            if (page > 0)
                query = query.Skip((page - 1) * 10);

            totalCount = query.Count();

            return query.Take(10).ToList();
        }
    }
}
