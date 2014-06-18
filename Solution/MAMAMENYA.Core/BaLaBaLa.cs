using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class BaLaBaLa : EntityBase
    {
        public virtual string LoginName { get; set; }


        public virtual string Pwd { get; set; }


        public virtual string RealName { get; set; }


        public virtual DateTime AddTime { get; set; }


        public virtual int LoginCount { get; set; }
    }
}
