using ShopOnline.Core.Entities;

namespace ShopOnline.Northwind.Entities.Concrete
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
