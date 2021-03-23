namespace BlogTube.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Keyword
    {
        public Keyword()
        {
            this.Articles = new HashSet<ArticleKeyword>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public virtual ICollection<ArticleKeyword> Articles { get; set; }
    }
}
