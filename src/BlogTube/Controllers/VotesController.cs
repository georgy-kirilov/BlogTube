namespace BlogTube.Controllers
{
    using BlogTube.Data;
    using BlogTube.Services;
    using BlogTube.Models.Input;
    using BlogTube.Models.Response;

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
        private readonly IArticlesService articlesService;

        public VotesController(
            ApplicationDbContext dbContext, 
            UserManager<ApplicationUser> userManager, 
            IArticlesService articlesService)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.articlesService = articlesService;
        }

        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel input)
        {
            string userId = this.userManager.GetUserId(this.User);

            if (userId == null)
            {
                return this.Unauthorized();
            }

            Vote vote = this.dbContext.Votes.FirstOrDefault(v => v.ArticleId == input.ArticleId && v.AuthorId == userId);
            VoteType voteType = input.IsUp ? VoteType.Up : VoteType.Down;

            var responseModel = new VoteResponseModel
            {
                IsUpvoted = input.IsUp,
                IsDownvoted = !input.IsUp,
            };

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
                    responseModel.IsUpvoted = false;
                    responseModel.IsDownvoted = false;
                }
                else
                {
                    vote.Type = voteType;
                }
            }

            await this.dbContext.SaveChangesAsync();

            responseModel.Upvotes = this.articlesService.GetUpvotesCount(input.ArticleId);
            responseModel.Downvotes = this.articlesService.GetDownvotesCount(input.ArticleId);

            return responseModel;
        }
    }
}
