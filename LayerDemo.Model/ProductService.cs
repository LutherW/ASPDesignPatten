using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerDemo.Model
{
    public class ProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public IList<Product> GetAllProducts(CustomerType customerType) 
        {
            IDiscountStrategy discountStrategy = DiscountFactory.GetDiscountStrategyFor(customerType);
            IList<Product> products = _productRepository.FindAll();
            products.Apply(discountStrategy);

            return products;
        }
    }
}
