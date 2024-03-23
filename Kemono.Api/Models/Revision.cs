using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kemono.Api.Models
{
    public class Revision : Post
    {
        [JsonPropertyName("revision_id")]
        public string RevisionId { get; set; } = string.Empty;
    }
}
