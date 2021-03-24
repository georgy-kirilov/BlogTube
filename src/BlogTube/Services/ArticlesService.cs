namespace BlogTube.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using BlogTube.Data;
    using BlogTube.Models;

    public class ArticlesService : IArticlesService
    {
        private readonly ApplicationDbContext dbContext;

        public ArticlesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ArticleViewModel> GetArticleAsync(ApplicationUser user, string articleId)
        {
            Article article = this.dbContext.Articles.FirstOrDefault(x => x.Id == articleId);
            bool canBeDeleted = true;

            if (article == null)
            {
                return null;
            }

            VoteType voteType = VoteType.None;

            if (user == null || article.AuthorId != user.Id)
            {
                article.Views++;
                canBeDeleted = false;
                await this.dbContext.SaveChangesAsync();
            }

            if (user != null)
            {
                Vote vote = this.dbContext.Votes.FirstOrDefault(v => v.ArticleId == articleId && v.AuthorId == user.Id);

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
                Upvotes = this.GetUpvotesCount(article.Id),
                Downvotes = this.GetDownvotesCount(article.Id),
                UserVoteType = voteType,
                CategoryName = this.dbContext.Categories.FirstOrDefault(c => c.Id == article.CategoryId).Name,
                CanBeDeleted = canBeDeleted,
            };

            return viewModel;
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
