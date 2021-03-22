namespace BlogTube.Controllers
{
    using BlogTube.Data;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class TrendingController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public TrendingController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Today()
        {
            //this.dbContext.Articles.Where(x => x.PublishedOn < DateTime.UtcNow).OrderByDescending(x => x);
            return this.View();
        }

        public IActionResult Week()
        {
            //TODO: Extract the most viewed articles for the last week
            return this.View();
        }

        public IActionResult Month()
        {
            //TODO: Extract the most viewed articles for the last month
            return this.View();
        }
    }
}
