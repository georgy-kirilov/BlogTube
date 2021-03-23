namespace BlogTube.Data
{
    using System.ComponentModel.DataAnnotations;

    public class ArticleKeyword
    {
        [Key]
        public int Id { get; set; }

        public string ArticleId { get; set; }

        public Article Article { get; set; }

        public int KeywordId { get; set; }

        public Keyword Keyword { get; set; }
    }
}
