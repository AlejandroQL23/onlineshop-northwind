using Microsoft.EntityFrameworkCore;
using ShopOnline.Northwind.Entities.Concrete;

namespace ShopOnline.Northwind.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=HPPROBOOK;Database=BusinessTrackDb;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
