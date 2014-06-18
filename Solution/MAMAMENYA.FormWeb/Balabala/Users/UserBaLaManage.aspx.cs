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

namespace MAMAMENYA.FormWeb.Balabala.Users
{
    public partial class UserBaLaManage : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var data= EnumExtenstion.GetEnumList<UserStatus>(UserStatus.正常);
            
        }




    }
}