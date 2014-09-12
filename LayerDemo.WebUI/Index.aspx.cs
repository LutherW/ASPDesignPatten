using LayerDemo.Model;
using LayerDemo.Presentation;
using LayerDemo.Service;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LayerDemo.WebUI
{
    public partial class Index : System.Web.UI.Page, IProductListView
    {
        private ProductListPresenter _productListPresenter;

        protected void Page_Init(object sender, EventArgs e) 
        {
            _productListPresenter = new ProductListPresenter(this, ObjectFactory.GetInstance<Service.ProductService>());
            ddlCustomerType.SelectedIndexChanged += delegate { _productListPresenter.Display(); };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _productListPresenter.Display();
            }
        }

        public void Display(IList<Service.ProductViewModel> products)
        {
            rptProducts.DataSource = products;
            rptProducts.DataBind();
        }

        public Model.CustomerType CustomerType
        {
            get 
            { 
                return (CustomerType)Enum.ToObject(typeof(CustomerType), int.Parse(ddlCustomerType.SelectedValue)); 
            }
        }

        public string ErrorMessage
        {
            set { lblErrorMessage.Text = String.Format("<p><strong>Error</strong><br/>{0}<p/>", value); }
        }
    }
}