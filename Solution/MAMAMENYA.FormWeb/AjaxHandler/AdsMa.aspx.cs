using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;
using MAMAMENYA.Data;

namespace MAMAMENYA.FormWeb.AjaxHandler
{
    public partial class AdsMa : System.Web.UI.Page
    {
        private readonly IAdsClassRepository _adsClassRepository=new AdsClassRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            var action = Request.QueryString["action"];
            if (action == "Add")
            {
                Add();
            }
        }

        private void Add()
        {
            
            
        }
    }
}