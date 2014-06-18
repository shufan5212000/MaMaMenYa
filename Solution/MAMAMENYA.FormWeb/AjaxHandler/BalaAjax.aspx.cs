using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAMAMENYA.Attributes;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;
using MAMAMENYA.Data;
using MAMAMENYA.FormWeb.UI;

namespace MAMAMENYA.FormWeb.AjaxHandler
{
    public partial class BalaAjax : PageBase
    {
        readonly IArticleRepository _articleRepository = new ArticleRepository();
        readonly IArticleClassRepository _articleClassRepository = new ArticleClassRepository();
        readonly IProductRepository _productRepository = new ProductRepository();
        readonly ICommentRepository _commentRepository = new CommentRepository();
        readonly IProductClassRepository _productClassRepository = new ProductClassRepository();
        readonly IBrandRepository _brandRepository=new BrandRepository();

        protected void Page_Load(object sender, EventArgs e)
        {

            var args = Request.QueryString["action"];
            if (args == "DelProduct")
            {
                DelProduct();
            }
            if (args == "DelArtile")
            {
                DelArticle();
            }
            if (args == "DelComment")
            {
                DelComment();
            }
            if (args == "AuditComment")
            {
                AuditComment();
            }
            if (args == "DelProductClass")
            {
                DelProductClass();
            }
            if (args == "DelArticleClass")
            {
                DelArticleClass();
            }
            if (args == "ChangeProductStatus")
            {
                ChangeProductStatus();
            }
            if (args == "DelBrand")
            {
                DelBrand();
            }
        }


        /// <summary>
        /// 删除文章分类
        /// </summary>
        private void DelArticleClass()
        {
            try
            {
                var id = int.Parse(Request.QueryString["ObjectId"]);
                _articleClassRepository.Delete(id);
                Response.Write("删除成功！");
            }
            catch (Exception err)
            {
                Response.Write(err.Message);
            }
        }

        /// <summary>
        /// 删除产品分类
        /// </summary>
        private void DelProductClass()
        {
            try
            {
                var id = int.Parse(Request.QueryString["ObjectId"]);
                _productClassRepository.Delete(id);
                Response.Write("删除成功！");
            }
            catch (Exception err)
            {
                Response.Write(err.Message);
            }

        }

        /// <summary>
        /// 删除品牌信息
        /// </summary>
        private void DelBrand()
        {
            try
            {
                var id = int.Parse(Request.QueryString["ObjectId"]);
                {
                    _brandRepository.Delete(id);
                    Response.Write("品牌删除成功！");
                }
            }
            catch (Exception err)
            {
                Response.Write(err.Message);
            }
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        private void DelArticle()
        {
            try
            {
                var id = int.Parse(Request.QueryString["ObjectId"]);
                {
                    _articleRepository.Delete(id);
                    Response.Write("文章删除成功！");
                }
            }
            catch (Exception err)
            {
                Response.Write(err.Message);
            }
        }

        /// <summary>
        /// 修改产品上架下架状态
        /// </summary>
        private void ChangeProductStatus()
        {
            try
            {
                var id = int.Parse(Request.QueryString["ObjectId"]);
                var item = _productRepository.Get(id);
                item.Status = item.Status == ProductStatus.上架 ? ProductStatus.下架 : ProductStatus.上架;

                _productRepository.SaveOrUpdate(item);
                Response.Write("产品修改成功！");
            }
            catch (Exception err)
            {
                Response.Write(err.Message);
            }
        }


        /// <summary>
        /// 删除产品
        /// </summary>
        private void DelProduct()
        {
            try
            {
                var id = int.Parse(Request.QueryString["ObjectId"]);
                _productRepository.Delete(id);

                Response.Write("删除成功！");
            }
            catch (Exception err)
            {

                Response.Write(err.Message);
            }

        }

        private void DelComment()
        {
            try
            {
                int id = int.Parse(Request.QueryString["ObjectId"]);
                _commentRepository.Delete(id);
                Response.Write("删除成功！");
            }
            catch (Exception err)
            {
                Response.Write(err.Message);
            }
        }


        private void AuditComment()
        {
            try
            {
                int id = int.Parse(Request.QueryString["ObjectId"]);
                var item = _commentRepository.Get(id);
                if (Request.QueryString["Status"] == "0")
                {
                    item.AuditStatus = AuditStatus.审核未通过;
                }
                else
                {
                    item.AuditStatus = AuditStatus.审核通过;
                }
                _commentRepository.SaveOrUpdate(item);
                Response.Write("操作成功！");
            }
            catch (Exception err)
            {
                Response.Write(err.Message);
            }
        }

    }
}