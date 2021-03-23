namespace BlogTube.Models.Input
{
    using BlogTube.Data;
    using System.Collections.Generic;
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
        [Display(Name = "Choose a category")]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
