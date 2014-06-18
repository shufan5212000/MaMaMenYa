using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Article : EntityBase
    {
        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Title { get; set; }


        public virtual ArticleFrom ArticleFrom { get; set; }

        /// <summary>
        /// 文章类别
        /// </summary>
        public virtual ArticleClass ArticleClass { get; set; }

        /// <summary>
        /// 页面关键词
        /// </summary>
        public virtual string Keyword { get; set; }

        /// <summary>
        /// 页面描述
        /// </summary>
        public virtual string Description { get; set; }


        /// <summary>
        /// 内容
        /// </summary>
        [FieldLength(4001)]
        public virtual string Content { get; set; }

        /// <summary>
        /// 浏览量
        /// </summary>
        public virtual int ClickCount { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual DateTime UpdateTime { get; set; }

        /// <summary>
        /// 文章图片链接
        /// </summary>
        public virtual string PicUrl { get; set; }

        /// <summary>
        /// 置顶
        /// </summary>
        public virtual bool IsTop { get; set; }

        /// <summary>
        /// 推荐
        /// </summary>
        public virtual bool IsNice { get; set; }
    }
}
