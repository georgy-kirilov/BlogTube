namespace BlogTube.Controllers
{
    using BlogTube.Data;
    using BlogTube.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public ArticlesController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateArticleInputModel input)
        {
            //TODO: Create article and add it to the database
            return this.Redirect("/");
        }

        public async Task<IActionResult> My()
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);
            //user.Articles.Add(new Article
            //{
            //    Title = "Database features",
            //    Body = "Body",
            //});
            //this.dbContext.SaveChanges();
            return this.View(user.Articles);
        }
    }
}
