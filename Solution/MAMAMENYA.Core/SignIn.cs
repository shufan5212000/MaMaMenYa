using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 签到
    /// </summary>
    public class SignIn : EntityBase
    {
        /// <summary>
        /// 签到时间
        /// </summary>
        public virtual DateTime SignInTime { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public virtual string SignRemark { get; set; }


        /// <summary>
        /// 日期
        /// </summary>
        [NotMap]
        public virtual string SignInDate
        {
            get { return SignInTime.Date.ToShortDateString(); }
        }
    }
}
