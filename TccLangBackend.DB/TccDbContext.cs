using Microsoft.EntityFrameworkCore;

namespace TccLangBackend.DB
{
    public class TccDbContext : DbContext
    {
        public TccDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<Flashcard> Flashcards { get; set; }

        public DbSet<Deck> Decks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(e => e.Username).IsUnique();

            modelBuilder.Entity<Deck>()
                .HasMany(x => x.Flashcards)
                .WithOne(x => x.Deck)
                .HasForeignKey(x => x.DockerId);

            modelBuilder.Entity<Text>()
                .HasMany(x => x.Decks)
                .WithOne(x => x.Text)
                .HasForeignKey(x => x.TextId);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Decks)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Texts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}