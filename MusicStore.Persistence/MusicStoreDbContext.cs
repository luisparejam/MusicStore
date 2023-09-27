using Microsoft.EntityFrameworkCore;
using MusicStore.Entities;

namespace MusicStore.Persistence
{
    public class MusicStoreDbContext : DbContext
    {
        public MusicStoreDbContext(DbContextOptions<MusicStoreDbContext> options)
        : base(options)
        {

        }

        public DbSet<Genre> Genres { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API

            modelBuilder.Entity<Genre>()
                .Property(p => p.Name)
                .HasMaxLength(50);

            // Si queremos usar esquema
            //modelBuilder.Entity<Genre>()
            //    .ToTable("Genres", schema:"principales");
        }
    }
}