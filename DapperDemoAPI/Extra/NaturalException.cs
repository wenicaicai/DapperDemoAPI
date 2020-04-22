using System;
using System.Collections.Generic;
using System.Text;

namespace DapperDemoAPI.Extra
{
    public class NaturalException : Exception
    {
        public NaturalException()
        {

        }

        public NaturalException(string msg) : base(msg)
        {

        }
    }

    public class EasyException : Exception
    {
        public EasyException()
        {

        }

        public EasyException(string msg) : base(msg)
        {

        }
    }

}
