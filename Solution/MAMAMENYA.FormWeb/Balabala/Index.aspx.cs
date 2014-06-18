using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAMAMENYA.FormWeb.UI;

namespace MAMAMENYA.FormWeb.Balabala
{
    public partial class Index : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var args = Request.QueryString["Action"];
            if (args == "Logout")
            {
                WriteCookie("BaLaBaLa", CurrentUser.LoginName, -14400);
                Response.Redirect("Login.aspx");
            }
        }
    }
}