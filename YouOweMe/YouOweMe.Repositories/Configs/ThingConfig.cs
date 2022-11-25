using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YouOweMe.Entities;

namespace YouOweMe.Repositories.Configs
{
    public class ThingConfig : IEntityTypeConfiguration<Thing>
    {
        public void Configure(EntityTypeBuilder<Thing> builder)
        {
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.Description).IsRequired();
            builder.Property(m => m.Quantity).IsRequired();

            builder.HasOne(m => m.Category)
                .WithMany();
            builder.Navigation(m => m.Category)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
