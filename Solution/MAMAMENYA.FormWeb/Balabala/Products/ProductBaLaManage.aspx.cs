using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;
using MAMAMENYA.Data;

namespace MAMAMENYA.FormWeb.Balabala.Products
{
    public partial class ProductBaLaManage : System.Web.UI.Page
    {
        public IList<Product> PageData = new List<Product>();

        private const int PageSize = 3;
        public int PageIndex, PageCount;
        private readonly IProductRepository _productRepository = new ProductRepository();
        private readonly IProductClassRepository _productClassRepository=new ProductClassRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                //BindData(1);

                drpPlantform.DataSource = EnumExtenstion.GetEnumList<Plantform>(Plantform.一号店);
                drpPlantform.DataTextField = "Text";
                drpPlantform.DataValueField = "Value";
                drpPlantform.DataBind();



                drpProductClass.DataSource = _productClassRepository.GetAll();
                drpProductClass.DataTextField = "Name";
                drpProductClass.DataValueField = "Id";
                drpProductClass.DataBind();

                drpProductClass.Items.Add(new ListItem("-----请选择------","0"));
            }
        }

        //protected void OnPageChange_Click(object sender, EventArgs e)
        //{
        //    var btn = sender as Button;
           


        //    if (btn != null)
        //    {
        //        var currentPage = btn.TabIndex;
        //        var btnName = btn.Text;
        //        switch (btnName)
        //        {
        //            case "首页":
        //                BindData(1);
        //                break;
        //            case "上一页":
        //                if (currentPage <= 0)
        //                {
        //                    currentPage = 1;
        //                }

        //                BindData(currentPage);
        //                break;
        //            case "下一页":
        //                if (currentPage > PageCount)
        //                {
        //                    currentPage = short.Parse(PageCount.ToString());
        //                }

        //                BindData(currentPage);
        //                break;
        //            case "尾页":
        //                BindData(currentPage);
        //                break;
        //        }
        //    }


        //}


        private void BindData(int pageIndex)
        {
            var query = new ProductQuery()
            {
                PageIndex = pageIndex,
                PageSize = PageSize
            };

            var data = _productRepository.GetList(query);
            PageData = data.Data;
            PageCount = data.PageCount;
            pageIndex = data.PageIndex;


            //btnFirstPage.TabIndex = 1;
            //btnLastpage.TabIndex = short.Parse(PageCount.ToString());
            //btnNext.TabIndex = short.Parse((pageIndex + 1).ToString());
            //btnPrevious.TabIndex = short.Parse((PageIndex - 1).ToString());

        }
    }
}