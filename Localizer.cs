using Umbraco.Web;

namespace Umbraco.Localizer
{
    public class Localizer
    {
        private UmbracoHelper Helper { get; set; }

        public Localizer()
        {
            Helper = Web.Composing.Current.UmbracoHelper;
        }

        public string this[string name]
        {
            get
            {
                return Helper.GetDictionaryValue(name);
            }
        }
    }
}