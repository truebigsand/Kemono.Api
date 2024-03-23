using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Kemono.Api.JsonConverters;

namespace Kemono.Api.Models
{
    public class Creator
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("service")]
        [JsonConverter(typeof(JsonStringEnumConverter<ServiceType>))]
        public ServiceType Service { get; set; }
        [JsonPropertyName("indexed")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime Indexed { get; set; }
        [JsonPropertyName("updated")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime Updated { get; set; }
        [JsonPropertyName("favorited")]
        public int Favorited { get; set; }
    }
}
