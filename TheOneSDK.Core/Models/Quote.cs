using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TheOneSDK.Core.Models
{
     public record Quote(
        [property: JsonPropertyName("_id")]
        string Id,
        [property: JsonPropertyName("dialog")]
        string Dialog,
        [property: JsonPropertyName("movie")]
        string MovieId,
        [property: JsonPropertyName("character")]
        string CharacterId
    );
}