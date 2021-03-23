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
    using BlogTube.Services;

    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IArticlesService articlesService;

        public ArticlesController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, IArticlesService articlesService)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.articlesService = articlesService;
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

            VoteType voteType = VoteType.None;

            if (user == null || article.AuthorId != user.Id)
            {
                article.Views++;
                await this.dbContext.SaveChangesAsync();
            }

            if (user != null)
            {
                Vote vote = this.dbContext.Votes.FirstOrDefault(v => v.ArticleId == id && v.AuthorId == user.Id);

                if (vote != null)
                {
                    voteType = vote.Type;
                }
            }

            var viewModel = new ArticleViewModel
            {
                Id = article.Id,
                Title = article.Title,
                Body = article.Body,
                AuthorName = this.dbContext.Users.FirstOrDefault(u => u.Id == article.AuthorId).UserName,
                PublishedOn = article.PublishedOn.ToString("dd/MMMM/yyyy"),
                Views = article.Views,
                Upvotes = this.articlesService.GetUpvotesCount(article.Id),
                Downvotes = this.articlesService.GetDownvotesCount(article.Id),
                UserVoteType = voteType,
            };

            return this.View(viewModel);
        }
    }
}
