using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YouOweMe.Entities;

namespace YouOweMe.Repositories.Configs
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        { 
            builder.Ignore(m => m.Description);

            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.Lastname).IsRequired();
            builder.Property(m => m.Phone).HasMaxLength(15);
        }
    }
}
