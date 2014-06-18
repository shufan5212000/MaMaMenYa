using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;
using MAMAMENYA.Data;
using MAMAMENYA.FormWeb.UI;

namespace MAMAMENYA.FormWeb.Balabala.Articles
{
    public partial class AdsList : PageBase
    {
        public IList<Advertisement> PageData = new List<Advertisement>();

        public const int PageSize = 15;
        public int PageIndex, PageCount, RecordCount;
        private readonly IAdvertisementRepository _advertisementRepository = new AdvertisementRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            var currentPage = Request.QueryString["pageIndex"] ?? "1";
            var query = new AdvertisementQuery()
            {
                PageIndex = int.Parse(currentPage),
                PageSize = PageSize
            };

            var data = _advertisementRepository.GetList(query);
            PageData = data.Data;
            PageCount = data.PageCount;
            PageIndex = data.PageIndex;
            RecordCount = data.RecordCount;
        }
    }
}