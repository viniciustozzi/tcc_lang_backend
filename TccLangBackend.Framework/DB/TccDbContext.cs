using Microsoft.EntityFrameworkCore;

namespace TccLangBackend.Framework.DB
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

        public DbSet<FlashcardLog> FlashcardLogs { get; set; }

        public DbSet<Bookmark> Bookmarks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateUser(modelBuilder);
            CreateDeck(modelBuilder);
            CreateText(modelBuilder);
            CreateFlashcard(modelBuilder);
        }

        private static void CreateFlashcard(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flashcard>()
                .HasMany(x => x.FlashcardLogs)
                .WithOne(x => x.Flashcard)
                .HasForeignKey(x => x.FlashcardId);
        }

        private static void CreateUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(e => e.Username).IsUnique();

            modelBuilder.Entity<User>()
                .HasMany(x => x.Decks)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Bookmarks)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }

        private static void CreateDeck(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deck>()
                .HasMany(x => x.Flashcards)
                .WithOne(x => x.Deck)
                .HasForeignKey(x => x.DeckId);
        }

        private static void CreateText(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Text>()
                .HasMany(x => x.Decks)
                .WithOne(x => x.Text)
                .HasForeignKey(x => x.TextId);

            modelBuilder.Entity<Text>()
                .HasMany(x => x.Bookmarks)
                .WithOne(x => x.Text)
                .HasForeignKey(x => x.TextId);
        }
    }
}