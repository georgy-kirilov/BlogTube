namespace BlogTube.Models
{
    using BlogTube.Data;

    public class ArticleViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string AuthorName { get; set; }

        public string PublishedOn { get; set; }

        public int Views { get; set; }

        public int Upvotes { get; set; }

        public int Downvotes { get; set; }

        public VoteType UserVoteType { get; set; }

        public string CategoryName { get; set; }

        public bool CanBeDeleted { get; set; }
    }
}
