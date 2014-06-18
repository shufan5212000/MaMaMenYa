using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 地域
    /// </summary>
    public class Area : EntityBase
    {
        public virtual string Name { get; set; }

        public virtual Area Parent { get; set; }
    }
}
