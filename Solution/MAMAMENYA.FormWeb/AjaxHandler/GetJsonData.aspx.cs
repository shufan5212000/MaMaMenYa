using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAMAMENYA.Core.InterfaceRepository;
using MAMAMENYA.Data;
using Newtonsoft.Json;

namespace MAMAMENYA.FormWeb.AjaxHandler
{
    public partial class GetJsonData : System.Web.UI.Page
    {
        private IUserRepository _userRepository = new UserRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetUser(1);
        }

        private string GetUser(int userId)
        {
            var item = _userRepository.Get(userId);
            return JsonConvert.SerializeObject(item);
        }
    }
}