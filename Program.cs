using System;
using System.Text.Json.Serialization;

namespace DummyDB
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            TableScheme scheme = TableScheme.ReadFile(".\\book.json");
            foreach (Column column in scheme.Columns) {
                Console.WriteLine(column.Name);
                Console.WriteLine(column.Type);
                Console.WriteLine();
            }
        }
    }

    class Column
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }

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

    class ReadTable
    {

    }

}
