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
    public partial class CommentBalaManage : System.Web.UI.Page
    {
        public IList<Comment> PageData = new List<Comment>();

        private const int PageSize = 15;
        public int PageIndex, PageCount;
        private readonly ICommentRepository _commentRepository = new CommentRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindData(1);
        }

        private void BindData(int currentPageIndex)
        {
            var query = new CommentQuery()
                {
                    PageSize = PageSize,
                    PageIndex = currentPageIndex
                };
            var data=_commentRepository.GetList(query);

            PageData = data.Data;
            PageCount = data.PageCount;
            PageIndex = data.PageIndex;
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
    }
}