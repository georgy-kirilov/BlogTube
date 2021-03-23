namespace BlogTube.Services
{
    using BlogTube.Data;

    public class ArticlesService : IArticlesService
    {
        public ArticlesService(ApplicationDbContext dbContext)
        {

        }

        public int GetDownvotesCount(string articleId)
        {
            throw new System.NotImplementedException();
        }

        public int GetUpvotesCount(string articleId)
        {
            throw new System.NotImplementedException();
        }
    }
}
