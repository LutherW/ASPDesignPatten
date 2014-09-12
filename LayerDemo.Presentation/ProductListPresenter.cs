using LayerDemo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerDemo.Presentation
{
    public class ProductListPresenter
    {
        private IProductListView _productListView;
        private ProductService _productService;

        public ProductListPresenter(IProductListView productListView, ProductService productService) 
        {
            _productListView = productListView;
            _productService = productService;
        }

        public void Display() 
        {
            ProductListRequest request = new ProductListRequest();
            request.CustomerType = _productListView.CustomerType;
            ProductListResponse response = _productService.GetAllProductsFor(request);

            if (response.Success)
            {
                _productListView.Display(response.Products);
            }
            else 
            {
                _productListView.ErrorMessage = response.Message;
            }
        }
    }
}
