using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace TheOneSDK.Core.Models
{
    public record Book(
        [property: JsonPropertyName("_id")]
        string Id,
        [property: JsonPropertyName("name")]
        string Name
    );
}