namespace BlogTube.Controllers
{
    using BlogTube.Models;
    using Microsoft.AspNetCore.Mvc;

    public class ArticlesController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateArticleInputModel input)
        {
            //TODO: Create article and add it to the database
            return this.Redirect("/");
        }
    }
}
