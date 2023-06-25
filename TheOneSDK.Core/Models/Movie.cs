using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TheOneSDK.Core.Models
{
      public record Movie(
        [property: JsonPropertyName("_id")]
        string Id,
        [property: JsonPropertyName("name")]
        string Name,
        [property: JsonPropertyName("runtimeInMinutes")]
        int Runtime,
        [property: JsonPropertyName("budgetInMillions")]
        float Budget,
        [property: JsonPropertyName("academyAwardNominations")]
        int AcademyAwardNominations,
        [property: JsonPropertyName("rottenTomatoesScore")]
        float RottenTomatoesScore,
        [property: JsonPropertyName("boxOfficeRevenueInMillions")]
        float BoxOfficeRevenue
    );
}