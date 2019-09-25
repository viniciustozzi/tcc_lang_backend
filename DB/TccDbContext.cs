using Microsoft.EntityFrameworkCore;

namespace tcc_lang_backend.DB
{
    public class TccDbContext : DbContext
    {
        public TccDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<Flashcard> Flashcards { get; set; }

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
        }
    }
}