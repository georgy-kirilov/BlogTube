namespace BlogTube.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BlogTube.Data;
    using BlogTube.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ArticlesController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
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

        [Authorize]
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

            if (article.AuthorId != user.Id)
            {
                article.Views++;
                await this.dbContext.SaveChangesAsync();
            }

            var viewModel = new ArticleViewModel
            {
                Id = article.Id,
                Title = article.Title,
                Body = article.Body,
                AuthorName = this.dbContext.Users.FirstOrDefault(u => u.Id == article.AuthorId).UserName,
                PublishedOn = article.PublishedOn.ToString("dd/MMMM/yyyy"),
                Views = article.Views,
                Upvotes = this.dbContext.Votes.Where(v => v.ArticleId == article.Id && v.Type == VoteType.Up).ToList().Count,
                Downvotes = this.dbContext.Votes.Where(v => v.ArticleId == article.Id && v.Type == VoteType.Down).ToList().Count,
            };

            return this.View(viewModel);
        }
    }
}
