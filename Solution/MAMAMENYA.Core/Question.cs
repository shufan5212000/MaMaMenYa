using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    public class Question : EntityBase
    {
        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Title { get; set; }


        /// <summary>
        /// 所属分类
        /// </summary>
        public virtual QuestionClass QuestionClass { get; set; }

        /// <summary>
        /// 状态，已解决还是未解决
        /// </summary>
        public virtual QuestionStatus Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual User User { get; set; }



        [FieldLength(4001)]
        public virtual string Content { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public virtual DateTime AddTime { get; set; }

        /// <summary>
        /// 悬赏积分
        /// </summary>
        public virtual int Integration { get; set; }


        /// <summary>
        /// 精华
        /// </summary>
        public virtual bool IsNice { get; set; }

        /// <summary>
        /// 是否为悬赏
        /// </summary>
        public virtual bool IsReward { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public virtual AuditStatus AuditStatus { get; set; }

    }

    /// <summary>
    /// 问题分类
    /// </summary>
    public class QuestionClass : EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Descript { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string PicUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual QuestionClass Parent { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Answer : EntityBase
    {
        /// <summary>
        /// 问题的ID
        /// </summary>
        public virtual int QuestionId { get; set; }

        /// <summary>
        /// 回答用户
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public virtual string IpAddress { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public virtual string NickName { get; set; }

        /// <summary>
        /// 回答时间
        /// </summary>
        public virtual DateTime AddTime { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [FieldLength(4001)]
        public virtual string Content { get; set; }

        /// <summary>
        /// 是否被才难
        /// </summary>
        public virtual bool IsBest { get; set; }
    
    }
}
