using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ShowmuWeb.Tools
{
    public class JObjectModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (context.Metadata.ModelType == (typeof(JObject)))
            {
                return new JObjectModelBinder(context.Metadata.ModelType);
            }
            if (context.Metadata.ModelType == (typeof(JArray)))
            {
                return new JObjectModelBinder(context.Metadata.ModelType);
            }
            return null;
        }
    }
}
