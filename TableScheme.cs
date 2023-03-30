using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DummyDB
{
    class TableScheme
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("columns")]
        public List<Column> Columns { get; set; }

        public static TableScheme ReadFile(string path)
        {
            return JsonSerializer.Deserialize<TableScheme>(File.ReadAllText(path));
        }
    }

}
