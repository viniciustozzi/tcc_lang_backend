using System;
using Microsoft.EntityFrameworkCore;

namespace tcc_lang_backend.DB
{
    public class TccDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<WordSection> WordSections { get; set; }

        public TccDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Text>()
                .HasMany(x => x.WordSections)
                .WithOne(x => x.Text);
            
            //this allows arrays of strings to be saved to the database
            //by transforming it to a comma separated string when saving and splitting it when reading
//            modelBuilder.Entity<User>()
//                .Property(e => e.Roles)
//                .HasConversion(
//                    v => string.Join(',', v),
//                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<User>()
                .HasIndex(e => e.Username).IsUnique();
        }
    }
}