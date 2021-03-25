namespace BlogTube.Controllers
{
    using BlogTube.Data;
    using BlogTube.Models;
    using BlogTube.Models.View;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<CategoryViewModel> viewModels = this.dbContext
                    .Categories
                    .Select(x => new CategoryViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        ArticlesCount = x.Articles.Count,
                    })
                    .ToList();

            return View(viewModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Search(SearchArticleInputModel input)
        {
            //TODO: Perform search in the database
            return this.View();
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
