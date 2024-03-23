using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kemono.Api.Models
{
    public class Announcement
    {
        [JsonPropertyName("service")]
        public ServiceType Service { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; } = string.Empty;
        [JsonPropertyName("hash")]
        public string Hash { get; set; } = string.Empty;
        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;
        [JsonPropertyName("added")]
        public DateTime Added { get; set; }
    }
}
