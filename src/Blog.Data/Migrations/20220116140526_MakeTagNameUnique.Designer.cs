﻿// <auto-generated />
using System;
using Blog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.Data.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20220116140526_MakeTagNameUnique")]
    partial class MakeTagNameUnique
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blog.Data.DbModels.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("middle_name");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.Property<Guid?>("author_user_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("author_user_id");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("Blog.Data.DbModels.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[name] IS NOT NULL");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Blog.Data.DbModels.CategoryPostMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid?>("category_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("post_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("category_id");

                    b.HasIndex("post_id");

                    b.ToTable("CategoryPostMaps");
                });

            modelBuilder.Entity("Blog.Data.DbModels.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("content");

                    b.Property<int>("Downvotes")
                        .HasColumnType("int")
                        .HasColumnName("downvotes");

                    b.Property<int>("Upvotes")
                        .HasColumnType("int")
                        .HasColumnName("upvotes");

                    b.Property<Guid?>("author_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("post_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("author_id");

                    b.HasIndex("post_id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Blog.Data.DbModels.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("content");

                    b.Property<int>("Downvotes")
                        .HasColumnType("int")
                        .HasColumnName("downvotes");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("published_on");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.Property<int>("Upvotes")
                        .HasColumnType("int")
                        .HasColumnName("upvotes");

                    b.Property<Guid?>("author_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("post_image")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("author_id");

                    b.HasIndex("post_image");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Blog.Data.DbModels.PostImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("image");

                    b.HasKey("Id");

                    b.ToTable("PostsImages");
                });

            modelBuilder.Entity("Blog.Data.DbModels.PostTagMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid?>("post_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("tag_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("post_id");

                    b.HasIndex("tag_id");

                    b.ToTable("PostTagMaps");
                });

            modelBuilder.Entity("Blog.Data.DbModels.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[name] IS NOT NULL");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Blog.Data.DbModels.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Blog.Data.DbModels.ApplicationUser", b =>
                {
                    b.HasOne("Blog.Data.DbModels.User", "AuthorUser")
                        .WithMany()
                        .HasForeignKey("author_user_id");

                    b.Navigation("AuthorUser");
                });

            modelBuilder.Entity("Blog.Data.DbModels.CategoryPostMap", b =>
                {
                    b.HasOne("Blog.Data.DbModels.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("category_id");

                    b.HasOne("Blog.Data.DbModels.Post", "Post")
                        .WithMany("Categories")
                        .HasForeignKey("post_id");

                    b.Navigation("Category");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Blog.Data.DbModels.Comment", b =>
                {
                    b.HasOne("Blog.Data.DbModels.User", "Author")
                        .WithMany()
                        .HasForeignKey("author_id");

                    b.HasOne("Blog.Data.DbModels.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("post_id");

                    b.Navigation("Author");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Blog.Data.DbModels.Post", b =>
                {
                    b.HasOne("Blog.Data.DbModels.User", "Author")
                        .WithMany()
                        .HasForeignKey("author_id");

                    b.HasOne("Blog.Data.DbModels.PostImage", "Image")
                        .WithMany()
                        .HasForeignKey("post_image");

                    b.Navigation("Author");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Blog.Data.DbModels.PostTagMap", b =>
                {
                    b.HasOne("Blog.Data.DbModels.Post", "Post")
                        .WithMany("Tags")
                        .HasForeignKey("post_id");

                    b.HasOne("Blog.Data.DbModels.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("tag_id");

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Blog.Data.DbModels.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Blog.Data.DbModels.Post", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Comments");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
