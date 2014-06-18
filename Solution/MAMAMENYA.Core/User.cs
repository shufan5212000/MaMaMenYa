using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    public class User : EntityBase
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public virtual string LoginName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Guid MembershipId { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public virtual string Tel { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// 宝宝年龄
        /// </summary>
        public virtual int BabyAge { get; set; }

        /// <summary>
        /// 邮箱是否验证
        /// </summary>
        public virtual bool EmailAuthenticate { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public virtual string NickName { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        public virtual string HeadUrl { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public virtual int Integral { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// 地区属性
        /// </summary>
        public virtual Area Area { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public virtual DateTime RegData { get; set; }

        /// <summary>
        /// 绑定的淘宝账户
        /// </summary>
        public virtual string TaoBaoAccount { get; set; }


        /// <summary>
        /// 绑定的腾讯微博账户
        /// </summary>
        public virtual string TencentAccount { get; set; }

        /// <summary>
        /// 绑定的新浪微博账户
        /// </summary>
        public virtual string SinaAccount { get; set; }

        /// <summary>
        /// 校内账号
        /// </summary>
        public virtual string XiaoNeiAccount { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public virtual UserStatus Status { get; set; }
    }
}
