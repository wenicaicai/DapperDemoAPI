using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemoAPI.Filters
{
    /// <summary>
    /// 管道拦截器：第五道
    /// </summary>
    public class ResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            context.HttpContext.Response.WriteAsync("Result excuting.");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.WriteAsync("Result excuted.");
        }
    }
}
