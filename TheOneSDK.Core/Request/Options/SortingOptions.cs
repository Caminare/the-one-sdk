using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheOneSDK.Core.Request.Extensions;

namespace TheOneSDK.Core.Request.Options
{
    public class SortingOptions
    {
        public string PropName { get; set; }
        public SortOrder Order { get; set; }

        public string ToQueryString()
        {
            return $"sort={PropName.ToCamelCase()}:{Order.ToString().ToLower()}";
        }
    }

    public enum SortOrder
    {
        Asc,
        Desc
    }
}