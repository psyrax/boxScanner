using SQLite;
namespace boxScanner
{
    public class Box
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Indexed]
        public string BoxId { get; set; }
        public string Name { get; set; }

        public string BoxDetail { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
