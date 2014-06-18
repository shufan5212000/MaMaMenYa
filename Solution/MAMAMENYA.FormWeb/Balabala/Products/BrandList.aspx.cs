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
    public partial class BrandList : System.Web.UI.Page
    {
        public IList<Brand> PageData = new List<Brand>();

        public const int PageSize = 15;
        public int PageIndex, PageCount, RecordCount;
        private readonly IBrandRepository _brandRepository = new BrandRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            var currentPage = Request.QueryString["pageIndex"];
            if (currentPage == null)
            {
                currentPage = "1";
            }
            var query = new ProductQuery()
            {
                PageIndex = int.Parse(currentPage),
                PageSize = PageSize
            };

            var data = _brandRepository.GetList(query);
            PageData = data.Data;
            PageCount = data.PageCount;
            PageIndex = data.PageIndex;
            RecordCount = data.RecordCount;
        }
    }
}