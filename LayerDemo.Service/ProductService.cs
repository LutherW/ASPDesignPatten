using LayerDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelService = LayerDemo.Model.ProductService;

namespace LayerDemo.Service
{
    public class ProductService
    {
        private ModelService _modelService;

        public ProductService(Model.ProductService modelService) 
        {
            _modelService = modelService;
        }

        public ProductListResponse GetAllProductsFor(ProductListRequest request) 
        {
            ProductListResponse response = new ProductListResponse();
            try
            {
                IList<Product> products = _modelService.GetAllProducts(request.CustomerType);
                response.Products = products.ToViews();
                response.Success = true;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // Log the exception...

                response.Success = false;
                // Return a friendly error message
                response.Message = ex.Message;
            }
            catch
            {
                // 记录日志
                // 显示友好的错误信息
                response.Success = false;
                response.Message = "An error occurred";
            }

            return response;
        }
    }
}
