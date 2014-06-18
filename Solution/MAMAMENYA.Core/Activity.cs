using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 活动
    /// </summary>
    public class Activity : EntityBase
    {
        /// <summary>
        /// 活动标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 页面关键词
        /// </summary>
        public virtual string Keyword { get; set; }


        /// <summary>
        /// 页面描述
        /// </summary>
        public virtual string Descrp { get; set; }
        
        
        /// <summary>
        /// 图片
        /// </summary>
        public virtual string PicUrl { get; set; }

        /// <summary>
        /// 活动详情
        /// </summary>
        [FieldLength(4001)]
        public virtual string Content { get; set; }


        /// <summary>
        /// 活动时间
        /// </summary>
        public virtual string StartDate { get; set; }


        /// <summary>
        /// 添加发布时间
        /// </summary>
        public virtual DateTime AddTime { get; set; }

        /// <summary>
        /// 报名开始时间
        /// </summary>
        public virtual DateTime SignInStartTime { get; set; }

        /// <summary>
        /// 报名截止时间
        /// </summary>
        public virtual DateTime SignInEndTime { get; set; }


        /// <summary>
        /// 总数
        /// </summary>
        public virtual int TotleUser { get; set; }

        /// <summary>
        /// 当前人数
        /// </summary>
        public virtual int CurrentCount { get; set; }

        /// <summary>
        /// 点击量
        /// </summary>
        public virtual int ClickRate { get; set; }

        /// <summary>
        /// 报名费用
        /// </summary>
        public virtual decimal Price { get; set; }

        /// <summary>
        /// 报名电话
        /// </summary>
        public virtual string Tel { get; set; }

        /// <summary>
        /// 报名地址
        /// </summary>
        public virtual string Address { get; set; }


        /// <summary>
        /// 是否推荐
        /// </summary>
        public virtual Recommend Recommend { get; set; }
    }
}
