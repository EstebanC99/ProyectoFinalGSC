using Microsoft.EntityFrameworkCore;
using YouOweMe.Entities;
using YouOweMe.Repositories.Configs;

#nullable disable
namespace YouOweMe.Repositories
{
    public class YouOweMeContext : DbContext, IYouOweMeContext
    {
        public YouOweMeContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ThingConfig());
            modelBuilder.ApplyConfiguration(new LoanConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }

        public DbSet<Category> Categories { get; set; } 
        public DbSet<Thing> Things { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
    }
}