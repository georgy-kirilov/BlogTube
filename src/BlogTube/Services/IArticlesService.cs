namespace BlogTube.Services
{
    using BlogTube.Data;
    using BlogTube.Models;
    using System.Threading.Tasks;

    public interface IArticlesService
    {
        int GetUpvotesCount(string articleId);

        int GetDownvotesCount(string articleId);

        Task<ArticleViewModel> GetArticleAsync(ApplicationUser user, string articleId);
    }
}
