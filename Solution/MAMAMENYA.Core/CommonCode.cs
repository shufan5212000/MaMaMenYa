
using System;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 公共编码
    /// </summary>
    public class CommonCode : EntityBase
    {
        /// <summary>
        /// 编码类型
        /// </summary>
        public virtual CommonCodeType CommonCodeType { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string CodeName { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public virtual string CodeCode { get; set; }

        /// <summary>
        /// 上级编码
        /// </summary>
        public virtual CommonCode Parent { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public virtual DateTime AddTime { get; set; }
    }
}
