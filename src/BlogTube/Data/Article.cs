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
            this.Keywords = new HashSet<ArticleKeyword>();
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime PublishedOn { get; set; }

        public int Views { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public virtual ICollection<ArticleKeyword> Keywords { get; set; } 

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
