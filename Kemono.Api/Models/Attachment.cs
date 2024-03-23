using System.Text.Json.Serialization;

namespace Kemono.Api.Models
{
    public class Attachment
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("path")]
        public string Path { get; set; } = string.Empty;
        public bool IsEmpty() => Name == string.Empty && Path == string.Empty;
    }
}
