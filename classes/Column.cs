using System.Text.Json.Serialization;

namespace DummyDB
{
    class Column
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
       
    }

}
