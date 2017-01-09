using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Threading.Tasks;

namespace ShowmuWeb.Tools
{
    internal class JObjectValueProvider : IValueProvider
    {
        private JContainer _jcontainer;
        public JObjectValueProvider(JContainer jcontainer)
        {
            _jcontainer = jcontainer;
        }
        public bool ContainsPrefix(string prefix)
        {
            //  return _jcontainer.SelectToken(prefix) != null;
            return true;
        }
        public ValueProviderResult GetValue(string key)
        {
            var jtoken = _jcontainer.SelectToken("");
            if (jtoken == null) return ValueProviderResult.None;
            return new ValueProviderResult( jtoken.ToString(), CultureInfo.CurrentCulture);
        }
    }
}