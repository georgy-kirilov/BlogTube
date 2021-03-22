namespace BlogTube.Data
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Articles = new HashSet<Article>();
        }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
