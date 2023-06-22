namespace Handbook.Models
{
    public class Chapter
    {
        public int ChapterId { get; set; }
        public string Name { get; set; }

        public Catalog catalog { get; set; }

        public int CatalogId { get; set; }

        public List<Article> Articles { get; set; }
    }
}