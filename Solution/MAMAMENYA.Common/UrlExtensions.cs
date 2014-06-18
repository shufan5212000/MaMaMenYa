using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace MAMAMENYA
{
    public static class UrlExtensions
    {
        private const string linkTemplate = "{0}{1}{2}{3}";

        public static string ActionLinkForAreas<TController>(this UrlHelper helper,
  Expression<Action<TController>> action) where TController : System.Web.Mvc.Controller
        {
            Type controllerType = typeof(TController);
            string controllerUrlName = LinkAreasExtensions.GetUrlNameEquivalentOf(controllerType);
            string areaUrl = LinkAreasExtensions.ConvertNamespaceIntoAreaUrl(controllerType);

            MethodCallExpression methodCall = LinkAreasExtensions.GetMethodCall(action);
            string actionName = methodCall.Method.Name;
            string arguments = GetQueryStringArguments(helper, action, controllerUrlName, actionName);

            string url = string.Format(linkTemplate,
                helper.RequestContext.HttpContext.Request.ApplicationPath == "/"
                    ? helper.RequestContext.HttpContext.Request.ApplicationPath
                    : helper.RequestContext.HttpContext.Request.ApplicationPath + "/",
                !string.IsNullOrEmpty(areaUrl)
                    ? (areaUrl + "/" + controllerUrlName)
                    : controllerUrlName,
                actionName == "Index" || actionName == ""
                    ? ""
                    : "/" + actionName,
                arguments
                );
            return url;

        }

        private static string GetQueryStringArguments<TController>(UrlHelper helper,
     Expression<Action<TController>> action, string controllerUrlName, string actionName)
     where TController : System.Web.Mvc.Controller
        {

            RouteValueDictionary routingValues = ExpressionHelperex.GetRouteValuesFromExpression<TController>(action);
            string routePortion = helper.RouteCollection.GetVirtualPath(helper.RequestContext, routingValues).VirtualPath;
            string controllerAndActionUrlPortion = controllerUrlName + "/" + actionName;

            // If there's a "?" in the querystring, then take everything from the "?" 
            // and onwards as the parameters to the URL
            if (routePortion.IndexOf('?') > -1)
            {
                return routePortion.Substring(routePortion.IndexOf('?'));
            }
            // If the controllerAndActionUrlPortion + "/" is found in the querystring, then it implies
            // that there are parameters, so take everything after the controllerAndActionUrlPortion, 
            // including the "/"
            else if (routePortion.IndexOf(controllerAndActionUrlPortion + "/") > -1)
            {
                return routePortion.Substring(routePortion.IndexOf(controllerAndActionUrlPortion + "/") +
                    controllerAndActionUrlPortion.Length);
            }
            else
            {
                return "";
            }
        }


    }
}
