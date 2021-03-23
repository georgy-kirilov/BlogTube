namespace BlogTube.Services
{
    public interface IArticlesService
    {
        int GetUpvotesCount(string articleId);

        int GetDownvotesCount(string articleId);
    }
}
