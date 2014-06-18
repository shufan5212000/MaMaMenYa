using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    public class Tag : EntityBase
    {
        public virtual string Name { get; set; }


        public virtual string Remark { get; set; }
    }
}
