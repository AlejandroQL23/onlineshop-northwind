using Microsoft.Extensions.Options;
using ShopOnline.Core.DataAccess.EntityFrameworkCore;
using ShopOnline.Core.Settings;
using ShopOnline.Northwind.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using ShopOnline.Northwind.DataAccess.Interfaces;
using ShopOnline.Northwind.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace ShopOnline.Northwind.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfProductRepository : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public IOptions<ProductControllerSettings> _productControllerSettings { get; set; }
        public EfProductRepository(IOptions<ProductControllerSettings> productControllerSettings)
        {
            _productControllerSettings = productControllerSettings;
        }

        public List<Product> GetListPaged(out int totalCount, int page, int categoryId)
        {
            using var context = new NorthwindContext();
            var query = context.Products.AsQueryable();

            if (categoryId > 0)
                query = query.Where(p => p.CategoryId == categoryId);

            totalCount = query.Count();

            if (page > 0)
                query = query.Skip((page - 1) * _productControllerSettings.Value.IndexPageSize);

            return query.Take(_productControllerSettings.Value.IndexPageSize).ToList();
        }
    }
}
