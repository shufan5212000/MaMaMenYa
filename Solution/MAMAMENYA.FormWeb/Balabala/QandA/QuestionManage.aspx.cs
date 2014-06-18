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
    public partial class QuestionManage : PageBase
    {
        public IList<QuestionClass> QuestionClasses = new List<QuestionClass>();
        private IQuestionClassRepository _questionClassRepository = new QuestionClassRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QuestionClasses = _questionClassRepository.GetAll();
            }
        }
    }
}