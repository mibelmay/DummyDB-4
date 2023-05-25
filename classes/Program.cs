using System;

namespace DummyDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TableScheme scheme = TableScheme.ReadFile(".\\book.json");

            Table table = ReadTable.Read(scheme, "\\books.csv");
            Console.WriteLine(table.Rows[1].Data[scheme.Columns[2]]);
        }
    }

}
