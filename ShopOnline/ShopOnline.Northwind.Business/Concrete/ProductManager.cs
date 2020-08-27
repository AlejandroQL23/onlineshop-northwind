using ShopOnline.Northwind.Business.Interfaces;
using ShopOnline.Northwind.DataAccess.Interfaces;
using ShopOnline.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ShopOnline.Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategoryId(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryId == categoryId);
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product { ProductId = productId });
        }

        public List<Product> GetListPaged(out int totalCount, int page, int categoryId)
        {
            return _productDal.GetListPaged(out totalCount, page, categoryId);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(i => i.ProductId == productId);
        }
    }
}
