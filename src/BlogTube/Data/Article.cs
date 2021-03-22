namespace BlogTube.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Article
    {
        public Article()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Categories = new HashSet<ArticleCategory>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime PublishedOn { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public virtual ICollection<ArticleCategory> Categories { get; set; }
    }
}
