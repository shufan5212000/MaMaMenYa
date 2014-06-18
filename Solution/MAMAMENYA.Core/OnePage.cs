using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    public class OnePage : EntityBase
    {
        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Keyword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// 父类
        /// </summary>
        public virtual OnePage Parent { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [FieldLength(4001)]
        public virtual string Content { get; set; }


        public virtual DateTime UpdateTime { get; set; }
    }
}
