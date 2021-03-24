namespace BlogTube.Data
{
    using System.ComponentModel.DataAnnotations;

    public class ArticleCategory
    {
        [Key]
        public int Id { get; set; }

        public string ArticleId { get; set; }

        public Article Article { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
