using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Entities;
using System.Reflection.Emit;

namespace MusicStore.Persistence.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        // Fluent API

        builder
            .Property(p => p.Name)
            .HasMaxLength(50);
    }
}
