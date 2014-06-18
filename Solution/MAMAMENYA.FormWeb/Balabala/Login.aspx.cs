using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAMAMENYA.Common;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;
using MAMAMENYA.Data;
using MAMAMENYA.FormWeb.UI;

namespace MAMAMENYA.FormWeb.Baba
{
    public partial class Login : Page
    {
        IBaLaBaLaRepository _adminRepository = new BaLaBaLaRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnBtnLogin_Click(object sender, EventArgs e)
        {
            var validcode = txtcode.Text.Trim().ToUpper();
            if (Request.Cookies["verifyCode"] == null)
            {
                return;
            }
            var msg = string.Empty;
            if (String.CompareOrdinal(Request.Cookies["verifyCode"].Value, validcode) == 0)
            {

                var item = _adminRepository.GetByLoginName(txtLoginName.Text.Trim());
                if (item != null && item.Pwd == Security.GetMD5_32(txtPwd.Text.Trim()))
                {
                    item.LoginCount += 1;
                    _adminRepository.SaveOrUpdate(item);
                    //设置cookie
                    var baLa = new HttpCookie("BaLaBaLa", item.LoginName);
                    baLa.Expires = DateTime.Now.AddMinutes(30);
                    Response.AppendCookie(baLa);
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    msg = "用户名或密码错误！";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "$(document).ready(function () { $(\"#success-block\").hide();$(\"#warning-block\").show();$(\"#msg\").text('" + msg + "')});", true);
                    //JsMsgBox("用户名或密码错误！", AlertType.失败);
                }
            }
            else
            {
                msg = " 验证码错误";
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "$(document).ready(function () { $(\"#success-block\").hide();$(\"#warning-block\").show();$(\"#msg\").text('" + msg + "')});", true);

                //JsMsgBox("验证码错误！", AlertType.失败);
            }
        }
    }
}