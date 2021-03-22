namespace BlogTube.Models
{
    using System;

    public class ArticleViewModel
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string AuthorName { get; set; }

        public DateTime PublishedOn { get; set; }

        public int VotesCount { get; set; }
    }
}
