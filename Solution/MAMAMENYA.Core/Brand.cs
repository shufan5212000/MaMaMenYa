using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 品牌
    /// </summary>
    public class Brand:EntityBase
    {
        /// <summary>
        /// 品牌名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 品牌描述
        /// </summary>
        [FieldLength(4001)]
        public virtual string Description { get; set; }

        /// <summary>
        /// 相关图片
        /// </summary>
        public virtual string PicUrl { get; set; }

        /// <summary>
        /// 产品数量
        /// </summary>
        public virtual int ProductCount { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual DateTime UpdateTime { get; set; }
    }
}
