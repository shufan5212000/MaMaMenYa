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

namespace MAMAMENYA.FormWeb.Balabala.QandA
{
    public partial class QandAList : PageBase
    {
        public IList<Question> PageData = new List<Question>();

        public const int PageSize = 15;
        public int PageIndex, PageCount, RecordCount;

        private readonly IQuestionRepository _questionRepository = new QuestionRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            var currentPage = Request.QueryString["pageIndex"] ?? "1";
            var query = new ArticleQuery()
            {
                PageIndex = int.Parse(currentPage),
                PageSize = PageSize
            };

            var data = _questionRepository.GetList(query);
            PageData = data.Data;
            PageCount = data.PageCount;
            PageIndex = data.PageIndex;
            RecordCount = data.RecordCount;
        }
    }
}