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
    public partial class AdsBaLaManage : PageBase
    {
        public IList<AdsClass> AllAdsClass = new List<AdsClass>();
        private readonly IAdsClassRepository _adsClassRepository = new AdsClassRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            var action = Request.QueryString["action"];
            if (!IsPostBack)
            {
                AllAdsClass = _adsClassRepository.GetAll();
            }
            else
            {

                if (action == "Add")
                {
                    AddClass();
                }
            }
        }

        private void AddClass()
        {
            var item = new AdsClass()
                {
                    Name = Request.Form["Name"]
                };

            _adsClassRepository.SaveOrUpdate(item);
            JsMsgBox(string.Empty, AlertType.成功);
        }
    }
}