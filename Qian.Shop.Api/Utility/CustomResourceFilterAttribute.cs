using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qian.Shop.Api.Utility
{
    public class CustomResourceFilterAttribute : Attribute, IResourceFilter
    {
        private static Dictionary<object, object> dictionnaryCache = new Dictionary<object, object>(); //创建缓存字典
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            string key = context.HttpContext.Request.Path.ToString();
            if(dictionnaryCache.ContainsKey(key)) //判断字典中是否已经存在该key
            {
                context.Result = dictionnaryCache[key] as ObjectResult; //直接返回上次请求的结果
            }            
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string key = context.HttpContext.Request.Path.ToString();
            ObjectResult objectResult = context.Result as ObjectResult;
            dictionnaryCache[key] = objectResult;
        }
    }
}
