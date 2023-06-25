using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheOneSDK.Core.Request.Options;
using RestSharp;

namespace TheOneSDK.Core.Request.Extensions
{
    public static class RestRequestExtensions
    {
        public static RestRequest AddOptions(this RestRequest request, APIRequest options)
        {
            var requestBuilder = new RequestBuilder();
            requestBuilder = requestBuilder.AddPagination(options.Pagination).AddSorting(options.Sorting);

            if (options.Filters != null)
            {
                foreach (var filter in options.Filters)
                {
                    requestBuilder = requestBuilder.AddFilter(filter);
                }
            }

            request.AddQueryParameter(requestBuilder.Build(), null, false);

            return request;
        }

        public static RestRequest AddParameters (this RestRequest request, Dictionary<string, string> parameters)
        {
            foreach (var parameter in parameters)
            {
                request.AddUrlSegment(parameter.Key, parameter.Value);
            }

            return request;
        }
    }
}