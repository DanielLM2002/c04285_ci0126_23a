namespace laboratorio3.Models
{
    public class SongModel
    {
        public int Id { get; set; }

        public string SongName { get; set; }

        public string SongGenre { get; set; }

        public string Album { get; set; }

        public string Artist { get; set; }

        public string ProducedBy { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
