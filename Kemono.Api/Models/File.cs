using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kemono.Api.Models
{
    public class File
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("path")]
        public string Path { get; set; } = string.Empty;
        [JsonPropertyName("covers")]
        public IEnumerable<Cover> Covers { get; set; } = new List<Cover>();
        [JsonPropertyName("thumbnail")]
        public Attachment Thumbnail { get; set; } = new Attachment();
    }
}
