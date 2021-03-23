namespace BlogTube.Controllers
{
    using BlogTube.Data;
    using BlogTube.Models.Input;
    using BlogTube.Models.Response;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using System.Linq;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel input)
        {
            string userId = this.userManager.GetUserId(this.User);
            Vote vote = this.dbContext.Votes.FirstOrDefault(v => v.ArticleId == input.ArticleId && v.AuthorId == userId);
            VoteType voteType = input.IsUp ? VoteType.Up : VoteType.Down;

            if (vote == null)
            {
                vote = new Vote
                {
                    Type = voteType,
                    ArticleId = input.ArticleId,
                    AuthorId = userId,
                };

                this.dbContext.Votes.Add(vote);
            }
            else
            {
                if (vote.Type == VoteType.Up && input.IsUp || vote.Type == VoteType.Down && !input.IsUp)
                {
                    vote.Type = VoteType.None;
                }
                else
                {
                    vote.Type = voteType;
                }
            }

            await this.dbContext.SaveChangesAsync();

            int upvotes = this.dbContext.Votes.Where(v => v.ArticleId == input.ArticleId && v.Type == VoteType.Up).ToList().Count;
            int downvotes = this.dbContext.Votes.Where(v => v.ArticleId == input.ArticleId && v.Type == VoteType.Down).ToList().Count;

            return new VoteResponseModel { Upvotes = upvotes, Downvotes = downvotes };
        }
    }
}
