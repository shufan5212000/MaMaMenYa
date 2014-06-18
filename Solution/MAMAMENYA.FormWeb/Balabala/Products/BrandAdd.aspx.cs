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
    public partial class BrandAdd : System.Web.UI.Page
    {
        private readonly IBrandRepository _brandRepository = new BrandRepository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            var item = new Brand()
            {
                Description = txtProdctContent.Text,
                Name = txtProductName.Text.Trim(),
                ProductCount = int.Parse(txtProductCount.Text),
                UpdateTime = DateTime.Now,
                PicUrl = txtPicUrl.Text.Trim()
            };
            _brandRepository.SaveOrUpdate(item);
            Response.Redirect("BrandBaLaManage.aspx");
        }
    }
}