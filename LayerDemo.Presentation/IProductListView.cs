using LayerDemo.Model;
using LayerDemo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerDemo.Presentation
{
    public interface IProductListView
    {
        void Display(IList<ProductViewModel> products);
        CustomerType CustomerType { get; }
        string ErrorMessage { set; }
    }
}
