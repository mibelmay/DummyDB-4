namespace DummyDB
{
    class Row
    {
        public Dictionary<Column, object> Data { get; set; }
        public Row() 
        {
            Data = new Dictionary<Column, object>();
        }
    }

}
