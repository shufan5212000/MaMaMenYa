using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAMAMENYA.FormWeb.AjaxHandler
{
    public partial class Attachment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var fileid = Request["fileid"] as string;

            HttpPostedFile fileUploadPic = Request.Files[fileid];
            
            var fileName = fileUploadPic.FileName;
            var extension = System.IO.Path.GetExtension(fileName);
            var filePath = string.Format("{0}{1}{2}{3}{4}{5}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                            DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            var fileOnServer = string.Format("/UploadFile/{0}{1}", filePath, extension);
            filePath = string.Format("{0}{1}{2}", Server.MapPath("/UploadFile/"), filePath, extension);
            fileUploadPic.SaveAs(filePath);
            Response.Write(fileOnServer);
        }
    }
}