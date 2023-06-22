using Handbook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Handbook.Services
{
    public class ArticleService
    {

        public List<Chapter>? getChaptersById(ApplicationContext db, int id)
        {
            return db.Catalogs.SelectMany(x => x.chapters).Where(x => x.CatalogId == id)?.ToList();
        }
          
        public int? getArticleIdByTitle(ApplicationContext db, string Title)
        {
            return db.Catalogs.SelectMany(x => x.chapters).SelectMany(x => x.Articles).Where(x => x.Title == Title)?.FirstOrDefault()?.ArticleId;
        }

        public Article? getArticleById(ApplicationContext db, int id)
        {
            return db.Catalogs.SelectMany(x => x.chapters).SelectMany(x => x.Articles).Where(x => x.ArticleId == id)?.FirstOrDefault();
        }

        public HttpStatusCode CreateArticle(ApplicationContext db, string CatalogName, string ChapterName, string TitleName, string Content)
        {
            if (string.IsNullOrEmpty(CatalogName) || string.IsNullOrEmpty(ChapterName)|| string.IsNullOrEmpty(TitleName)|| string.IsNullOrEmpty(Content)) { return HttpStatusCode.BadRequest; }
            Catalog? catalog = db.Catalogs.Where(x => x.Name == CatalogName).FirstOrDefault();
            if (catalog is null) {
                catalog = new Catalog() { Name = CatalogName };
                db.Catalogs.Add(catalog);
                }
            Chapter? chapter = db.Catalogs.SelectMany(x => x.chapters).Where(x => x.Name == ChapterName).FirstOrDefault();
            if (chapter is null)
            {
               chapter =  new Chapter() { catalog = catalog, Name = ChapterName };
                db.Chapters.Add(chapter);
            }
            Article? article = db.Catalogs.SelectMany(x => x.chapters).SelectMany(x => x.Articles).Where(x => x.Title == TitleName).FirstOrDefault();
            if (article is null) {
               article = new Article() { chapter = chapter, Title = TitleName };
                db.Articles.Add(article);
            }
            article.Content = Content;
            db.SaveChanges();
            return HttpStatusCode.OK;
        }
    }
}
