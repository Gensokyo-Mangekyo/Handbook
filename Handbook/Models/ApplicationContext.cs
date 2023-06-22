using Microsoft.EntityFrameworkCore;

namespace Handbook.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chapter>()
                .HasOne(s => s.catalog)
                .WithMany(c => c.chapters)
                .HasForeignKey(s => s.CatalogId);
            modelBuilder.Entity<Article>()
                .HasOne(s => s.chapter)
                .WithMany(c => c.Articles)
                .HasForeignKey(s => s.ChapterId);
        }

        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Article> Articles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;database=Hakurei;",
                new MySqlServerVersion(new Version(8, 0, 25)));
        }
    }
}
