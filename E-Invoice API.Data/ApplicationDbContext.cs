using E_Invoice_API.Data.EntityConfiguration;
using E_Invoice_API.Data.Models;
using E_Invoice_API.Data.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace E_Invoice_API.Data
{
    public class ApplicationDbContext : IdentityUserContext<User, int>
    {
        public DbSet<User> User => Set<User>();
        public DbSet<MailHistory> MailHistory => Set<MailHistory>();
        public DbSet<Application> Application => Set<Application>();
        public DbSet<ApplicationComment> ApplicationComment => Set<ApplicationComment>();
        public DbSet<ApplicationUserVote> ApplicationUserVote => Set<ApplicationUserVote>();
        public DbSet<ForumComment> ForumComment => Set<ForumComment>();
        public DbSet<ForumThread> ForumThread => Set<ForumThread>();

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MailHistoryConfiguration).Assembly);

            SeedConfiguration.Seed(modelBuilder);
        }
    }
}
