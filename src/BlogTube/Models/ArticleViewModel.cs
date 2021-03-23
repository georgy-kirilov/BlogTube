namespace BlogTube.Models
{
    using System;

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
    }
}
