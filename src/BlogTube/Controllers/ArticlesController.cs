namespace BlogTube.Controllers
{
    using BlogTube.Data;
    using BlogTube.Models;
    using BlogTube.Services;
    using BlogTube.Models.Input;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IArticlesService articlesService;

        public ArticlesController(
            ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            IArticlesService articlesService)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.articlesService = articlesService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var inputModel = new CreateArticleInputModel
            {
                Categories = this.dbContext.Categories.ToList()
            };

            return this.View(inputModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleInputModel input)
        {
            ApplicationUser author = await this.userManager.GetUserAsync(this.User);

            Category category = this.dbContext.Categories.FirstOrDefault(c => c.Id == input.CategoryId);

            var article = new Article
            {
                Title = input.Title,
                Body = input.Body,
                PublishedOn = DateTime.UtcNow,
                Views = 1,
            };

            category.Articles.Add(article);
            author.Articles.Add(article);
            await this.dbContext.SaveChangesAsync();

            return this.Redirect("/");
        }

        [Authorize]
        public async Task<IActionResult> My()
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);

            var articles = this.dbContext.Articles.Where(x => x.AuthorId == user.Id).ToList();
            var articlesViewModels = new List<ArticleViewModel>(articles.Count);

            foreach (var article in articles)
            {
                articlesViewModels.Add(await this.articlesService.GetArticleAsync(user, article.Id));
            }

            return this.View(articlesViewModels);
        }

        public async Task<IActionResult> Id(string id)
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);
            ArticleViewModel viewModel = await this.articlesService.GetArticleAsync(user, id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }
    }
}
