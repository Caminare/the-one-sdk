using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheOneSDK.Core.Request.Options;

namespace TheOneSDK.Core.Request
{
    public class RequestBuilder
    {
        private List<string> _filters = new List<string>();

        public RequestBuilder AddFilter<T>(Filter<T> filter)
        {
            if (filter.Operator == FilterOperator.Exists || filter.Operator == FilterOperator.NotExists)
            {
                _filters.Add($"{filter.OperatorString}{filter.PropName}");
            }
            else
            {
                if (filter.Value != null)
                {
                    _filters.Add($"{filter.PropName}{filter.OperatorString}{filter.Value}");
                }
            }

            return this;
        }

        public RequestBuilder AddPagination(PaginationOptions pagination)
        {
            if (pagination != null)
            {
                if (pagination.PageSize.HasValue)
                {
                    _filters.Add($"limit={pagination.PageSize}");
                }

                if (pagination.PageNumber.HasValue)
                {
                    _filters.Add($"page={pagination.PageNumber}");
                }

                if (pagination.Offset.HasValue)
                {
                    _filters.Add($"offset={pagination.Offset}");
                }
            }

            return this;
        }

        public RequestBuilder AddSorting(SortingOptions sorting)
        {
            if (sorting != null && !string.IsNullOrEmpty(sorting.PropName) && sorting.Order != null)
            {
                _filters.Add(sorting.ToQueryString());
            }

            return this;
        }

        public string Build()
        {
            return string.Join("&", _filters);
        }

    }
}