﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TccLangBackend.Framework;
using TccLangBackend.Framework.DB;

namespace TccLangBackend.Api.Migrations
{
    [DbContext(typeof(TccDbContext))]
    [Migration("20190928102303_addsOneToOne")]
    partial class addsOneToOne
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TccLangBackend.Framework.Deck", b =>
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

            modelBuilder.Entity("TccLangBackend.Framework.Flashcard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DeckId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("DeckId");

                    b.ToTable("Flashcards");
                });

            modelBuilder.Entity("TccLangBackend.Framework.Text", b =>
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

            modelBuilder.Entity("TccLangBackend.Framework.User", b =>
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

            modelBuilder.Entity("TccLangBackend.Framework.Deck", b =>
                {
                    b.HasOne("TccLangBackend.Framework.Text", "Text")
                        .WithOne("Deck")
                        .HasForeignKey("TccLangBackend.Framework.Deck", "TextId");

                    b.HasOne("TccLangBackend.Framework.User", "User")
                        .WithMany("Decks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TccLangBackend.Framework.Flashcard", b =>
                {
                    b.HasOne("TccLangBackend.Framework.Deck", "Deck")
                        .WithMany("Flashcards")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TccLangBackend.Framework.Text", b =>
                {
                    b.HasOne("TccLangBackend.Framework.User", "User")
                        .WithMany("Texts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
