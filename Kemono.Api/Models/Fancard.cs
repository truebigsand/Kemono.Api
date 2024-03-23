using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kemono.Api.Models
{
    public class Fancard
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; } = string.Empty;

        [JsonPropertyName("file_id")]
        public long FileId { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; } = string.Empty;

        [JsonPropertyName("mtime")]
        public DateTime Mtime { get; set; }

        [JsonPropertyName("ctime")]
        public DateTime Ctime { get; set; }

        [JsonPropertyName("mime")]
        public string Mime { get; set; } = string.Empty;

        [JsonPropertyName("ext")]
        public string Ext { get; set; } = string.Empty;

        [JsonPropertyName("added")]
        public DateTime Added { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("ihash")]
        public object? Ihash { get; set; } = null;
    }
}
