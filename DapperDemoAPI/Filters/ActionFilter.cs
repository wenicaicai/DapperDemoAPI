using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DapperDemoAPI.Filters
{

    /// <summary>
    /// 管道拦截器：第三道
    /// https://www.cnblogs.com/xtt321/p/12467142.html
    /// 在调用操作方法之前和之后立即运行代码；可以更改传递到操作中的参数；可以更改从操作返回的结果。
    /// </summary>
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.WriteAsync("Action excuting.");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.WriteAsync("Action excuted.");
        }
    }
}
