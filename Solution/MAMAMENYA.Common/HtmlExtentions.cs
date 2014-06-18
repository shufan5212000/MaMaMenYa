using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Microsoft.Web.Mvc;

namespace MAMAMENYA
{
    public static class HtmlExtentions
    {
        public static MvcHtmlString Debug(this HtmlHelper helper)
        {
#if DEBUG
            return MvcHtmlString.Create("<div id='_divDebug'></div>");
#endif
            return MvcHtmlString.Create("");
        }

        public static MvcHtmlString CssInclude(this HtmlHelper helper, string file)
        {
            return CssInclude(helper, file, null);
        }

        public static MvcHtmlString CssInclude(this HtmlHelper helper, string file, string mediaType)
        {
            if (String.IsNullOrEmpty(file))
            {
                throw new ArgumentException("请输入文件名", "file");
            }

            string src;
            if (file.IsRelativeToDefaultPath())
            {
                src = "~/Content/Css/" + file;
            }
            else
            {
                src = file;
            }

            TagBuilder linkTag = new TagBuilder("link");
            linkTag.MergeAttribute("type", "text/css");
            linkTag.MergeAttribute("rel", "stylesheet");
            if (mediaType != null)
            {
                linkTag.MergeAttribute("media", mediaType);
            }
            linkTag.MergeAttribute("href", UrlHelper.GenerateContentUrl(src, helper.ViewContext.HttpContext));
            return MvcHtmlString.Create(linkTag.ToString(TagRenderMode.SelfClosing));
        }
        public static MvcHtmlString ImageInclude(this HtmlHelper helper, string imageRelativeUrl, string alt, object htmlAttributes)
        {
            if (String.IsNullOrEmpty(imageRelativeUrl))
            {
                throw new ArgumentException("请输入文件名", "imageRelativeUrl");
            }

            string src;
            if (imageRelativeUrl.IsRelativeToDefaultPath())
            {
                src = UrlHelper.GenerateContentUrl("~/Content/Images/" + imageRelativeUrl, helper.ViewContext.HttpContext);
            }
            else
            {
                src = imageRelativeUrl;
            }
            TagBuilder imageTag = new TagBuilder("img");

            if (!String.IsNullOrEmpty(imageRelativeUrl))
            {
                //imageTag.MergeAttribute("src", imageRelativeUrl);

                imageTag.MergeAttribute("src", src);
            }

            if (!String.IsNullOrEmpty(alt))
            {
                imageTag.MergeAttribute("alt", alt);
            }

            imageTag.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);

            if (imageTag.Attributes.ContainsKey("alt") && !imageTag.Attributes.ContainsKey("title"))
            {
                imageTag.MergeAttribute("title", (imageTag.Attributes["alt"] ?? "").ToString());
            }
            return MvcHtmlString.Create(imageTag.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString ImageInclude(this HtmlHelper helper, string imageRelativeUrl, string alt)
        {
            return ImageInclude(helper, imageRelativeUrl, alt, null);
        }
        public static MvcHtmlString ImageInclude(this HtmlHelper helper, string imageRelativeUrl)
        {
            return ImageInclude(helper, imageRelativeUrl, null, null);
        }

        public static MvcHtmlString DropDownListFor<TModel, TIdProperty, TProperty, TTextProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> items, Expression<Func<TProperty, TIdProperty>> idExpression, Expression<Func<TProperty, TTextProperty>> textExpression)
        {
            return DropDownListFor(htmlHelper, items, idExpression, textExpression, null, null);
        }

        public static MvcHtmlString DropDownListFor<TModel, TIdProperty, TProperty, TTextProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> items, Expression<Func<TProperty, TIdProperty>> idExpression, Expression<Func<TProperty, TTextProperty>> textExpression, string optionLabel)
        {
            return DropDownListFor(htmlHelper, items, idExpression, textExpression, optionLabel, null);
        }



        public static MvcHtmlString DropDownListFor<TModel, TIdProperty, TProperty, TTextProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> items, Expression<Func<TProperty, TIdProperty>> idExpression, Expression<Func<TProperty, TTextProperty>> textExpression, string optionLabel, object htmlAttributes)
        {

            var list = From(items.Compile()(htmlHelper.ViewData.Model), idExpression, textExpression);


            // var list = items.Select(c => new SelectListItem { Value=idExpression. });
           
            return htmlHelper.DropDownListFor(items, list, optionLabel, htmlAttributes);

        }

        public static IEnumerable<SelectListItem> From<TProperty, TIdProperty, TTextProperty>(this IEnumerable<TProperty> items, Expression<Func<TProperty, TIdProperty>> idExpression, Expression<Func<TProperty, TTextProperty>> textExpression)
        {
            var idFunc = idExpression.Compile();
            var textFunc = textExpression.Compile();
            var list = items.Select(c => new SelectListItem { Value = idFunc(c).ToString(), Text = textFunc(c).ToString() });
            return list;
        }



        public static MvcHtmlString DropDownList<TModel, TIdProperty, TProperty, TTextProperty>(this HtmlHelper<TModel> htmlHelper, string name, Expression<Func<TModel, IEnumerable<TProperty>>> items, Expression<Func<TProperty, TIdProperty>> idExpression, Expression<Func<TProperty, TTextProperty>> textExpression)
        {
            return DropDownList(htmlHelper, name, items, idExpression, textExpression, null, null);
        }

        public static MvcHtmlString DropDownList<TModel, TIdProperty, TProperty, TTextProperty>(this HtmlHelper<TModel> htmlHelper, string name, Expression<Func<TModel, IEnumerable<TProperty>>> items, Expression<Func<TProperty, TIdProperty>> idExpression, Expression<Func<TProperty, TTextProperty>> textExpression, string optionLabel)
        {
            return DropDownList(htmlHelper, name, items, idExpression, textExpression, optionLabel, null);
        }

        public static MvcHtmlString DropDownList<TModel, TIdProperty, TProperty, TTextProperty>(this HtmlHelper<TModel> htmlHelper, string name, Expression<Func<TModel, IEnumerable<TProperty>>> items, Expression<Func<TProperty, TIdProperty>> idExpression, Expression<Func<TProperty, TTextProperty>> textExpression, string optionLabel, object htmlAttributes)
        {

            var idFunc = idExpression.Compile();
            var textFunc = textExpression.Compile();
            var list = items.Compile()(htmlHelper.ViewData.Model).Select(c => new SelectListItem { Value = idFunc(c).ToString(), Text = textFunc(c).ToString() });


            // var list = items.Select(c => new SelectListItem { Value=idExpression. });

            return htmlHelper.DropDownList(name, list, optionLabel, htmlAttributes);

        }


        public static MvcHtmlString DropDownListForBoolean<TModel>(this HtmlHelper<TModel> htmlHelper, string name, string optionLabel)
        {
            return DropDownListForBoolean(htmlHelper, name, optionLabel, null);
        }


        public static MvcHtmlString DropDownListForBoolean<TModel>(this HtmlHelper<TModel> htmlHelper, string name, string optionLabel, object htmlAttributes)
        {
            SelectList selectList =
                new SelectList(new object[] { new { Value = true, Text = "是" }, new { Value = false, Text = "否" } }, "Value",
                               "Text");
            return htmlHelper.DropDownList(name, selectList, optionLabel, htmlAttributes);
        }






        public static void RenderActionForArea<TController>(this HtmlHelper helper, string areaName, Expression<Action<TController>> action)
    where TController : System.Web.Mvc.Controller
        {
            RouteValueDictionary rvd = Microsoft.Web.Mvc.Internal.ExpressionHelper.GetRouteValuesFromExpression(action);

            foreach (var entry in helper.ViewContext.RouteData.Values)
            {
                if (!rvd.ContainsKey(entry.Key))
                {
                    rvd.Add(entry.Key, entry.Value);
                }
            }
            rvd.Add("area", areaName);
            helper.RenderRoute(rvd);
        }

        public static void RenderActionForArea<TController>(this HtmlHelper helper, Expression<Action<TController>> action)
    where TController : System.Web.Mvc.Controller
        {
            var typeController = typeof(TController);
            var area = typeController.Namespace.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();

            RenderActionForArea(helper, area, action);
        }


    }
}
