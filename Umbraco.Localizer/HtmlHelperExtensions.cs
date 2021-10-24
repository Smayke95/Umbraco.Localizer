using System.Globalization;
using System.Web;
using System.Web.Mvc;

namespace Umbraco.Localizer
{
    public static class HtmlHelperExtensions
    {
        public static string DictionaryItem<TModel>(this HtmlHelper<TModel> htmlHelper, string key)
        {
            if (HttpContext.Current.Request["keys"] == "true") return key;

            var helper = Web.Composing.Current.UmbracoHelper;
            var value = helper.GetDictionaryValue(key);
            if (string.IsNullOrEmpty(value)) return key;
            return value;
        }

        public static string DictionaryItemCulture<TModel>(this HtmlHelper<TModel> htmlHelper, string key, string culture)
        {
            if (HttpContext.Current.Request["keys"] == "true") return key;

            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            var helper = Web.Composing.Current.UmbracoHelper;
            var value = helper.GetDictionaryValue(key);
            if (string.IsNullOrEmpty(value)) return key;
            return value;
        }
    }
}