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
    public partial class ArticleList : PageBase
    {
        public IList<Article> PageData = new List<Article>();

        public const int PageSize = 15;
        public int PageIndex, PageCount, RecordCount;
       
        private readonly IArticleRepository _articleRepository = new ArticleRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            var currentPage = Request.QueryString["pageIndex"] ?? "1";
            var query = new ArticleQuery()
            {
                PageIndex = int.Parse(currentPage),
                PageSize = PageSize
            };

            var data = _articleRepository.GetList(query);
            PageData = data.Data;
            PageCount = data.PageCount;
            PageIndex = data.PageIndex;
            RecordCount = data.RecordCount;
        }
    }
}