using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Kemono.Api.Models
{
    public class Post
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("user")]
        public string User { get; set; } = string.Empty;
        [JsonPropertyName("service")]
        [JsonConverter(typeof(JsonStringEnumConverter<ServiceType>))]
        public ServiceType Service { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
        [JsonPropertyName("Content")]
        public string Content { get; set; } = string.Empty;
        [JsonPropertyName("embed")]
        public object? Embed { get; set; } = null;
        [JsonPropertyName("shared_file")]
        public bool? SharedFile { get; set; } = null;
        [JsonPropertyName("substring")]
        public string Substring { get; set; } = string.Empty;
        [JsonPropertyName("added")]
        public DateTime? Added { get; set; } = null;
        [JsonPropertyName("published")]
        public DateTime Published { get; set; }
        [JsonPropertyName("edited")]
        public DateTime? Edited { get; set; } = null;
        [JsonPropertyName("file")]
        public File File { get; set; } = new File();
        [JsonPropertyName("attachments")]
        public IEnumerable<Attachment> Attachments { get; set; } = new List<Attachment>();
        /// <summary>
        /// Previous post id
        /// </summary>
        [JsonPropertyName("prev")]
        public string Prev { get; set; }
    }
}
