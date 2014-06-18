using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

using MvcContrib.ActionResults;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NHibernate.Proxy;
using SharpArch.Web.JsonNet;

namespace MAMAMENYA.Controller
{
    public class ControllerBase : System.Web.Mvc.Controller
    {
        protected log4net.ILog Log = log4net.LogManager.GetLogger("MAMAMENYA.Controller");


        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            if (filterContext.ExceptionHandled)
            {
                return;
            }
            Log.ErrorFormat("{0}\n\t{1}\n\t{2}", filterContext.Exception.Message, filterContext.Exception.StackTrace, filterContext.Exception.Source);
            if (filterContext.HttpContext.Request.IsJson())
            {
                filterContext.HttpContext.Response.Clear();
                var content = filterContext.Exception.ToString();
                ActionResult result = null;
                if (content.Contains("DELETE ") && content.Contains(" REFERENCE "))
                {
                    result = JsonError("不能删除已经被使用的数据");
                }
                else
                {
                    result = JsonError(filterContext.Exception.ToString());
                }
                filterContext.Result = result;
                filterContext.ExceptionHandled = true;
            }


        }
        //protected override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    base.OnActionExecuted(filterContext);
        //}

        protected virtual ActionResult View<T>(T model)
        {
            if (Request.IsJson())
            {
                return JsonNet(model);
            }
            return base.View(model);
        }

        #region  Result


        protected XmlResult XmlSuccess<T>(T obj)
        {
            return Xml(new XmlSuccess<T>(true, obj));
        }
        protected XmlResult XmlError(string error)
        {
            return Xml(false, error);
        }
        protected XmlResult XmlError<T>(string error)
        {
            return Xml(new XmlSuccess<T>(error));
        }

        protected XmlResult Xml<T>(bool result, T obj)
        {
            return Xml(new XmlSuccess<T>(result, obj));

        }

        protected XmlResult Xml<T>(T obj)
        {
            XmlResult result = new XmlResult(obj);
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetExpires(DateTime.Now.)
            return result;
        }
        protected ActionResult TextResult(string text)
        {
            return Content(text, "text/plain");
        }

        protected ActionResult JsonNet<T>(T obj)
        {
            var result = new JsonNetResult(obj);

            result.Formatting = Formatting.None;
            result.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            result.SerializerSettings.ContractResolver = new NHibernateContractResolver();

            result.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
            return result;


        }


        public ActionResult JsonString<T>(T data)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = data;
            result.ContentType = "text/plain";
            return result;
        }


        public ActionResult JsonNetSuccess<T>(T data)
        {
            return JsonNet(new { success = true, data = data });
        }
        public ActionResult JsonNetnError(string error)
        {
            return JsonNet(new { success = false, data = error });
        }

        protected JsonResult JsonSuccess<T>(T data)
        {

            return Json(new { success = true, data = data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult JsonSuccess()
        {
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        protected JsonResult JsonError(string error)
        {
            return Json(new { success = false, data = error }, JsonRequestBehavior.AllowGet);
        }
        protected ActionResult Empty()
        {
            return new EmptyResult();
        }
        #endregion
    }
    public class XmlSuccess<T>
    {
        public XmlSuccess()
        {

        }
        public XmlSuccess(bool success, T value)
        {
            this.Success = success;

            this.Value = value;

        }

        public XmlSuccess(string errorMessage)
        {
            this.Success = false;

            Message = errorMessage;


        }
        public bool Success { get; set; }
        public T Value { get; set; }
        public string Message { get; set; }

    }
    public class NHibernateContractResolver : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            if (typeof(INHibernateProxy).IsAssignableFrom(objectType))
            {
                return base.GetSerializableMembers(objectType.BaseType);
            }
            else
            {
                return base.GetSerializableMembers(objectType);
            }
        }
    }

}