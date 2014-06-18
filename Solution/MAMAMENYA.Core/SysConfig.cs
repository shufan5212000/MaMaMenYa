using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    public class SysConfig 
    {
        /// <summary>
        /// 网站名称
        /// </summary>
        public virtual string WebSiteName { get; set; }

        /// <summary>
        /// 关键词
        /// </summary>
        public virtual string Keyword { get; set; }

        /// <summary>
        /// 网站描述
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// 域名
        /// </summary>
        public virtual string DomainName { get; set; }


        /// <summary>
        /// 备案信息
        /// </summary>
        public virtual string IcpNo { get; set; }

        /// <summary>
        /// 二维码图片
        /// </summary>
        public virtual string QrCodeUrl { get; set; }

        /// <summary>
        /// 在线QQ
        /// </summary>
        public virtual string Qq { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// 微信公众号
        /// </summary>
        public virtual string WeiXin { get; set; }

        /// <summary>
        /// 微博地址
        /// </summary>
        public virtual string WebBoUrl { get; set; }

        /// <summary>
        /// 旺旺号
        /// </summary>
        public virtual string WangWang { get; set; }
    }
}
