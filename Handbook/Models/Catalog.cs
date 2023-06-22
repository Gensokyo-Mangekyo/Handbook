namespace Handbook.Models
{
    public class Catalog
    {
        public int CatalogId { get; set; }

        public string? Name { get; set; }

        public List<Chapter> chapters { get; set; }
    }
}