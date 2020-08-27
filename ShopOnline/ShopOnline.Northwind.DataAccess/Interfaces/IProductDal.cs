using ShopOnline.Core.DataAccess;
using ShopOnline.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace ShopOnline.Northwind.DataAccess.Interfaces
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<Product> GetListPaged(out int totalCount, int page, int categoryId);
    }
}
