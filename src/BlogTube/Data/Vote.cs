namespace BlogTube.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Vote
    {
        public Vote()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public VoteType Type { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public string ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
