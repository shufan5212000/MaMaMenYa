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

namespace MAMAMENYA.FormWeb.Balabala
{
    public partial class MaMaBaLaConfig : PageBase
    {
        readonly ISettingRepository _settingRepository = new SettingRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var item = _settingRepository.Get<SysConfig>();
                txtWebName.Text = item.WebSiteName;
                txtKeywords.Text = item.Keyword;
                txtDesc.Text = item.Description;
                txtEmail.Text = item.Email;
                txtErWeiMa.Text = item.QrCodeUrl;
                txtDomain.Text = item.DomainName;
                txtICP.Text = item.IcpNo;
                txtWangWang.Text = item.WangWang;
                txtWeiXin.Text = item.WeiXin;
                txtQq.Text = item.Qq;
                txtWebBo.Text = item.WebBoUrl;
            }
        }

        protected void OnbtnSave_Click(object sender, EventArgs e)
        {
            var item = _settingRepository.Get<SysConfig>();

            item.WebSiteName = txtWebName.Text;
            item.Keyword = txtKeywords.Text;
            item.Description = txtDesc.Text;
            item.Email = txtEmail.Text;
            item.QrCodeUrl = txtErWeiMa.Text;
            item.DomainName = txtDomain.Text;
            item.IcpNo = txtICP.Text;
            item.WangWang = txtWangWang.Text;
            item.WeiXin = txtWeiXin.Text;
            item.Qq = txtQq.Text;
            item.WebBoUrl = txtWebBo.Text;

            _settingRepository.Save(item);
        }
    }
}