﻿// <auto-generated />
using System;
using Dictionary.Api.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dictionary.Api.Persistence.Migrations
{
    [DbContext(typeof(DictionaryDbContext))]
    [Migration("20241003064200_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dictionary.Api.Domain.Entitys.EmailConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NewEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("EmailConfigurations");
                });

            modelBuilder.Entity("Dictionary.Api.Domain.Entitys.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("Dictionary.Api.Domain.Entitys.EntryComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("EntryId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.HasIndex("UserId");

                    b.ToTable("EntryComments");
                });

            modelBuilder.Entity("Dictionary.Api.Domain.Entitys.EntryFavorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("EntryId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.HasIndex("UserId");

                    b.ToTable("EntryFavorites");
                });

            modelBuilder.Entity("Dictionary.Api.Domain.Entitys.EntryVote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("EntryId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VoteType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.HasIndex("UserId");

                    b.ToTable("EntryVotes");
                });

            modelBuilder.Entity("Dictionary.Api.Domain.Entitys.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmailConfigurationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Dictionary.Api.Domain.Entitys.EmailConfiguration", b =>
                {
                    b.HasOne("Dictionary.Api.Domain.Entitys.User", "User")
                        .WithOne("EmailConfiguration")
                        .HasForeignKey("Dictionary.Api.Domain.Entitys.EmailConfiguration", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dictionary.Api.Domain.Entitys.Entry", b =>
                {
                    b.HasOne("Dictionary.Api.Domain.Entitys.User", "User")
                        .WithMany("Entries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dictionary.Api.Domain.Entitys.EntryComment", b =>
                {
                    b.HasOne("Dictionary.Api.Domain.Entitys.Entry", "Entry")
                        .WithMany("EntryComments")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dictionary.Api.Domain.Entitys.User", "User")
                        .WithMany("EntryComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entry");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dictionary.Api.Domain.Entitys.EntryFavorite", b =>
                {
                    b.HasOne("Dictionary.Api.Domain.Entitys.Entry", "Entry")
                        .WithMany("EntryFavorites")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dictionary.Api.Domain.Entitys.User", "User")
                        .WithMany("EntryFavorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entry");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dictionary.Api.Domain.Entitys.EntryVote", b =>
                {
                    b.HasOne("Dictionary.Api.Domain.Entitys.Entry", "Entry")
                        .WithMany("EntryVotes")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dictionary.Api.Domain.Entitys.User", "User")
                        .WithMany("EntryVotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Entry");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dictionary.Api.Domain.Entitys.Entry", b =>
                {
                    b.Navigation("EntryComments");

                    b.Navigation("EntryFavorites");

                    b.Navigation("EntryVotes");
                });

            modelBuilder.Entity("Dictionary.Api.Domain.Entitys.User", b =>
                {
                    b.Navigation("EmailConfiguration")
                        .IsRequired();

                    b.Navigation("Entries");

                    b.Navigation("EntryComments");

                    b.Navigation("EntryFavorites");

                    b.Navigation("EntryVotes");
                });
#pragma warning restore 612, 618
        }
    }
}