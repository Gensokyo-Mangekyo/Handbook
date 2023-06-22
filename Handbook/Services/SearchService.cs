using Handbook.Models;
using Microsoft.EntityFrameworkCore;

namespace Handbook.Services
{
    public class SearchService
    {
        public List<Article> GetArticles(ApplicationContext db, string Title)
        {
           return db.Catalogs.SelectMany(x => x.chapters).SelectMany(x => x.Articles).Where(x => x.Title.StartsWith(Title)).ToList();
         }
    }
}
