using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kemono.Api.JsonConverters
{
    public class JsonDateTimeConverter : JsonConverter<DateTime>
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.ValueSpan.Length == 0) { return DateTime.MinValue; }
            return _epoch.AddSeconds((long)reader.GetUInt64());
        }
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteRawValue((value - _epoch).TotalSeconds.ToString());
        }
    }
}