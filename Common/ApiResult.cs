using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class ApiResult
    {
        public static object Successed(object data,string msg = "succ")
        {
            return new
            {
                code = 0,
                msg,
                data
            };
        }
        public static object Successed(object data,int total = 0,string msg = "succ")
        {
            return new
            {
                code = 0,
                msg,
                data,
                total
            };
        }

        public static object Successed(string msg = "succ")
        {
            return new
            {
                code = 0,
                msg                
            };
        }

        public static object Failed(string msg  = "error")
        {
            return new
            {
                code = -1,
                msg
            };
        }
    }
}
