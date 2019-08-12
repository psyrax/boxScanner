using SQLite;

namespace boxScanner
{
    public class BoxItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        [Indexed]
        public string BoxId { get; set; }
    }
}