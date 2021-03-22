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
            var articles = user.Articles.ToList();

            /*foreach (Article article in user.Articles.ToList())
            {
                articles.Add(new ArticleViewModel
                {
                    Title = article.Title,
                    Body = article.Body,
                    AuthorName = article.Author.UserName,
                    PublishedOn = article.PublishedOn,
                    VotesCount = article.Votes.Count,
                });
            }*/

            return this.View(articles);
        }
    }
}
