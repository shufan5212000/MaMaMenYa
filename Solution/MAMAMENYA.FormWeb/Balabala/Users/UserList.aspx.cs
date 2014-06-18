using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;
using MAMAMENYA.Data;

namespace MAMAMENYA.FormWeb.Balabala.Users
{
    public partial class UserList : System.Web.UI.Page
    {
        public IList<User> PageData = new List<User>();
        public const int PageSize = 15;
        public int PageIndex, PageCount, RecordCount;
        readonly IUserRepository _userRepository = new UserRepository();


        protected void Page_Load(object sender, EventArgs e)
        {
            var currentPage = Request.QueryString["pageIndex"] ?? "1";

            var query = new UserQuery()
            {
                PageIndex = int.Parse(currentPage),
                PageSize = PageSize
            };
            var data = _userRepository.GetList(query);

            PageData = data.Data;
            PageIndex = data.PageIndex;
            PageCount = data.PageCount;
            RecordCount = data.RecordCount;
        }
    }
}