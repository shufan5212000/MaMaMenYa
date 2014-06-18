using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Web.Mvc;
using SharpArch.Core.DomainModel;

namespace MAMAMENYA
{
    public static class ExpressionHelperex
    {
        public static RouteValueDictionary GetRouteValuesFromExpression<TController>(Expression<Action<TController>> action) where TController : System.Web.Mvc.Controller
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            MethodCallExpression call = action.Body as MethodCallExpression;
            if (call == null)
            {
                throw new ArgumentException("必须是一个方法", "action");
            }

            string controllerName = typeof(TController).Name;
            if (!controllerName.EndsWith("Controller", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("必须以Controller结尾", "action");
            }
            controllerName = controllerName.Substring(0, controllerName.Length - "Controller".Length);
            if (controllerName.Length == 0)
            {
                throw new ArgumentException("找不到Controller", "action");
            }

            // TODO: How do we know that this method is even web callable?
            //      For now, we just let the call itself throw an exception.

            string actionName = GetTargetActionName(call.Method);

            var rvd = new RouteValueDictionary();
            rvd.Add("Controller", controllerName);
            rvd.Add("Action", actionName);

            ActionLinkAreaAttribute areaAttr = typeof(TController).GetCustomAttributes(typeof(ActionLinkAreaAttribute), true /* inherit */).FirstOrDefault() as ActionLinkAreaAttribute;
            if (areaAttr != null)
            {
                string areaName = areaAttr.Area;
                rvd.Add("Area", areaName);
            }

            AddParameterValuesFromExpressionToDictionary(rvd, call);
            return rvd;
        }

        public static string GetInputName<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            if (expression.Body.NodeType == ExpressionType.Call)
            {
                MethodCallExpression methodCallExpression = (MethodCallExpression)expression.Body;
                string name = GetInputName(methodCallExpression);
                return name.Substring(expression.Parameters[0].Name.Length + 1);

            }
            return expression.Body.ToString().Substring(expression.Parameters[0].Name.Length + 1);
        }

        private static string GetInputName(MethodCallExpression expression)
        {
            // p => p.Foo.Bar().Baz.ToString() => p.Foo OR throw...

            MethodCallExpression methodCallExpression = expression.Object as MethodCallExpression;
            if (methodCallExpression != null)
            {
                return GetInputName(methodCallExpression);
            }
            return expression.Object.ToString();
        }

        // This method contains some heuristics that will help determine the correct action name from a given MethodInfo
        // assuming the default sync / async invokers are in use. The logic's not foolproof, but it should be good enough
        // for most uses.
        private static string GetTargetActionName(MethodInfo methodInfo)
        {
            string methodName = methodInfo.Name;

            // do we know this not to be an action?
            if (methodInfo.IsDefined(typeof(NonActionAttribute), true /* inherit */))
            {
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentUICulture,
                    "无法呼叫该Action:{0}", methodName));
            }

            // has this been renamed?
            ActionNameAttribute nameAttr = methodInfo.GetCustomAttributes(typeof(ActionNameAttribute), true /* inherit */).OfType<ActionNameAttribute>().FirstOrDefault();
            if (nameAttr != null)
            {
                return nameAttr.Name;
            }

            // targeting an async action?
            if (methodInfo.DeclaringType.IsSubclassOf(typeof(AsyncController)))
            {
                if (methodName.EndsWith("Async", StringComparison.OrdinalIgnoreCase))
                {
                    return methodName.Substring(0, methodName.Length - "Async".Length);
                }
                if (methodName.EndsWith("Completed", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(String.Format(CultureInfo.CurrentUICulture,
                       "找不到异步结束方法{0}Completed", methodName));
                }
            }

            // fallback
            return methodName;
        }

        static void AddParameterValuesFromExpressionToDictionary(RouteValueDictionary rvd, MethodCallExpression call)
        {
            ParameterInfo[] parameters = call.Method.GetParameters();

            if (parameters.Length > 0)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    Expression arg = call.Arguments[i];
                    object value = null;
                    ConstantExpression ce = arg as ConstantExpression;
                    if (ce != null)
                    {
                        if (ce.Type == typeof(string))
                        {
                            value = ce.Value;
                        }else if(ce.Type.IsEnum)
                        {
                            value =Enum.Format(ce.Type,  ce.Value,"d");
                        }
                        else if (ce.Type.IsClass)
                        {
                            var cc = new RouteValueDictionary(ce.Value);
                            foreach (var item in cc)
                            {
                                rvd[item.Key] = item.Value;
                            }
                            continue;
                        }
                        else
                        {
                            value = ce.Value;
                        }
                    }
                    else
                    {
                        value = CachedExpressionCompiler.Evaluate(arg);
                        var type = value.GetType();
                        if (value is string)//string 不用处理
                        {

                        }
                        else if (type.IsEnum)
                        {
                            value = Enum.Format(type, value, "d");
                        }
                        else if (type.IsClass) //如果是引用类型则解析类型的属性
                        {
                            AddToRouteValue(rvd, "", value);
                            continue;
                        }

                    }
                    rvd.Add(parameters[i].Name, value);
                }
            }
        }

        static void AddToRouteValue(RouteValueDictionary rvd, string prefix, object value)
        {

            var cc = new RouteValueDictionary(value);
            foreach (var item in cc)
            {
                if (item.Value == null) continue;
                var type = item.Value.GetType();
                if (type.IsClass)
                {
                    AddClassToRouteValue(item, type, prefix, rvd);
                }
                else
                {
                    rvd[item.Key] = item.Value;
                }

            }
        }

        private static void AddClassToRouteValue(KeyValuePair<string, object> item, Type type, string prefix, RouteValueDictionary rvd)
        {
            var strPrefix = "";
            if (prefix.IsNullOrEmpty())
            {
                strPrefix = item.Key;
            }
            else
            {
                strPrefix = prefix + "." + item.Key;
            }
            if (IsEntityType(type))
            {
                PropertyInfo pt = null;
                try
                {
                    pt = type.GetProperty("Id");
                }
                catch //FIX IIS 得到多个Id 属性的BUG
                {
                    var tp = type;
                    while (tp.FullName.Contains("Castle.Proxies"))
                    {
                        tp = type.BaseType;
                    }
                    pt = tp.GetProperty("Id");
                }
                var id = pt.GetValue(item.Value, null);
                rvd[strPrefix + ".Id"] = id;

            }
            else
            {
                AddToRouteValue(rvd, strPrefix, item.Value);
            }
        }

        private static bool IsEntityType(Type propertyType)
        {
            bool isEntityType = propertyType.GetInterfaces()
                .Any(type => type.IsGenericType &&
                    type.GetGenericTypeDefinition() == typeof(IEntityWithTypedId<>));

            return isEntityType;
        }

    }

}
