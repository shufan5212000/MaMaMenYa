using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAMAMENYA.Common;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;
using MAMAMENYA.Data;

namespace MAMAMENYA.FormWeb.Balabala.Users
{
    public partial class BaLaManage : System.Web.UI.Page
    {
        public IList<BaLaBaLa> PageData = new List<BaLaBaLa>();
        private const int PageSize = 15;
        public int PageIndex, PageCount;
        readonly IBaLaBaLaRepository _baLaBaLaRepository = new BaLaBaLaRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindData(1);
        }


        private void BindData(int pageIndex)
        {
            var query = new BaLaBaLaQuery()
                {
                    PageSize = PageSize,
                    PageIndex = pageIndex
                };

            var data = _baLaBaLaRepository.GetList(query);
            PageData = data.Data;
            PageIndex = data.PageIndex;
            PageCount = data.PageCount;

        }

        protected void OnPageChange_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                var btnName = btn.Text;
                switch (btnName)
                {
                    case "首页":
                        BindData(1);
                        break;
                    case "上一页":
                        if (PageIndex - 1 <= 0)
                        {
                            PageIndex = 1;
                        }
                        else
                        {
                            PageIndex = PageIndex - 1;
                        }
                        BindData(PageIndex);
                        break;
                    case "下一页":
                        if (PageIndex + 1 > PageCount)
                        {
                            PageIndex = PageCount;
                        }
                        else
                        {
                            PageIndex = PageIndex + 1;
                        }
                        BindData(PageIndex);
                        break;
                    case "尾页":
                        BindData(PageCount);
                        break;
                }
            }


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var item = new BaLaBaLa()
                {
                    AddTime = DateTime.Now,
                    LoginName = txtLoginName.Text.Trim(),
                    Pwd = Security.GetMD5_32(txtPwd.Text.Trim()),
                    RealName = txtRealName.Text.Trim()

                };

            _baLaBaLaRepository.SaveOrUpdate(item);

            Response.Redirect("BaLaManage.aspx");
        }
    }
}