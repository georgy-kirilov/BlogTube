namespace BlogTube.Controllers
{
    using BlogTube.Data;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using BlogTube.Models;
    using BlogTube.Services;

    public class TrendingController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IArticlesService articlesService;

        public TrendingController(ApplicationDbContext dbContext, IArticlesService articlesService)
        {
            this.dbContext = dbContext;
            this.articlesService = articlesService;
        }

        public IActionResult Today()
        {
            var yesterday = DateTime.UtcNow.AddDays(-1);

            var viewModels = this.dbContext.Articles
                    .Where(x => x.PublishedOn >= yesterday)
                    .OrderByDescending(x => x.Views)
                    .Take(10)
                    .Select(x => new ArticleViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Body = x.Body,
                        AuthorName = x.Author.UserName,
                        Views = x.Views,
                        Upvotes = this.articlesService.GetUpvotesCount(x.Id),
                        Downvotes = this.articlesService.GetDownvotesCount(x.Id),
                    })
                    .ToList();

            return this.View(viewModels);
        }

        public IActionResult Week()
        {
            var lastWeek = DateTime.UtcNow.AddDays(-7);

            var viewModels = this.dbContext.Articles
                    .Where(x => x.PublishedOn >= lastWeek)
                    .OrderByDescending(x => x.Views)
                    .Take(10)
                    .Select(x => new ArticleViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Body = x.Body,
                        AuthorName = x.Author.UserName,
                        Views = x.Views,
                        Upvotes = this.articlesService.GetUpvotesCount(x.Id),
                        Downvotes = this.articlesService.GetDownvotesCount(x.Id),
                        PublishedOn = x.PublishedOn.ToString("dd/MMMM/yyyy"),
                    })
                    .ToList();

            return this.View(viewModels);
        }

        public IActionResult Month()
        {
            var lastMonth = DateTime.UtcNow.AddMonths(-1);

            var viewModels = this.dbContext.Articles
                    .Where(x => x.PublishedOn >= lastMonth)
                    .OrderByDescending(x => x.Views)
                    .Take(10)
                    .Select(x => new ArticleViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Body = x.Body,
                        AuthorName = x.Author.UserName,
                        Views = x.Views,
                        Upvotes = this.articlesService.GetUpvotesCount(x.Id),
                        Downvotes = this.articlesService.GetDownvotesCount(x.Id),
                        PublishedOn = x.PublishedOn.ToString("dd/MMMM/yyyy"),
                    })
                    .ToList();

            return this.View(viewModels);
        }
    }
}
