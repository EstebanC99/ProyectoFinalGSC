using Microsoft.EntityFrameworkCore;
using YouOweMe.Entities;

namespace YouOweMe.Repositories
{
    public interface IYouOweMeContext
    {
        DbSet<Category> Categories { get; }

        DbSet<Thing> Things { get; }

        DbSet<Loan> Loans { get; }

        DbSet<Person> Persons { get; }

        DbSet<User> Users { get; }
    }
}