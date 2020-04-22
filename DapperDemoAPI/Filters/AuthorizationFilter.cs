using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DapperDemoAPI.Filters
{
    /// <summary>
    /// 管道拦截器：第一道
    /// </summary>
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Response.WriteAsync("用户暂无权限.");
        }
    }
}
