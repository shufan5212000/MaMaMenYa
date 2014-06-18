using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace MAMAMENYA
{
    public static class ActionLinkForAreasWithAuthorize
    {
        private static readonly object lockobj = new object();
        private static Dictionary<MethodInfo, FilterInfo> controllers = new Dictionary<MethodInfo, FilterInfo>();

        /// <summary>
        /// 包含身份验证的连接生成，身份验证不通过的返回空字符
        /// </summary>
        /// <typeparam name="TController">The Controller Type</typeparam>
        /// <param name="action">The Method to route to</param>
        /// <param name="linkText">The linked text to appear on the page</param>
        /// <returns>System.String</returns>
        public static string AreaActionLinkForAuthroize<TController>(this HtmlHelper helper,
            Expression<Action<TController>> action, string linkText, object htmlAttributes) where TController : System.Web.Mvc.Controller
        {
            return helper.AreaActionLinkForAuthroize(action, linkText, "", htmlAttributes);

        }

        /// <summary>
        /// 包含身份验证的连接生成，身份验证不通过的返回空字符
        /// </summary>
        /// <typeparam name="TController">The Controller Type</typeparam>
        /// <param name="action">The Method to route to</param>
        /// <param name="linkText">The linked text to appear on the page</param>
        /// <returns>System.String</returns>
        public static string AreaActionLinkForAuthroize<TController>(this HtmlHelper helper,
            Expression<Action<TController>> action, string linkText, string noAuthTxt, object htmlAttributes) where TController : System.Web.Mvc.Controller
        {
            var method = ((MethodCallExpression)action.Body).Method;



            var info = GetFilterInfo(method);

            //设置ValueProvider，验证组件里面使用
            helper.ViewContext.Controller.ValueProvider =
                new RouteValueDictionaryProvider(ExpressionHelperex.GetRouteValuesFromExpression(action));
            var result = InvokeAuthorizationFilters(helper.ViewContext.Controller.ControllerContext, info.AuthorizationFilters, new NullActionDescriptor());

            if (result.Result != null)
            {
                if (noAuthTxt.IsNullOrEmpty())
                {
                    return "";
                }
                var values = new RouteValueDictionary(htmlAttributes);
                values.Add(noAuthTxt, "");
                return helper.ActionLinkForAreas(action, linkText, values);
            }


            return helper.ActionLinkForAreas(action, linkText, htmlAttributes);

        }
        static FilterInfo GetFilterInfo(MethodInfo method)
        {

            if (!controllers.ContainsKey(method))
            {
                lock (lockobj)
                {
                    if (!controllers.ContainsKey(method))
                    {
                        var info = GetFilters(method);
                        controllers[method] = info;
                        return info;
                    }
                }

            }
            return controllers[method];
        }
        internal static FilterInfo GetFilters(MethodInfo methodInfo)
        {
            // Enumerable.OrderBy() is a stable sort, so this method preserves scope ordering.
            FilterAttribute[] typeFilters = (FilterAttribute[])methodInfo.ReflectedType.GetCustomAttributes(typeof(FilterAttribute), true /* inherit */);
            FilterAttribute[] methodFilters = (FilterAttribute[])methodInfo.GetCustomAttributes(typeof(FilterAttribute), true /* inherit */);
            List<FilterAttribute> orderedFilters = RemoveOverriddenFilters(typeFilters.Concat(methodFilters)).OrderBy(attr => attr.Order).ToList();

            FilterInfo filterInfo = new FilterInfo();
            MergeFiltersIntoList(orderedFilters, filterInfo.ActionFilters);
            MergeFiltersIntoList(orderedFilters, filterInfo.AuthorizationFilters);
            MergeFiltersIntoList(orderedFilters, filterInfo.ExceptionFilters);
            MergeFiltersIntoList(orderedFilters, filterInfo.ResultFilters);
            return filterInfo;
        }

        internal static void MergeFiltersIntoList<TFilter>(IList<FilterAttribute> allFilters, IList<TFilter> destFilters) where TFilter : class
        {
            foreach (FilterAttribute filter in allFilters)
            {
                TFilter castFilter = filter as TFilter;
                if (castFilter != null)
                {
                    destFilters.Add(castFilter);
                }
            }
        }

        internal static IEnumerable<FilterAttribute> RemoveOverriddenFilters(IEnumerable<FilterAttribute> filters)
        {
            // If an attribute is declared on both the controller and on an action method and that attribute's
            // type has AllowMultiple = false (which is the default for attributes), we should ignore the attributes
            // declared on the controller. The CLR's reflection implementation follows a similar algorithm when it
            // encounters an overridden virtual method where both the base and the override contain some
            // AllowMultiple = false attribute.

            // Key = attribute type
            // Value = -1 if AllowMultiple true, last index of this attribute type if AllowMultiple false
            Dictionary<Type, int> attrsIndexes = new Dictionary<Type, int>();

            FilterAttribute[] filtersList = filters.ToArray();
            for (int i = 0; i < filtersList.Length; i++)
            {
                FilterAttribute filter = filtersList[i];
                Type filterType = filter.GetType();

                int lastIndex;
                if (attrsIndexes.TryGetValue(filterType, out lastIndex))
                {
                    if (lastIndex >= 0)
                    {
                        // this filter already exists and AllowMultiple = false, so clear last entry
                        filtersList[lastIndex] = null;
                        attrsIndexes[filterType] = i;
                    }
                }
                else
                {
                    // not found - add to dictionary
                    // exactly one AttributeUsageAttribute will always be present
                    // bool allowMultiple = _allowMultiplAttributesCache.IsMultiUseAttribute(filterType);
                    attrsIndexes[filterType] = i;//(allowMultiple) ? -1 : i;
                }
            }

            // any duplicated attributes have now been nulled out, so just return remaining attributes
            return filtersList.Where(attr => attr != null);
        }

        private static AuthorizationContext InvokeAuthorizationFilters(ControllerContext controllerContext, IList<IAuthorizationFilter> filters, ActionDescriptor actionDescriptor)
        {
            AuthorizationContext context = new AuthorizationContext(controllerContext, actionDescriptor);
            foreach (IAuthorizationFilter filter in filters)
            {
                filter.OnAuthorization(context);
                // short-circuit evaluation
                if (context.Result != null)
                {
                    break;
                }
            }

            return context;
        }
        //private static ControllerDescriptor GetControllerDescriptor(ControllerContext controllerContext)
        //{


        //    var controllerType = controllerContext.Controller.GetType();
        //    if (!controllers.ContainsKey(controllerType))
        //    {
        //        lock (lockobj)
        //        {
        //            if (!controllers.ContainsKey(controllerType))
        //            {
        //                ControllerDescriptor controllerDescriptor = new ReflectedControllerDescriptor(controllerType);
        //                controllers[controllerType] = controllerDescriptor;
        //                return controllerDescriptor;
        //            }
        //        }

        //    }

        //    return controllers[controllerType];

        //}

        //private static ActionDescriptor FindAction(ControllerContext controllerContext, ControllerDescriptor controllerDescriptor, string actionName)
        //{
        //    ActionDescriptor actionDescriptor = controllerDescriptor.FindAction(controllerContext, actionName);
        //    return actionDescriptor;
        //}
    }


    public class NullActionDescriptor : ActionDescriptor
    {


        public override string ActionName
        {
            get { throw new NotImplementedException(); }
        }

        public override ControllerDescriptor ControllerDescriptor
        {
            get { throw new NotImplementedException(); }
        }

        public override object Execute(ControllerContext controllerContext, IDictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public override ParameterDescriptor[] GetParameters()
        {
            throw new NotImplementedException();
        }
    }

    public class RouteValueDictionaryProvider : DictionaryValueProvider<object>
    {

        // RouteData should use the invariant culture since it's part of the URL, and the URL should be
        // interpreted in a uniform fashion regardless of the origin of a particular request.
        public RouteValueDictionaryProvider(RouteValueDictionary values)
            : base(values, CultureInfo.InvariantCulture)
        {
        }
    }
}
