using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YouOweMe.Entities;

namespace YouOweMe.Repositories.Configs
{
    public class ThingConfig : IEntityTypeConfiguration<Thing>
    {
        public void Configure(EntityTypeBuilder<Thing> builder)
        {
            builder.Property(m => m.Nombre).IsRequired();
            builder.Property(m => m.Descripcion).IsRequired();
            builder.Property(m => m.Cantidad).IsRequired();

            builder.HasOne(m => m.Category)
                .WithMany();
            builder.Navigation(m => m.Category)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
