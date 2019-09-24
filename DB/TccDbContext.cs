using System;
using Microsoft.EntityFrameworkCore;

namespace tcc_lang_backend.DB
{
    public class TccDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<Flashcard> Flashcards { get; set; }

        public TccDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(e => e.Username).IsUnique();
        }
    }
}