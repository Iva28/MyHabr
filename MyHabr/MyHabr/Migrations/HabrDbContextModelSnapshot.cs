﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyHabr.Models;

namespace MyHabr.Migrations
{
    [DbContext(typeof(HabrDbContext))]
    partial class HabrDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyHabr.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int?>("PostId");

                    b.Property<string>("Text");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MyHabr.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Preview");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MyHabr.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar");

                    b.Property<string>("Email");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<DateTime>("RegistrationDate");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyHabr.Models.Comment", b =>
                {
                    b.HasOne("MyHabr.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("MyHabr.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MyHabr.Models.Post", b =>
                {
                    b.HasOne("MyHabr.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
