using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;
using MAMAMENYA.Data;
using MAMAMENYA.Common;
namespace MAMAMENYA.FormWeb.Balabala.Products
{
    public partial class ProductAddBal : System.Web.UI.Page
    {
        private readonly IProductRepository _productRepository = new ProductRepository();
        private readonly IProductClassRepository _productClassRepository = new ProductClassRepository();
        private readonly IBrandRepository _brandRepository = new BrandRepository();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindPageData();
            }
        }

        private void BindPageData()
        {


            if (Request.QueryString["Id"] != null)
            {
                var currentProduct = _productRepository.Get(int.Parse(Request.QueryString["Id"]));

            }
            else
            {
                drpPlantform.DataSource = EnumExtenstion.GetEnumList<Plantform>(Plantform.一号店);
                drpPlantform.DataTextField = "Text";
                drpPlantform.DataValueField = "Value";
                drpPlantform.DataBind();

                drpCreting.DataSource = EnumExtenstion.GetEnumList<CreditRating>(CreditRating.一星);
                drpCreting.DataValueField = "Value";
                drpCreting.DataTextField = "Text";
                drpCreting.DataBind();

                drpProductClass.DataSource = _productClassRepository.GetAll();
                drpProductClass.DataTextField = "Name";
                drpProductClass.DataValueField = "Id";
                drpProductClass.DataBind();

                drpBrand.DataSource = _brandRepository.GetAll();
                drpBrand.DataTextField = "Name";
                drpBrand.DataValueField = "Id";
                drpBrand.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var item = new Product()
                {
                    ProductName = txtProductName.Text.Trim(),
                    BuyCount = int.Parse(txtBuyCount.Text.Trim()),
                    ClickCount = 0,
                    Content = txtProdctContent.Text,
                    FavorableCount = 0,
                    Inventory = int.Parse(txtInventory.Text.Trim()),
                    Price = decimal.Parse(txtPrice.Text.Trim()),
                    ProductClass = _productClassRepository.Get(int.Parse(drpProductClass.SelectedValue)),
                    ProductKeyword = txtKeyword.Text.Trim(),
                    ShopName = txtShopName.Text.Trim(),
                    Summary = txtSummary.Text.Trim(),
                    UpdateTime = DateTime.Now,
                    ProductUrl = txtProductUrl.Text.Trim(),
                    PlantformName = (Plantform)Enum.Parse(typeof(Plantform), drpPlantform.SelectedItem.Text),
                    Pic = txtPicUrl.Text.Trim(),
                    ProductBrand = _brandRepository.Get(int.Parse(drpBrand.SelectedValue))
                };
            _productRepository.SaveOrUpdate(item);
            Response.Redirect("ProductBaLaManage.aspx");
        }
    }
}