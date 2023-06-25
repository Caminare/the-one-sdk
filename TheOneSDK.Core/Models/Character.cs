using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TheOneSDK.Core.Models
{
      public record Character(
        [property: JsonPropertyName("_id")]
        string Id,
        [property: JsonPropertyName("name")]
        string Name,
        [property: JsonPropertyName("race")]
        string Race,
        [property: JsonPropertyName("gender")]
        string Gender,
        [property: JsonPropertyName("realm")]
        string Realm,
        [property: JsonPropertyName("hair")]
        string Hair,
        [property: JsonPropertyName("height")]
        string Height,
        [property: JsonPropertyName("birth")]
        string Birth,
        [property: JsonPropertyName("spouse")]
        string Spouse,
        [property: JsonPropertyName("death")]
        string Death,
        [property: JsonPropertyName("wikiUrl")]
        string WikiUrl
    );
}