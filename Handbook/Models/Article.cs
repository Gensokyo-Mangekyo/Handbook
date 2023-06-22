namespace Handbook.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int ChapterId { get; set; }

        public Chapter chapter { get; set; }
    }
}
