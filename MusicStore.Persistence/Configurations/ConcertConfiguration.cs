using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Entities;

namespace MusicStore.Persistence.Configurations;

public class ConcertConfiguration : IEntityTypeConfiguration<Concert>
{
    public void Configure(EntityTypeBuilder<Concert> builder)
    {
        builder.Property(p => p.Title)
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .HasMaxLength(200);

        builder.Property(p => p.Place)
            .HasMaxLength(100);

        builder.Property(p => p.DateEvent)
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()"); // Esto es muy especifico del proveedor de datos

        builder.Property(p => p.ImageUrl)
            .IsUnicode(false)
            .HasMaxLength(1000);

        builder.HasIndex(p => p.Title);
    }
}
