using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DummyDB
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            TableScheme scheme = TableScheme.ReadFile(".\\book.json");
            Console.WriteLine(scheme.Name);
            Console.WriteLine();
        }
    }

    class TableScheme
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("columns")]
        public List<Column> Columns { get; }

        public static TableScheme ReadFile(string path)
        {
            return JsonSerializer.Deserialize<TableScheme>(File.ReadAllText(path));
        }
    }

    class Column
    { 
        public string Name { get; }
        public ColumnType Type { get; }
    }

    class Table
    {
        private TableScheme Scheme { get; }

    }

    class Row
    {
        public Dictionary<Column, object> Data { get; }
    }


    enum ColumnType
    {
        String,
        Int,
        Uint,
        Double,
        DateTime
    }

}
