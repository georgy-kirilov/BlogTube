namespace BlogTube.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class TrendingController : Controller
    {
        public IActionResult Today()
        {
            //TODO: Extract the most viewed articles for the last 24 hours
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
