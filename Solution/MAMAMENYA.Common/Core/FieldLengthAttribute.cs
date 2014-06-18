using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    public class FieldLengthAttribute:Attribute
    {
        public FieldLengthAttribute(int length)
        {
            this.Length = length;
        }
        public int Length{get;set;}
    }
}
