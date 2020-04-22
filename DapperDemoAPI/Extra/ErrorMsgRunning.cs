using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemoAPI.Extra
{
    public class ErrorMsgRunning
    {
        public async Task WhatNumberIs()
        {
            var typeName = typeof(NaturalException);
            int numberI = 0;
            if (numberI == 0)
                throw new NaturalException("除数不能为0");
            int result = 5 / numberI;
        }
    }
}
