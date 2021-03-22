namespace BlogTube.Data
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Articles = new HashSet<Article>();
            this.Comments = new HashSet<Comment>();
        }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
