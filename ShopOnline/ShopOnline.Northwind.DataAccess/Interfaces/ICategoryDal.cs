using ShopOnline.Core.DataAccess;
using ShopOnline.Northwind.Entities.Concrete;

namespace ShopOnline.Northwind.DataAccess.Interfaces
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}
