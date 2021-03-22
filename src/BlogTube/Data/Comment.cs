namespace BlogTube.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime MadeOn { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        [Required]
        public string ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
