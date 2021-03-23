namespace BlogTube.Models.Input
{
    using System.ComponentModel.DataAnnotations;

    public class CreateArticleInputModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(30)]
        public string Body { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
