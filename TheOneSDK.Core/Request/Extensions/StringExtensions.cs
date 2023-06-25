using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheOneSDK.Core.Request.Extensions
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string str)
        {
            return str.Substring(0, 1).ToLower() + str.Substring(1);
        }
    }
}