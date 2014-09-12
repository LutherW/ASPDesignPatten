using LayerDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerDemo.Service
{
    public static class ProductMapperExtensionMethods
    {
        public static IList<ProductViewModel> ToViews(this IList<Product> products)
        {
            IList<ProductViewModel> viewModels = new List<ProductViewModel>();
            foreach (Product product in products)
            {
                viewModels.Add(product.ToView());
            }

            return viewModels;
        }

        public static ProductViewModel ToView (this Product product)
        {
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.ProudctId = product.Id;
            viewModel.ProductName = product.Name;
            viewModel.RRP = string.Format("{0:C}", product.Price.RRP);
            viewModel.SellingPrice = string.Format("{0:C}", product.Price.SellingPrice);
            if (product.Price.Discount > 0)
            {
                viewModel.Discount = string.Format("{0:C}", product.Price.Discount);
            }
            if (product.Price.Savings < 1 && product.Price.Savings > 0)
            {
                viewModel.Savings = product.Price.Savings.ToString("#%");
            }

            return viewModel;
        }
    }
}
