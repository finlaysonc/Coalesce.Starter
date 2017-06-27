using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Coalesce.TaskListSample.Data;

namespace Coalesce.TaskListSample.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20170627221445_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LastName");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("BlogId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.BlogAndAuthor", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LastName");

                    b.Property<string>("Url");

                    b.HasKey("BlogId");

                    b.ToTable("BlogAndAuthor");
                });

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.BlogsWithNameFoo", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("BlogId");

                    b.ToTable("BlogsWithNameFoo");
                });

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.ShortBlog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Url");

                    b.HasKey("BlogId");

                    b.ToTable("ShortBlogs");
                });

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.Blog", b =>
                {
                    b.HasOne("Coalesce.TaskListSample.Data.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");
                });
        }
    }
}
