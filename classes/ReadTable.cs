namespace DummyDB
{
    class ReadTable
    {
        public static Table Read(TableScheme scheme, string path)
        {
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + path);
            Table table = new Table();
            table.Rows = new List<Row>();
            table.Scheme = scheme;

            for (int i = 0; i < data.Length; i++)
            {
                string[] line = data[i].Split(';');
                if(line.Length != scheme.Columns.Count)
                {
                    throw new Exception("В таблице неверное количество столбцов");
                }
                table.Rows.Add(CreateRow(scheme, line, i));
            }
            return table;
        }

        public static Row CreateRow(TableScheme scheme, string[] line, int i)
        {   
            Row row = new Row();
            for (int j = 0; j < line.Length; j++)
            {
                switch (scheme.Columns[j].Type)
                {
                    case ("int"):
                        {
                            IntCase(line[j], row, scheme.Columns[j], i, j);
                            break;
                        }
                    case ("uint"):
                        {
                            UintCase(line[j], row, scheme.Columns[j], i, j);
                            break;
                        }
                    case ("datetime"):
                        {
                            DateTimeCase(line[j], row, scheme.Columns[j], i, j);
                            break;
                        }
                    case ("double"):
                        {
                            DoubleCase(line[j], row, scheme.Columns[j], i, j);
                            break;
                        }
                    default:
                        row.Data.Add(scheme.Columns[j], line[j]);
                        break;
                }

            }

            return row;
        }

        public static void IntCase(string element, Row row, Column column, int i, int j)
        {
            if (int.TryParse(element, out int data))
            {
                row.Data.Add(column, data);
            }
            else
            {
                throw new Exception($"В сроке {i + 1} в столбце {j + 1} указаны некорректные данные");
            }
        }
        public static void UintCase(string element, Row row, Column column, int i, int j)
        {
            if (uint.TryParse(element, out uint data))
            {
                row.Data.Add(column, data);
            }
            else
            {
                throw new Exception($"В сроке {i + 1} в столбце {j + 1} указаны некорректные данные");
            }
        }
        public static void DateTimeCase(string element, Row row, Column column, int i, int j)
        {
            if (DateTime.TryParse(element, out DateTime data))
            {
                row.Data.Add(column, data);
            }
            else
            {
                throw new Exception($"В сроке {i + 1} в столбце {j + 1} указаны некорректные данные");
            }
        }
        public static void DoubleCase(string element, Row row, Column column, int i, int j)
        {
            if (double.TryParse(element, out double data))
            {
                row.Data.Add(column, data);
            }
            else
            {
                throw new Exception($"В сроке {i + 1} в столбце {j + 1} указаны некорректные данные");
            }
        }
    }
}
