using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerDemo.Model
{
    public static class ProductListExtensionMethod
    {
        public static void Apply(this IList<Product> products, IDiscountStrategy discountStrategy) 
        {
            foreach (Product product in products)
            {
                product.Price.SetDiscountStrategyTo(discountStrategy);
            }
        }
    }
}
