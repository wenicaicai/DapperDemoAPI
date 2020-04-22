using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DapperDemoAPI.Filters
{
    /// <summary>
    /// 管道拦截器：第二道
    /// </summary>
    public class ResourceFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            context.HttpContext.Response.WriteAsync("Resuorce excuting.");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.WriteAsync("Resuorce excuted.");
        }
    }
}
