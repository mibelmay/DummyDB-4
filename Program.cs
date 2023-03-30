using System;
using System.Text.Json.Serialization;

namespace DummyDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TableScheme scheme = TableScheme.ReadFile(".\\book.json");
            //foreach (Column column in scheme.Columns) {
            //    Console.WriteLine(column.Name);
            //    Console.WriteLine(column.Type);
            //    Console.WriteLine();
            //}
            Table table = ReadTable.Read(scheme, "\\books.csv");
            Console.WriteLine(table.Rows[0].Data[scheme.Columns[2]]);
            
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
        public TableScheme Scheme { get; set; }
        public List<Row> Rows { get; set; }
    }

    class Row
    {
        public Dictionary<Column, object> Data { get; set; }
        public Row() 
        {
            Data = new Dictionary<Column, object>();
        }
    }

}
