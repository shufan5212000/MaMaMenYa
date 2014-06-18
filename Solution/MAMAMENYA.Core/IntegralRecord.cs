using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 用户积分变动记录
    /// </summary>
    public class IntegralRecord : EntityBase
    {
        /// <summary>
        /// 用户
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// 变动数量
        /// </summary>
        public virtual int Count { get; set; }

        /// <summary>
        /// 变动之前
        /// </summary>
        public virtual int BeforeChange { get; set; }

        /// <summary>
        /// 变动之后
        /// </summary>
        [NotMap]
        public virtual int AfterChange { get { return BeforeChange - Count; } }

        /// <summary>
        /// 变动类型
        /// </summary>
        public virtual IntegralType Type { get; set; }

        /// <summary>
        /// 积分兑换产品的ID
        /// </summary>
        public virtual int ProductId { get; set; }

        /// <summary>
        /// 变动时间
        /// </summary>
        public virtual DateTime ChangeTime { get; set; }
    }
}
