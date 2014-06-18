using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 收藏的
    /// </summary>
    public class Favorite : EntityBase
    {
        public virtual User User { get; set; }


        public virtual DateTime AddTime { get; set; }


        //public virtual Product Product { get; set; }


    }
}
