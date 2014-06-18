using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 产品分类
    /// </summary>
    public class ProductClass : EntityBase
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 分类编码
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// 上级分类
        /// </summary>
        public virtual ProductClass Parent { get; set; }


        /// <summary>
        /// 分类的图标
        /// </summary>
        public virtual string ClassPic { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public virtual DateTime AddTime { get; set; }

        /// <summary>
        /// 该分类下的产品数量
        /// </summary>
        public virtual int ProductCount { get; set; }
    }
}
