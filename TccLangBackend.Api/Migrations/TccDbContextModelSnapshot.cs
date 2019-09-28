﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TccLangBackend.DB;

namespace TccLangBackend.Api.Migrations
{
    [DbContext(typeof(TccDbContext))]
    partial class TccDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TccLangBackend.DB.Deck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("TextId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TextId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("TccLangBackend.DB.Flashcard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DeckId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("DeckId");

                    b.ToTable("Flashcards");
                });

            modelBuilder.Entity("TccLangBackend.DB.Text", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DeckId");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.Property<string>("Words");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Texts");
                });

            modelBuilder.Entity("TccLangBackend.DB.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fullname")
                        .IsRequired();

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired();

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TccLangBackend.DB.Deck", b =>
                {
                    b.HasOne("TccLangBackend.DB.Text", "Text")
                        .WithOne("Deck")
                        .HasForeignKey("TccLangBackend.DB.Deck", "TextId");

                    b.HasOne("TccLangBackend.DB.User", "User")
                        .WithMany("Decks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TccLangBackend.DB.Flashcard", b =>
                {
                    b.HasOne("TccLangBackend.DB.Deck", "Deck")
                        .WithMany("Flashcards")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TccLangBackend.DB.Text", b =>
                {
                    b.HasOne("TccLangBackend.DB.User", "User")
                        .WithMany("Texts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
