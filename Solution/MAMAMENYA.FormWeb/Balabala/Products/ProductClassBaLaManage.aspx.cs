using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;
using MAMAMENYA.Data;

namespace MAMAMENYA.FormWeb.Balabala.Products
{
    public partial class ProductClassBaLaManage : System.Web.UI.Page
    {
        public IList<ProductClass> PageData = new List<ProductClass>();
      

        private const int PageSize = 15;
        public int PageIndex, PageCount;
        private readonly IProductClassRepository _productClassRepository = new ProductClassRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindData(1);
            if (!IsPostBack)
            {
                GetClassTree();
            }
        }


        private void BindData(int pageIndex)
        {
            var query = new UserQuery()
            {
                PageIndex = pageIndex,
                PageSize = PageSize
            };
            var data = _productClassRepository.GetList(query);

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
            var fileOnServer = string.Empty;
            if (fileUploadPic.PostedFile != null)
            {
                var fileName = fileUploadPic.PostedFile.FileName;
                var extension = System.IO.Path.GetExtension(fileName);
                var filePath = string.Format("{0}{1}{2}{3}{4}{5}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                fileOnServer = string.Format("/UploadFile/{0}{1}", filePath, extension);
                filePath = string.Format("{0}{1}{2}", Server.MapPath("/UploadFile/"), filePath, extension);
                fileUploadPic.PostedFile.SaveAs(filePath);

            }

            var item = new ProductClass()
                {
                    AddTime = DateTime.Now,
                    ClassPic = fileOnServer,
                    Name = txtClassName.Text.Trim(),
                    Code = txtClassCode.Text.Trim(),
                    ProductCount = 0,
                    Remark = txtRemark.Text.Trim()
                };
            if (drpClassPageData.SelectedItem != null)
            {
                item.Parent = _productClassRepository.Get(int.Parse(drpClassPageData.SelectedValue));
            }
           
            _productClassRepository.SaveOrUpdate(item);
            Response.Redirect("ProductClassBaLaManage.aspx");
        }


        private void GetClassTree()
        {
            var allClass = _productClassRepository.GetAll();
            var parentCLass = allClass.Where(c => c.Parent == null);
            IList<ProductClassModel> classPageData = parentCLass.Select(productClass => new ProductClassModel()
                {
                    Name = productClass.Name,
                    ClassId = productClass.Id
                }).ToList();
            classPageData.Add(new ProductClassModel(){ClassId = 0,Name = "--------请选择--------"});

            foreach (var productClass in allClass)
            {
                if (productClass.Parent == null)
                {
                    continue;
                }
                var parentCurrent = classPageData.First(c => c.ClassId == productClass.Parent.Id);
                int location = classPageData.IndexOf(parentCurrent);
                classPageData.Insert(location + 1, new ProductClassModel()
                    {
                        Name = "﹂" + productClass.Name,
                        ClassId = productClass.Id
                    });
            }

            drpClassPageData.DataSource = classPageData;
            drpClassPageData.DataTextField = "Name";
            drpClassPageData.DataValueField = "ClassId";
            drpClassPageData.DataBind();
        }
    }



}