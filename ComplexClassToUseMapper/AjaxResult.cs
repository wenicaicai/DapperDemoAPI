using System;
using System.Collections.Generic;
using System.Text;

namespace ComplexClassToUseMapper
{
    public class AjaxResult<T>
    {
        public ResultType Type { get; set; }

        public int ErrorCode { get; set; }

        public string msg { get; set; }

        public object ResultData { get; set; }

        public static AjaxResult<T> Success()
        {
            return new AjaxResult<T>
            {
                Type = ResultType.success,
                msg = "成功"
            };
        }

        public static AjaxResult<T> Failed()
        {
            return new AjaxResult<T>
            {
                Type = ResultType.error,
                msg = "失败"
            };
        }
    }

    public enum ResultType
    {
        info = 0,
        success = 1,
        warning = 2,
        error = 3
    }
}
