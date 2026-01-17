// En AppStockul.Shared.Models
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Stockpoint.Shared.Models
{

    //public class JsonDotNetDateConverter : JsonConverter<DateTime>
    //{
    //    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        string dateString = reader.GetString();

    //        // Manejar formato "/Date(1634567890123)/"
    //        if (dateString.StartsWith("/Date(") && dateString.EndsWith(")/"))
    //        {
    //            string timestampStr = dateString.Substring(6, dateString.Length - 8);
    //            if (long.TryParse(timestampStr, out long timestamp))
    //            {
    //                // Convertir timestamp de milisegundos a DateTime
    //                return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).DateTime;
    //            }
    //        }

    //        throw new JsonException($"Formato de fecha no reconocido: {dateString}");
    //    }

    //    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    //    {
    //        // Opcional: Si necesitas enviar fechas en el mismo formato
    //        long timestamp = new DateTimeOffset(value).ToUnixTimeMilliseconds();
    //        writer.WriteStringValue($"/Date({timestamp})/");
    //    }
    //}
    public class JsonDotNetDateConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                if (reader.TokenType == JsonTokenType.String)
                {
                    string dateString = reader.GetString();

                    // Manejar formato "/Date(1634567890123)/"
                    if (dateString.StartsWith("/Date(") && dateString.EndsWith(")/"))
                    {
                        string timestampStr = dateString.Substring(6, dateString.Length - 8);
                        if (long.TryParse(timestampStr, out long timestamp))
                        {
                            // Convertir timestamp de milisegundos a DateTime (UTC)
                            var dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(timestamp);
                            return dateTimeOffset.UtcDateTime;
                        }
                    }

                    // Intentar parsear como DateTime normal si el formato no coincide
                    if (DateTime.TryParse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var date))
                    {
                        return date;
                    }
                }
                else if (reader.TokenType == JsonTokenType.Number)
                {
                    // Manejar timestamp directamente como número
                    long timestamp = reader.GetInt64();
                    return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).DateTime;
                }

                throw new JsonException($"Formato de fecha no reconocido");
            }
            catch (Exception ex)
            {
                throw new JsonException("Error al convertir fecha", ex);
            }
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            // Convertir a UTC antes de serializar
            var utcValue = value.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(value, DateTimeKind.Utc)
                : value.ToUniversalTime();

            long timestamp = new DateTimeOffset(utcValue).ToUnixTimeMilliseconds();
            writer.WriteStringValue($"/Date({timestamp})/");
        }
    }

}
