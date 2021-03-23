namespace BlogTube.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Vote> Votes { get; set; } 

        public DbSet<Keyword> Keywords { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Comment>()
                   .HasOne(x => x.Author)
                   .WithMany(x => x.Comments)
                   .HasForeignKey(x => x.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Article>()
                   .HasOne(article => article.Category)
                   .WithMany(category => category.Articles)
                   .HasForeignKey(article => article.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
