using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheOneSDK.Core.Request.Options
{
    public class PaginationOptions
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public int? Offset { get; set; }
    }
}