using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TheOneSDK.Core.Models
{
    public record Chapter(
        [property: JsonPropertyName("_id")]
        string Id,
        [property: JsonPropertyName("chapterName")]
        string Name,
        [property: JsonPropertyName("book")]
        string BookId
    );
}