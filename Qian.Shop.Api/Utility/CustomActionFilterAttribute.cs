using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qian.Shop.Api.Utility
{
    public class CustomActionFilterAttribute : Attribute, IActionFilter
    {
        private readonly ILogger<CustomActionFilterAttribute> _logger;
        public CustomActionFilterAttribute(ILogger<CustomActionFilterAttribute> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 方法执行后
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result;
            ObjectResult objectResult = result as ObjectResult;
            var resultLog = $"{DateTime.Now} 完成调用 {context.RouteData.Values["action"]} api完成；执行结果：" +
                $"{Newtonsoft.Json.JsonConvert.SerializeObject(objectResult.Value)}";
            _logger.LogInformation(resultLog);
        }

        /// <summary>
        /// 方法执行前
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var beginLog = $"{DateTime.Now} 开始调用 {context.RouteData.Values["action"]} api： 参数为：" +
                $"{Newtonsoft.Json.JsonConvert.SerializeObject(context.ActionArguments)}";
            _logger.LogInformation(beginLog);
        }
    }
}
