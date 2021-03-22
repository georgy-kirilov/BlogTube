namespace BlogTube.Controllers
{
    using BlogTube.Data;
    using BlogTube.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Authorize]
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public ArticlesController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleInputModel input)
        {
            ApplicationUser author = await this.userManager.GetUserAsync(this.User);

            var article = new Article
            {
                Title = input.Title,
                Body = input.Body,
                PublishedOn = DateTime.UtcNow,
            };

            author.Articles.Add(article);
            await this.dbContext.SaveChangesAsync();
            return this.Redirect("/");
        }

        public async Task<IActionResult> My()
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);
            List<Article> articles = this.dbContext.Articles.Where(x => x.AuthorId == user.Id).ToList();

            return this.View(articles);
        }

        public async Task<IActionResult> Id(string id)
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);
            Article article = this.dbContext.Articles.FirstOrDefault(x => x.Id == id);

            if (article == null)
            {
                return this.NotFound();
            }

            if (article.Author != user)
            {
                article.Views++;
                await this.dbContext.SaveChangesAsync();
            }

            return this.View(article);
        }
    }
}
