using System.Text.Json.Serialization;

namespace Kemono.Api.Models
{
    public class Cover
    {
        [JsonPropertyName("original")]
        public Attachment Original { get; set; } = new Attachment();
        [JsonPropertyName("main_cover")]
        public bool MainCover { get; set; } = false;
    }
}
