using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YouOweMe.Entities;

namespace YouOweMe.Repositories.Configs
{
    public class LoanConfig : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.Ignore(m => m.Description);

            builder.HasOne(m => m.Person)
                .WithMany();
            builder.Navigation(m => m.Person)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.HasOne(m => m.Thing)
                .WithMany();
            builder.Navigation(m => m.Thing)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Property(m => m.BorrowedAmount).IsRequired();
            builder.Property(m => m.ReturnDate);
        }
    }
}
