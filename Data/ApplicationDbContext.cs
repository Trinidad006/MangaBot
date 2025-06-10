using Microsoft.EntityFrameworkCore;
using MangaBot.Models;

namespace MangaBot.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Manga> Mangas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Manga>()
            .HasIndex(m => m.Titulo)
            .IsUnique();
    }
} 