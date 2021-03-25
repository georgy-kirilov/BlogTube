namespace BlogTube.Controllers
{
    using BlogTube.Data;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using BlogTube.Models;
    using BlogTube.Services;
    using System.Collections.Generic;

    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IArticlesService articlesService;

        public CategoriesController(ApplicationDbContext dbContext, IArticlesService articlesService)
        {
            this.dbContext = dbContext;
            this.articlesService = articlesService;
        }

        public IActionResult Id(int id)
        {
            List<ArticleViewModel> viewModels = this.dbContext
                .Articles
                .Where(article => article.CategoryId == id)
                .OrderBy(article => article.PublishedOn)
                .Select(article => new ArticleViewModel
                {
                    Id = article.Id,
                    Title = article.Title,
                    AuthorName = article.Author.UserName,
                    Views = article.Views,
                    Upvotes = this.articlesService.GetUpvotesCount(article.Id),
                    Downvotes = this.articlesService.GetDownvotesCount(article.Id),
                    PublishedOn = article.PublishedOn.ToString("dd/MMMM/yyyy"),
                })
                .ToList();

            return this.View(viewModels);
        }
    }
}
