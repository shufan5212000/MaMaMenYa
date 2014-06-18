using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    public class NotMapAttribute : Attribute
    {
        public NotMapAttribute()
        { }
        public bool IsMap { get; set; }
    }
}
