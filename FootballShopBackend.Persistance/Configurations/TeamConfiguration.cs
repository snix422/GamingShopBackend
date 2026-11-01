using FootballShopBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballShopBackend.Persistance.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(40);

        builder.Property(t => t.Country)
            .IsRequired()
            .HasMaxLength(20);
    }
}
