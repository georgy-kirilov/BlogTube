namespace BlogTube.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CreateArticleInputModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(80)]
        public string Title { get; set; }

        [Required]
        [MinLength(30)]
        public string Body { get; set; }
    }
}
