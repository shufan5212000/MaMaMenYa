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
    public partial class ArticleBaLaManage : System.Web.UI.Page
    {

        private readonly IArticleClassRepository _articleClassRepository = new ArticleClassRepository();
        public IList<ArticleClass> AllClass=new List<ArticleClass>();  


        protected void Page_Load(object sender, EventArgs e)
        {
            AllClass = _articleClassRepository.GetAll();
        }

       



    }
}