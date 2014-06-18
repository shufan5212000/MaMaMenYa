using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public class SysLog:EntityBase
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [FieldLength(4001)]
        public virtual string Content { get; set; }


        /// <summary>
        /// 添加时间
        /// </summary>
        public virtual DateTime AddTime { get; set; }
    }
}
