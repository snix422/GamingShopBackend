using FootballShopBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballShopBackend.Persistance.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(a => a.Surname)
            .IsRequired()
            .HasMaxLength(20);
    }
}
