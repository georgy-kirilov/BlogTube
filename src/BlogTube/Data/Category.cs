namespace BlogTube.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.Articles = new HashSet<Article>();
            this.Keywords = new HashSet<Keyword>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Keyword> Keywords { get; set; }
    }
}
