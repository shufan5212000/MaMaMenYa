using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 订单
    /// </summary>
    public class BuyOrder : EntityBase
    {
        /// <summary>
        /// 用户
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        //public virtual Product Product { get; set; }

        /// <summary>
        /// 产品数量
        /// </summary>
        public virtual int ProductCount { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public virtual decimal TotleMoney { get; set; }

        /// <summary>
        /// 邮寄地址
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public virtual string PostCode { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public virtual string Tel { get; set; }


        /// <summary>
        /// 收件人
        /// </summary>
        public virtual string Consignee { get; set; }

        /// <summary>
        /// 发货状态
        /// </summary>
        public virtual DeliveryStatus DeliveryStatus { get; set; }

        /// <summary>
        /// 付款状态
        /// </summary>
        public virtual PayStatus PayStatus { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public virtual PayType PayType { get; set; }

        /// <summary>
        /// 订单提交时间
        /// </summary>
        public virtual DateTime SubmitTime { get; set; }



    }
}
