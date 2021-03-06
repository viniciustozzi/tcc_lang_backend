﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TccLangBackend.Framework.DB;

namespace TccLangBackend.Api.Migrations
{
    [DbContext(typeof(TccDbContext))]
    [Migration("20191013154745_AddSourceLanguage")]
    partial class AddSourceLanguage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TccLangBackend.Framework.DB.Bookmark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TextId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TextId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookmarks");
                });

            modelBuilder.Entity("TccLangBackend.Framework.DB.Deck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("TextId");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TextId");

                    b.HasIndex("UserId");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("TccLangBackend.Framework.DB.Flashcard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DeckId");

                    b.Property<string>("OriginalWord");

                    b.Property<string>("TranslatedWord");

                    b.HasKey("Id");

                    b.HasIndex("DeckId");

                    b.ToTable("Flashcards");
                });

            modelBuilder.Entity("TccLangBackend.Framework.DB.Text", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Language");

                    b.Property<string>("Title");

                    b.Property<int?>("UserId");

                    b.Property<string>("Words");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Texts");
                });

            modelBuilder.Entity("TccLangBackend.Framework.DB.User", b =>
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

            modelBuilder.Entity("TccLangBackend.Framework.DB.Bookmark", b =>
                {
                    b.HasOne("TccLangBackend.Framework.DB.Text", "Text")
                        .WithMany("Bookmarks")
                        .HasForeignKey("TextId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TccLangBackend.Framework.DB.User", "User")
                        .WithMany("Bookmarks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TccLangBackend.Framework.DB.Deck", b =>
                {
                    b.HasOne("TccLangBackend.Framework.DB.Text", "Text")
                        .WithMany("Decks")
                        .HasForeignKey("TextId");

                    b.HasOne("TccLangBackend.Framework.DB.User", "User")
                        .WithMany("Decks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TccLangBackend.Framework.DB.Flashcard", b =>
                {
                    b.HasOne("TccLangBackend.Framework.DB.Deck", "Deck")
                        .WithMany("Flashcards")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TccLangBackend.Framework.DB.Text", b =>
                {
                    b.HasOne("TccLangBackend.Framework.DB.User")
                        .WithMany("Texts")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
