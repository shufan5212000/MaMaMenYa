using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 评论
    /// </summary>
    public class Comment : EntityBase
    {
        /// <summary>
        /// 用户
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// 评论对象的ID
        /// </summary>
        public virtual int ItemId { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        [FieldLength(4001)]
        public virtual string Content { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public virtual DateTime AddTime { get; set; }

        /// <summary>
        /// 评论类型
        /// </summary>
        public virtual CommentType CommentType { get; set; }


        /// <summary>
        /// 审核状态
        /// </summary>
        public virtual AuditStatus AuditStatus { get; set; }
    }
}
