﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TccLangBackend.Api;
using TccLangBackend.DB;

namespace TccLangBackend.Api.Migrations
{
    [DbContext(typeof(TccDbContext))]
    [Migration("20190922153746_migration2")]
    partial class migration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TccLangBackend.Api.DB.Text", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

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

                    b.Property<string>("Roles")
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

                    b.Property<bool>("IsPressed");

                    b.Property<int?>("TextId");

                    b.Property<string>("Word");

                    b.HasKey("Id");

                    b.HasIndex("TextId");

                    b.ToTable("WordSections");
                });

            modelBuilder.Entity("TccLangBackend.Api.DB.WordSection", b =>
                {
                    b.HasOne("TccLangBackend.Api.DB.Text", "Text")
                        .WithMany("WordSections")
                        .HasForeignKey("TextId");
                });
#pragma warning restore 612, 618
        }
    }
}
