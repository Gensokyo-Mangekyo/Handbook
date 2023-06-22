using Handbook.Models;
using Handbook.Services;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Handbook.Controllers
{
    public class HomeController : Controller
    {
        public  IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/GetCatalog")]
        public IActionResult Catalog([FromServices] ApplicationContext applicationContext, [FromServices] ArticleService articleService, int id)
        {
            List<Chapter>? chapters = articleService.getChaptersById(applicationContext, id);
            if (chapters.Count == 0)
            {
                throw new NotImplementedException();
            }
            return View("ViewCatalogs",chapters);
        }

        [HttpPost]
        [Route("/GetArticles")] 
        public IActionResult GetArticles([FromServices] ApplicationContext applicationContext, [FromServices] SearchService articleService, string SearchName)
        {
            List<Article> articles = articleService.GetArticles(applicationContext, SearchName);
            return View("SearchResults",articles);
        }

        [HttpPost]
        [Route("/Article")]
        public IActionResult CreateArticle([FromServices] ApplicationContext applicationContext, [FromServices] ArticleService articleService, string CatalogName, string ChapterName, string TitleName, string Content,string Password) {
            if (Password != "Hakurei")
                return View("Index", "Пароль неправильный");
            HttpStatusCode Code = articleService.CreateArticle(applicationContext,CatalogName,ChapterName,TitleName,Content);
            if (Code == HttpStatusCode.OK)
            {
                int? id = articleService.getArticleIdByTitle(applicationContext, TitleName);
               if (id.HasValue)
                {
                    return Redirect($"~/GetArticle?id={id}");
                }
            }
            return View("Index","Не успешно");
                    
        }
    }
}
