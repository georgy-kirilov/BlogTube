namespace BlogTube.Services
{
    using System.Linq;
    using BlogTube.Data;

    public class ArticlesService : IArticlesService
    {
        private readonly ApplicationDbContext dbContext;

        public ArticlesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int GetDownvotesCount(string articleId)
        {
            return this.GetVotes(articleId, VoteType.Down);
        }

        public int GetUpvotesCount(string articleId)
        {
            return this.GetVotes(articleId, VoteType.Up);
        }

        private int GetVotes(string articleId, VoteType voteType)
        {
            return this.dbContext.Votes
                .Where(v => v.ArticleId == articleId && v.Type == voteType)
                .ToList()
                .Count;
        }
    }
}
