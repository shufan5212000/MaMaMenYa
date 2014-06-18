using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 广告和友情链接
    /// </summary>
    public class Advertisement : EntityBase
    {
        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 广告类别
        /// </summary>
        public virtual AdsClass AdsClass { get; set; }

        /// <summary>
        /// 广告描述
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public virtual string PicUrl { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public virtual string Link { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public virtual DateTime AddTime { get; set; }

        /// <summary>
        /// 点击
        /// </summary>
        public virtual int ClickCount { get; set; }
    }

    /// <summary>
    /// 广告类别
    /// </summary>
    public class AdsClass : EntityBase
    {
        public virtual string Name { get; set; }
    }
}
