
using ComplexClassToUseMapper;
using DapperDemoAPI.Extra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace DapperDemoAPI.Filters
{
    public class DapperExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //var result = new AjaxResult<string>();

            //if (filterContext.Exception is NaturalException)
            //{
            //    result = new AjaxResult<string> { ErrorCode = 3, msg = filterContext.Exception.Message };
            //}

            //filterContext.Result = new ApplicationErrorResult(result);
            //filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.WriteAsync("进入异常处理.");
        }
    }

    public class ApplicationErrorResult : ObjectResult
    {
        public ApplicationErrorResult(object value) : base(value)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
