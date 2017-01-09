using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace ShowmuWeb.Tools
{

    public class JObjectModelBinder : IModelBinder
    {
        public JObjectModelBinder(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null) throw new ArgumentNullException("bindingContext");
            ValueProviderResult result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);//调用取值 ValueProvider
            try
            {
                if (bindingContext.ModelType == typeof(JObject))
                {
                    JObject obj = new JObject();
                    if (bindingContext.ActionContext.HttpContext.Request.ContentType.
                StartsWith("application/json", StringComparison.OrdinalIgnoreCase))//json
                    {
                        if (result.ToString().StartsWith("["))//是否是组？
                        {
                            obj =(JObject) JArray.Parse(result.ToString()).First;//取首值。
                            bindingContext.Result = (ModelBindingResult.Success(obj));
                            return Task.CompletedTask;
                        }
                        else
                        {
                            obj = JObject.Parse(result.ToString());//不是组直接取值
                        }
                    }
                    else  //form
                    {
                        foreach (var item in bindingContext.ActionContext.HttpContext.Request.Form)
                        {
                            obj.Add(new JProperty(item.Key.ToString(), item.Value.ToString()));
                        }
                    }
                    if ((obj.Count == 0))
                    {
                        bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, bindingContext.ModelMetadata.ModelBindingMessageProvider.ValueMustNotBeNullAccessor(result.ToString()));
                        return Task.CompletedTask;
                    }
                    bindingContext.Result = (ModelBindingResult.Success(obj));
                    return Task.CompletedTask;
                }
                if (bindingContext.ModelType == typeof(JArray ))
                {
                    JArray obj = new JArray();
                    if   (bindingContext.ActionContext.HttpContext.Request.ContentType.
                StartsWith("application/json", StringComparison.OrdinalIgnoreCase))//json
                        {
                        if (result.ToString().StartsWith("["))//是否是组？
                        {
                            JArray array = new JArray();
                            array = JArray.Parse(result.ToString());//取首值。
                            bindingContext.Result = (ModelBindingResult.Success(array));
                            return Task.CompletedTask;
                        }
                    }
                    if ((obj.Count == 0))
                    {
                        bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, bindingContext.ModelMetadata.ModelBindingMessageProvider.ValueMustNotBeNullAccessor(result.ToString()));
                        return Task.CompletedTask;
                    }
                    bindingContext.Result = (ModelBindingResult.Success(obj));
                    return Task.CompletedTask;
                }
                return Task.CompletedTask;
            }
            catch (Exception exception)
            {
                if (!(exception is FormatException) && (exception.InnerException != null))
                {
                    exception = ExceptionDispatchInfo.Capture(exception.InnerException).SourceException;
                }
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, exception, bindingContext.ModelMetadata);
                return Task.CompletedTask;
            }
        }
    }
}

