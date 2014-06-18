using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MAMAMENYA.Controller;
using MvcContrib.ActionResults;

namespace MAMAMENYA.Attributes
{
    /// <summary>
    /// 处理了Json出错时返回Json格式的错误信息
    /// </summary>
    public class TransactionAttribute : SharpArch.Web.NHibernate.TransactionAttribute
    {

        public TransactionAttribute()
        {


        }
        public TransactionAttribute(string factorykey)
            : base(factorykey)
        {


        }

        

        // public bool ExceptionHandled { get; set; }
        //public override void OnResultExecuted(ResultExecutedContext filterContext)
        //{
        //    try
        //    {
        //        base.OnResultExecuted(filterContext);
        //    }
        //    catch (Exception ex)
        //    {

        //        filterContext.Exception = ex;
        //    }

        //    if (filterContext.Exception != null && !filterContext.ExceptionHandled)
        //    {
        //        if (filterContext.HttpContext.Request.IsAjaxRequest())
        //        {
        //            filterContext.Result = new JsonResult() { Data = new { success = false, data = filterContext.Exception.Message } };
        //            filterContext.ExceptionHandled = true;
        //        }
        //        else if (filterContext.HttpContext.Request.IsXmlRequest())
        //        {
        //            filterContext.Result = new XmlResult(new XmlSuccess<string>(false, filterContext.Exception.Message));
        //            filterContext.ExceptionHandled = true;
        //        }

        //    }
        //}
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {


            bool IsHandledException = false;
            //是ViewResult的话检测model是否是IExceptionModel,如果是IExceptionModel则代表他自己处理异常
            var result = filterContext.Result as ViewResultBase;
            if (result != null)
            {
                var exModel = result.ViewData.Model as IExceptionModel;
                if (exModel != null)
                {
                    filterContext.Exception = exModel.Exception;
                    filterContext.ExceptionHandled = true;
                    IsHandledException = true;
                }
            }
            base.OnActionExecuted(filterContext);
            if (IsHandledException || filterContext.Exception == null) return;
            if (filterContext.HttpContext.Request.IsJson())
            {
                filterContext.Result = new JsonResult() { Data = new { success = false, data = filterContext.Exception.Message } };
                filterContext.ExceptionHandled = true;
            }
            else if (filterContext.HttpContext.Request.IsXmlRequest())
            {
                filterContext.Result = new XmlResult(new XmlSuccess<string>(false, filterContext.Exception.Message));
                filterContext.ExceptionHandled = true;
            }
        }
    }
}
