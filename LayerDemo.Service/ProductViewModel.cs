using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerDemo.Service
{
    public class ProductViewModel
    {
        public int ProudctId { get; set; }
        public string ProductName { get; set; }
        public string RRP { get; set; }
        public string SellingPrice { get; set; }
        public string Discount { get; set; }
        public string Savings { get; set; }
    }
}
