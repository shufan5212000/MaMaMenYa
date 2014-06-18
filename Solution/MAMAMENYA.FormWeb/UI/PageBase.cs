using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;
using MAMAMENYA.Data;

namespace MAMAMENYA.FormWeb.UI
{
    public class PageBase : System.Web.UI.Page
    {
        protected IBaLaBaLaRepository BaLaBaLaRepository = new BaLaBaLaRepository();
        /// <summary>
        /// 当前管理员
        /// </summary>
        public BaLaBaLa CurrentUser
        {
            get
            {
                return Request.Cookies["BaLaBaLa"] != null ? BaLaBaLaRepository.GetByLoginName(Request.Cookies["BaLaBaLa"].Value) : null;
            }

        }

        protected override void OnLoad(EventArgs e)
        {
            CheckAdminLogin();

            base.OnLoad(e);
        }

        /// <summary>
        /// 获取页面异常，弹出提示窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (HttpContext.Current.Server.GetLastError() is HttpRequestValidationException)
            {

                string msgbox = "parent.jsdialog(\"错误提示\", \"" + ex.Message + "\", \"back\", \"Error\")";
                Response.Write("<script type=\"text/javascript\">" + msgbox + "</script>");
                Response.End();
                HttpContext.Current.Server.ClearError();
            }
        }

        /// <summary>
        /// JS的提示窗口
        /// </summary>
        /// <param name="msg"></param>
        protected void JsMsgBox(string msg, AlertType type)
        {
            var jsType = string.Empty;
            if (type == AlertType.成功)
            {
                jsType = "'success'";
            }
            if (type == AlertType.异常)
            {
                jsType = "'danger'";
            }
            if (type == AlertType.失败)
            {
                jsType = "'warning'";
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "$('body').alert({ type: " + jsType + "," + msg + " })", true);
        }


        private void CheckAdminLogin()
        {
            if (CurrentUser == null)
            {
                Response.Redirect("/BaLaBaLa/Login.aspx");
            }
        }


        public string UploadPic(HttpPostedFile postedFile)
        {
            var fileName = postedFile.FileName;
            var extension = System.IO.Path.GetExtension(fileName);
            var filePath = string.Format("{0}{1}{2}{3}{4}{5}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                            DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            string fileOnServer = string.Format("/UploadFile/{0}{1}", filePath, extension);
            filePath = string.Format("{0}{1}{2}", Server.MapPath("/UploadFile/"), filePath, extension);
            postedFile.SaveAs(filePath);


            return fileOnServer;
        }


        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="strValue">过期时间(分钟)</param>
        public void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = UrlEncode(strValue);
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }


        /// <summary>
        /// URL字符编码
        /// </summary>
        public string UrlEncode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            str = str.Replace("'", "");
            return HttpContext.Current.Server.UrlEncode(str);
        }

        /// <summary>
        /// URL字符解码
        /// </summary>
        public string UrlDecode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            return HttpContext.Current.Server.UrlDecode(str);
        }
    }
}