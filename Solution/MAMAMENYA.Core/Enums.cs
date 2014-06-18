using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 平台
    /// </summary>
    public enum Plantform
    {
        淘宝,
        京东,
        一号店,
        易迅,
        拍拍,
        苏宁易购,
        妈妈们丫
    }

    /// <summary>
    /// 商家的信用级别
    /// </summary>
    public enum CreditRating
    {
        一星,
        二星,
        三星,
        四星,
        五星,
        钻石
    }

    /// <summary>
    /// 发件状态
    /// </summary>
    public enum DeliveryStatus
    {
        未发货,
        已发货
    }

    /// <summary>
    /// 支付方式
    /// </summary>
    public enum PayType
    {
        支付宝,
        财付通,
        微信支付,
        银联在线支付
    }

    /// <summary>
    /// 支付状态
    /// </summary>
    public enum PayStatus
    {
        未支付,
        已支付
    }

    /// <summary>
    /// 评论类型
    /// </summary>
    public enum CommentType
    {
        产品评论,
        商家评论,
        文章评论

    }


    public enum CommonCodeType
    {
        省份城市,
        招募类型,
        文章类别,
        行业类别,
        职业类别
    }


    public enum Gender
    {
        妈妈,
        爸爸
    }

    /// <summary>
    /// 文章来源
    /// </summary>
    public enum ArticleFrom
    {
        原创,
        转载,
        未知
    }


    public enum ProductStatus
    {
        上架,
        下架
    }

    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserStatus
    {
        正常,
        禁用

    }

    /// <summary>
    /// 审核状态
    /// </summary>
    public enum AuditStatus
    {
        未审核,
        审核通过,
        审核未通过
    }

    public enum MsgType
    {
        系统通知,
        私信
    }


    public enum ReadStatus
    {
        未读,
        已读
    }

    public enum AlertType
    {
        成功,
        失败,
        异常
    }

    public enum Recommend
    {
        普通 = 1,
        推荐 = 2
    }


    public enum QuestionStatus
    {
        待解决,
        已解决
    }

    public enum IntegralType
    {
        登录,
        签到,
        回答问题,
        回答被采纳,
        悬赏问题,
        积分兑换产品
    }
}
