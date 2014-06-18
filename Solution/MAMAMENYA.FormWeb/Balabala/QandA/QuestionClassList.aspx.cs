using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;
using MAMAMENYA.Data;

namespace MAMAMENYA.FormWeb.Balabala.QandA
{
    public partial class QuestionClassList : System.Web.UI.Page
    {
        public IList<QuestionClass> PageData = new List<QuestionClass>();

        public const int PageSize = 15;
        public int PageIndex, PageCount, RecordCount;

        private readonly IQuestionClassRepository _questionClassRepository = new QuestionClassRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            var currentPage = Request.QueryString["pageIndex"] ?? "1";
            var query = new ArticleQuery()
            {
                PageIndex = int.Parse(currentPage),
                PageSize = PageSize
            };

            var data = _questionClassRepository.GetList(query);
            PageData = data.Data;
            PageCount = data.PageCount;
            PageIndex = data.PageIndex;
            RecordCount = data.RecordCount;
        }
    }
}