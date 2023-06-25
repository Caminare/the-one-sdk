using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheOneSDK.Core.Request.Options;

namespace TheOneSDK.Core.Request
{
    public class APIRequest
    {
        public PaginationOptions Pagination { get; set; }
        public SortingOptions Sorting { get; set; }
        public List<Filter<object>> Filters { get; set; }
    }
}