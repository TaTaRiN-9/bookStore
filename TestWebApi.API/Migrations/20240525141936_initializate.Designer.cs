﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestWebApi.DataAccess;

#nullable disable

namespace TestWebApi.API.Migrations
{
    [DbContext(typeof(TestWebApiDbContext))]
    [Migration("20240525141936_initializate")]
    partial class initializate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TestWebApi.DataAccess.Entities.BasketEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailUser")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ListBook")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EmailUser")
                        .IsUnique();

                    b.ToTable("basket");
                });

            modelBuilder.Entity("TestWebApi.DataAccess.Entities.BookEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            Description = "Черезвычайно захватывающее фэнтези. Прекрасно подойдет детям в подростковом возрасте!",
                            Price = 1900m,
                            Title = "Гарри Поттер и тайная комната"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "Черезвычайно захватывающее фэнтези. Прекрасно подойдет детям в подростковом возрасте!",
                            Price = 1900m,
                            Title = "Гарри Поттер и узник Азкабана"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Одно из лучших произведений Михаила Булгакова, который является знаменитым писателем 20-ого века.",
                            Price = 1999m,
                            Title = "Мастер и Маргарита"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 6,
                            Description = "Роман Фёдора Достоевского с криминальным сюжетом и глубокой религиозно-философской подоплёкой.",
                            Price = 1650m,
                            Title = "Преступление и наказание"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 6,
                            Description = "Роман Льва Толстого, в котором автор описывает человеческие жизни на фоне исторического события.",
                            Price = 2700m,
                            Title = "Война и мир"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 7,
                            Description = "Произведение Н.В.Гоголя.",
                            Price = 1200m,
                            Title = "Мертвые души"
                        });
                });

            modelBuilder.Entity("TestWebApi.DataAccess.Entities.GenreEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Фантастика"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Фэнтези"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Приключения"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Драма"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Мелодрама"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Роман"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Детектив"
                        });
                });

            modelBuilder.Entity("TestWebApi.DataAccess.Entities.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailUser")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("TestWebApi.DataAccess.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}