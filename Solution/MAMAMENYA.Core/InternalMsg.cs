using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 站内信
    /// </summary>
    public class InternalMsg:EntityBase
    {
        /// <summary>
        /// 站内信类型
        /// </summary>
        public virtual MsgType MsgType { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 谁发的：昵称
        /// </summary>
        public virtual string FromName { get; set; }

        /// <summary>
        /// 谁发的：用户
        /// </summary>
        public virtual User FromUser { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [FieldLength(4001)]
        public virtual string Content { get; set; }

        /// <summary>
        /// 谁收
        /// </summary>
        public virtual User ToUser { get; set; }

        /// <summary>
        /// 阅读状态
        /// </summary>
        public virtual ReadStatus ReadStatus { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        public virtual DateTime SendTime { get; set; }


    }
}
