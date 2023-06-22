using Handbook.Models;
using Handbook.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Handbook.Controllers
{
    public class CatalogController : Controller
    {
        [HttpGet]
        [Route("/GetArticle")]
        public IActionResult GetArticle([FromServices] ApplicationContext db, [FromServices] ArticleService articleService ,int id)
        {
            Article? article = articleService.getArticleById(db,id);
            if (article == null )
            {
                throw new NotImplementedException();
            }
            return View("Article",article);
        }

       
    }
}
