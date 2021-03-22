namespace BlogTube.Controllers
{
    using BlogTube.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/Search")]
        public IActionResult Search(SearchArticleInputModel input)
        {
            var view = new SearchArticleViewModel();

            //TODO: Perform search in the database

            return this.View(view);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
