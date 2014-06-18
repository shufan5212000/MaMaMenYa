using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;
using MAMAMENYA.Data;

namespace MAMAMENYA.FormWeb.Balabala.Articles
{
    public partial class ArticleClassBaLaManage : System.Web.UI.Page
    {
        private readonly IArticleClassRepository _articleClassRepository = new ArticleClassRepository();
        public IList<ArticleClass> PageData = new List<ArticleClass>();


        private const int PageSize = 15;
        public int PageIndex, PageCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindData(1);
            if (!IsPostBack)
            {
                var dataSourceClass = _articleClassRepository.GetAll();
                dataSourceClass.Add(new ArticleClass(){Name = "--------请选择--------"});
                drpClassPageData.DataSource = dataSourceClass.OrderBy(c=>c.Id);
                drpClassPageData.DataTextField = "Name";
                drpClassPageData.DataValueField = "Id";
                drpClassPageData.DataBind();

                
            }
        }

        private void BindData(int pageIndex)
        {
            var query = new ArticleClassQuery() { PageIndex = pageIndex, PageSize = PageSize };
            var data = _articleClassRepository.GetList(query);

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var item = new ArticleClass()
                {
                    AddTime = DateTime.Now,
                    Description = txtDescription.Text.Trim(),
                    Keyword = txtKeyword.Text.Trim(),
                    Name = txtClassName.Text.Trim(),
                    Remark = txtRemark.Text.Trim()

                };

            if (drpClassPageData.SelectedItem != null)
            {
                item.Parent = _articleClassRepository.Get(int.Parse(drpClassPageData.SelectedValue));
            }

            _articleClassRepository.SaveOrUpdate(item);
            Response.Redirect("ArticleClassBaLaManage.aspx");
        }
    }
}