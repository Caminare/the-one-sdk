using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TheOneSDK.Core.Request
{
    public record RequestReponse<T>
    (
        [property: JsonPropertyName("docs")]
        T[] Docs,
        [property: JsonPropertyName("total")]
        int Total,
        [property: JsonPropertyName("limit")]
        int Limit,
        [property: JsonPropertyName("offset")]
        int Offset,
        [property: JsonPropertyName("page")]
        int Page,
        [property: JsonPropertyName("pages")]
        int Pages
    );
}