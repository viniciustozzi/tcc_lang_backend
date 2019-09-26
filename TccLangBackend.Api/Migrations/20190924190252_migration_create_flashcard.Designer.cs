﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TccLangBackend.DB;

namespace TccLangBackend.DB.Migrations
{
    [DbContext(typeof(TccDbContext))]
    [Migration("20190924190252_migration_create_flashcard")]
    partial class migration_create_flashcard
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TccLangBackend.Api.DB.Flashcard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Flashcards");
                });

            modelBuilder.Entity("TccLangBackend.Api.DB.Text", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FlashcardId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("FlashcardId");

                    b.ToTable("Texts");
                });

            modelBuilder.Entity("TccLangBackend.Api.DB.User", b =>
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

            modelBuilder.Entity("TccLangBackend.Api.DB.WordSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FlashcardId");

                    b.Property<bool>("IsPressed");

                    b.Property<int?>("TextId");

                    b.Property<string>("Word");

                    b.HasKey("Id");

                    b.HasIndex("FlashcardId");

                    b.HasIndex("TextId");

                    b.ToTable("WordSections");
                });

            modelBuilder.Entity("TccLangBackend.Api.DB.Text", b =>
                {
                    b.HasOne("TccLangBackend.Api.DB.Flashcard", "Flashcard")
                        .WithMany()
                        .HasForeignKey("FlashcardId");
                });

            modelBuilder.Entity("TccLangBackend.Api.DB.WordSection", b =>
                {
                    b.HasOne("TccLangBackend.Api.DB.Flashcard", "Flashcard")
                        .WithMany("WordSections")
                        .HasForeignKey("FlashcardId");

                    b.HasOne("TccLangBackend.Api.DB.Text", "Text")
                        .WithMany("WordSections")
                        .HasForeignKey("TextId");
                });
#pragma warning restore 612, 618
        }
    }
}