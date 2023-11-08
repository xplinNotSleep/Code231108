using System.Text.Json.Serialization;
using System.Text.Json;

namespace DataCheck.Website.Utility
{
    /// <summary>
    /// Json数据中的日期信息转换类
    /// </summary>
    public class DateTimeConverterClass : JsonConverter<DateTime>
    {

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString());
        }
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss"));

        }


    }
}
