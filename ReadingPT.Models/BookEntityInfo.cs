namespace ReadingPT.Models
{
    public class BookEntityInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string BookCode { get; set; }

        public string BannerUrl { get; set; }

        public int BookCategory { get; set; }

        public string Description { get; set; }

        public bool IsCharge { get; set; }
    }
}