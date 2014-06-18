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
    public partial class ArticleAddBaLa : PageBase
    {
        private readonly IArticleRepository _articleRepository = new ArticleRepository();
        private readonly IArticleClassRepository _articleClassRepository = new ArticleClassRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                drpArticleClass.DataSource = _articleClassRepository.GetAll();
                drpArticleClass.DataTextField = "Name";
                drpArticleClass.DataValueField = "Id";
                drpArticleClass.DataBind();

                drpFrom.DataSource = EnumExtenstion.GetEnumList<ArticleFrom>(null);
                drpFrom.DataTextField = "Text";
                drpFrom.DataValueField = "Value";
                drpFrom.DataBind();
                if (Request.QueryString["Id"] != null)
                {
                    ModifyInit(Request.QueryString["Id"]);
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                ModifySave();
            }
            else
            {
                AddSave();
            }
        }

        private void ModifyInit(string articleId)
        {
            var item = _articleRepository.Get(int.Parse(articleId));
            txtArticleContent.Text = item.Content;
            txtKeyword.Text = item.Keyword;
            txtSummary.Text = item.Description;
            txtTitle.Text = item.Title;

            chkIsNice.Checked = item.IsNice;
            chkIsTop.Checked = item.IsTop;

            drpArticleClass.Text = item.ArticleClass.Name;
            drpArticleClass.SelectedValue = item.ArticleClass.Id.ToString();
        }

        private void AddSave()
        {
            var fileOnServer = string.Empty;
            if (fileUploadPic.PostedFile != null)
            {
                fileOnServer = base.UploadPic(fileUploadPic.PostedFile);
            }

            var item = new Article
            {
                Title = txtTitle.Text.Trim(),
                UpdateTime = DateTime.Now,
                Keyword = txtKeyword.Text.Trim(),
                Content = txtArticleContent.Text,
                Description = txtSummary.Text.Trim(),
                ArticleFrom = (ArticleFrom)Enum.Parse(typeof(ArticleFrom), drpFrom.SelectedItem.Text),
                ClickCount = 0,
                PicUrl = fileOnServer,
                IsTop = chkIsTop.Checked,
                IsNice = chkIsNice.Checked
            };

            if (drpArticleClass.SelectedItem != null)
            {
                item.ArticleClass = _articleClassRepository.Get(int.Parse(drpArticleClass.SelectedValue));
            }
            _articleRepository.SaveOrUpdate(item);
            Response.Redirect("ArticleBaLaManage.aspx");
        }

        private void ModifySave()
        {
            var fileOnServer = string.Empty;
            var articleId = Request.QueryString["Id"];
            var currentItem = _articleRepository.Get(int.Parse(articleId));

            if (fileUploadPic.PostedFile != null)
            {
                if (fileUploadPic.PostedFile.FileName != currentItem.PicUrl)
                {
                    currentItem.PicUrl = base.UploadPic(fileUploadPic.PostedFile);
                }
            }

            currentItem.Title = txtTitle.Text.Trim();
            currentItem.UpdateTime = DateTime.Now;
            currentItem.Keyword = txtKeyword.Text.Trim();
            currentItem.Content = txtArticleContent.Text;
            currentItem.Description = txtSummary.Text.Trim();
            currentItem.ArticleFrom = (ArticleFrom)Enum.Parse(typeof(ArticleFrom), drpFrom.SelectedItem.Text);
            currentItem.ClickCount = 0;

            currentItem.IsTop = chkIsTop.Checked;
            currentItem.IsNice = chkIsNice.Checked;

            _articleRepository.SaveOrUpdate(currentItem);
            Response.Redirect("ArticleBaLaManage.aspx");
        }
    }
}