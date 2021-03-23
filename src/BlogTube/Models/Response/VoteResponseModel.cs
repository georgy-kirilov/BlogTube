namespace BlogTube.Models.Response
{
    public class VoteResponseModel
    {
        public int Upvotes { get; set; }

        public int Downvotes { get; set; }

        public bool IsUpvoted { get; set; }

        public bool IsDownvoted { get; set; }
    }
}
