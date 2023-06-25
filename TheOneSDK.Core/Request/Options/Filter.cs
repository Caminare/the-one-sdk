using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheOneSDK.Core.Request.Extensions;

namespace TheOneSDK.Core.Request.Options
{
    public class Filter<T>
    {
        public string PropName { get; set; }
        public T Value { get; set; }
        public FilterOperator Operator { get; set; }
        public string OperatorString => OperatorToString();

        public Filter(string propName, T value, FilterOperator op)
        {
            PropName = propName.ToCamelCase();
            Value = value;
            Operator = op;
        }

        public string OperatorToString()
        {
            switch (Operator)
            {
                case FilterOperator.Contains:
                case FilterOperator.Equals:
                case FilterOperator.Like:
                    return "=";
                case FilterOperator.NotContains:
                case FilterOperator.NotEquals:
                case FilterOperator.NotLike:
                    return "!=";
                case FilterOperator.GreaterThan:
                    return ">";
                case FilterOperator.GreaterThanOrEqual:
                    return ">=";
                case FilterOperator.LessThan:
                    return "<";
                case FilterOperator.LessThanOrEqual:
                    return "<=";
                case FilterOperator.NotExists:
                    return "!";
                default:
                    return "";
            }
        }

    }

    public enum FilterOperator
    {
        Equals,
        NotEquals,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
        Contains,
        NotContains,
        Like,
        NotLike,
        Exists,
        NotExists
    }
}