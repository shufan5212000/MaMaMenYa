using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    public class Product : EntityBase
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public virtual string ProductName { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public virtual string ProductNo { get; set; }

        /// <summary>
        /// 产品类别
        /// </summary>
        public virtual ProductClass ProductClass { get; set; }

        /// <summary>
        /// 所属品牌
        /// </summary>
        public virtual Brand ProductBrand { get; set; }

        /// <summary>
        /// 产品页面关键词
        /// </summary>
        public virtual string ProductKeyword { get; set; }

        /// <summary>
        /// 产品简介
        /// </summary>
        [FieldLength(4001)]
        public virtual string Summary { get; set; }

        /// <summary>
        /// 产品链接,针对第三方平台的产品
        /// </summary>
        public virtual string ProductUrl { get; set; }

        /// <summary>
        /// 产品内容
        /// </summary>
        [FieldLength(4001)]
        public virtual string Content { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public virtual string Pic { get; set; }


        /// <summary>
        /// 价格
        /// </summary>
        public virtual decimal Price { get; set; }

        /// <summary>
        /// 运费
        /// </summary>
        public virtual decimal Freight { get; set; }


        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual DateTime UpdateTime { get; set; }

        /// <summary>
        /// 浏览数量
        /// </summary>
        public virtual int ClickCount { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public virtual int BuyCount { get; set; }

        /// <summary>
        ///  库存数量
        /// </summary>
        public virtual int Inventory { get; set; }

        /// <summary>
        /// 好评数
        /// </summary>
        public virtual int FavorableCount { get; set; }


        /// <summary>
        /// 所在平台
        /// </summary>
        public virtual Plantform PlantformName { get; set; }

        /// <summary>
        /// 商家名称
        /// </summary>
        public virtual string ShopName { get; set; }

        /// <summary>
        /// 商家信用等级
        /// 在自动生成数据库脚本时，枚举类型不能为空类型，必须有枚举内容
        /// </summary>
        public virtual CreditRating CreditRating { get; set; }
       
        /// <summary>
        /// 推荐
        /// </summary>
        public virtual bool Recommend { get; set; }

        /// <summary>
        /// 推荐天数，从上架开始算起
        /// </summary>
        public virtual int RecommendDays { get; set; }

        /// <summary>
        /// 产品状态
        /// </summary>
        public virtual ProductStatus Status { get; set; }

        /// <summary>
        /// 综合评分
        /// </summary>
        public virtual double CompositeScore { get; set; }

        /// <summary>
        /// 评分次数
        /// </summary>
        public virtual int ScoredCount { get; set; }

        /// <summary>
        /// 运费
        /// </summary>
        public virtual decimal DeliveryFee { get; set; }

        /// <summary>
        /// 发货地址
        /// </summary>
        public virtual string ShippingFrom { get; set; }
    }
}
