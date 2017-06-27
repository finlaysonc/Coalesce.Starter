//add-migration -Name Initial -Context AppDbContext -StartupProject Coalesce.TaskListSample.Data

using Coalesce.TaskListSample.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Coalesce.TaskListSample.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        [NotMapped]
        public DbSet<ShortBlog> ShortBlogs { get; set; }

        public DbSet<Author> Authors { get; set; }

        [NotMapped]
        public DbSet<BlogsWithNameFoo> BlogsWithNameFoo { get; set; }

        [NotMapped]
        public DbSet<BlogAndAuthor> BlogAndAuthor { get; set; }

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Remove cascading deletes.
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //builder.Entity<Student>()
            //    .Property(p => p.FullName)
            //    .HasComputedColumnSql($"[{nameof(Student.LastName)}] + ','  + [{nameof(Student.FirstMidName)}]");

            // builder.EnableAutoHistory();
        }

        /// <summary>
        /// Migrates the database and sets up items that need to be set up from scratch.
        /// </summary>
        public void Initialize()
        {
            try
            {
                this.Database.Migrate();
            }
            catch (InvalidOperationException e) when (e.Message ==
                                                      "No service for type 'Microsoft.EntityFrameworkCore.Migrations.IMigrator' has been registered."
            )
            {
                // this exception is expected when using an InMemory database
            }
        }
    }
}