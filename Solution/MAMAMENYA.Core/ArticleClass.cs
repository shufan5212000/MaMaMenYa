using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 文章分类
    /// </summary>
    public class ArticleClass : EntityBase
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 上级分类
        /// </summary>
        public virtual ArticleClass Parent { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// 页面关键词
        /// </summary>
        public virtual string Keyword { get; set; }

        /// <summary>
        /// 页面描述
        /// </summary>
        public virtual string Description { get; set; }

      

        /// <summary>
        /// 添加时间
        /// </summary>
        public virtual DateTime AddTime { get; set; }

        
    }
}
