﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokemon_Review_App_Web_API_.Data;

#nullable disable

namespace Pokemon_Review_App_Web_API_.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pokemon_Review_App_Web_API_.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Pokemon_Review_App_Web_API_.Models.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Pokemon_Review_App_Web_API_.Models.Owner", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("countryid")
                        .HasColumnType("int");

                    b.Property<string>("gym")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("countryid");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("Pokemon_Review_App_Web_API_.Models.Pokemon", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("Pokemon_Review_App_Web_API_.Models.Pokemon_category", b =>
                {
                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("PokemonId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Pokemon_categories");
                });

            modelBuilder.Entity("Pokemon_Review_App_Web_API_.Models.Review", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("pokemonid")
                        .HasColumnType("int");

                    b.Property<int>("reviewerid")
                        .HasColumnType("int");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("pokemonid");

                    b.HasIndex("reviewerid");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Pokemon_Review_App_Web_API_.Models.Reviewer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Reviewers");
                });

            modelBuilder.Entity("Pokemon_Review_App_Web_API_.Models.pokemon_owner", b =>
                {
                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("PokemonId", "OwnerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Pokemon_owners");
                });

            modelBuilder.Entity("Pokemon_Review_App_Web_API_.Models.Owner", b =>
                {
                    b.HasOne("Pokemon_Review_App_Web_API_.Models.Country", "country")
                        .WithMany("owners")
                        .HasForeignKey("countryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("country");
                });

            modelBuilder.Entity("Pokemon_Review_App_Web_API_.Models.Pokemon_category", b =>
                {
                    b.HasOne("Pokemon_Review_App_Web_API_.Models.Category", "category")
                        .WithMany("pokemons")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pokemon_Review_App_Web_API_.Models.Pokemon", "pokemon")
                        .WithMany("categories")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");

                    b.Navigation("pokemon");
                });

            modelBuilder.Entity("Pokemon_Review_App_Web_API_.Models.Review", b =>
                {
                    b.HasOne("Pokemon_Review_App_Web_API_.Models.Pokemon", "pokemon")
                        .WithMany("reviews")
                        .HasForeignKey("pokemonid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pokemon_Review_App_Web_API_.Models.Reviewer", "reviewer")
                        .WithMany("reviews")
                        .HasForeignKey("reviewerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pokemon");

                    b.Navigation("reviewer");
                });

            modelBuilder.Entity("Pokemon_Review_App_Web_API_.Models.pokemon_owner", b =>
                {
                    b.HasOne("Pokemon_Review_App_Web_API_.Models.Owner", "owner")
                        .WithMany("pokemons")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pokemon_Review_App_Web_API_.Models.Pokemon", "pokemon")
                        .WithMany("owners")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("owner");

                    b.Navigation("pokemon");
                });

            modelBuilder.Entity("Pokemon_Review_App_Web_API_.Models.Category", b =>
                {
                    b.Navigation("pokemons");
                });

            modelBuilder.Entity("Pokemon_Review_App_Web_API_.Models.Country", b =>
                {
                    b.Navigation("owners");
                });

            modelBuilder.Entity("Pokemon_Review_App_Web_API_.Models.Owner", b =>
                {
                    b.Navigation("pokemons");
                });

            modelBuilder.Entity("Pokemon_Review_App_Web_API_.Models.Pokemon", b =>
                {
                    b.Navigation("categories");

                    b.Navigation("owners");

                    b.Navigation("reviews");
                });

            modelBuilder.Entity("Pokemon_Review_App_Web_API_.Models.Reviewer", b =>
                {
                    b.Navigation("reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
