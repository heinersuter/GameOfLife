using System;
using GameOfLife.Model;
using Newtonsoft.Json;

namespace GameOfLife.Service
{
    public class GridConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Grid);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var grid = (Grid)value;

            writer.WriteStartObject();
            writer.WritePropertyName("Width");
            serializer.Serialize(writer, grid.Width);
            writer.WritePropertyName("Height");
            serializer.Serialize(writer, grid.Height);

            writer.WritePropertyName("Alive");
            writer.WriteStartArray();
            for (var x = 0; x < grid.Width; x++)
            {
                for (var y = 0; y < grid.Height; y++)
                {
                    if (grid[x, y])
                    {
                        writer.WriteStartObject();
                        writer.WritePropertyName("X");
                        serializer.Serialize(writer, x);
                        writer.WritePropertyName("Y");
                        serializer.Serialize(writer, y);
                        writer.WriteEndObject();
                    }
                }
            }
            writer.WriteEndArray();

            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            reader.Read(); // PropertyName Width
            var width = reader.ReadAsInt32() ?? 0;
            reader.Read(); // PropertyName Height
            var height = reader.ReadAsInt32() ?? 0;
            reader.Read(); // PropertyName Alive

            var grid = new Grid(width, height);

            reader.Read(); // StartArray
            reader.Read(); // StartObject or EndArray

            while (reader.TokenType == JsonToken.StartObject)
            {
                reader.Read(); // PropertyName
                var x = reader.ReadAsInt32() ?? 0;
                reader.Read(); // PropertyName
                var y = reader.ReadAsInt32() ?? 0;
                reader.Read(); // EndObject

                grid[x, y] = true;

                reader.Read(); // StartObject or EndArray
            }
            reader.Read(); // EndObject

            return grid;
        }
    }
}