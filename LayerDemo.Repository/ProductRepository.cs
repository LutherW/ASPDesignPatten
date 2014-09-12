using LayerDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerDemo.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IList<Product> FindAll()
        {
            var products = from p in new ShopDataContext().Products
                           select new Product
                           {
                               Id = p.ProductId,
                               Name = p.ProductName,
                               Price = new Price(p.RRP, p.SellingPrice)
                           };

            return products.ToList();
        }
    }
}
