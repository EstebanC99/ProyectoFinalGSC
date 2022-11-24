using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YouOweMe.Entities;

namespace YouOweMe.Repositories.Configs
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        { 
            builder.Ignore(m => m.Descripcion);

            builder.Property(m => m.Nombre).IsRequired();
            builder.Property(m => m.Apellido).IsRequired();
            builder.Property(m => m.Telefono).HasMaxLength(15);
        }
    }
}
