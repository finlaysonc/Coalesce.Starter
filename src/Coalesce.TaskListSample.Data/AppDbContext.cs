using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Coalesce.TaskListSample.Data.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
namespace Coalesce.TaskListSample.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Course> Courses { get; set; }
        //public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Student> Students { get; set; }

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
            {
                warnings.Log(CoreEventId.IncludeIgnoredWarning);
                warnings.Log(RelationalEventId.OpeningConnection);
                warnings.Log(RelationalEventId.PossibleIncorrectResultsUsingLikeOperator);
                warnings.Log(RelationalEventId.PossibleUnintendedUseOfEqualsWarning);
                warnings.Log(RelationalEventId.QueryClientEvaluationWarning);
                warnings.Throw(CoreEventId.IncludeIgnoredWarning);
                warnings.Throw(RelationalEventId.OpeningConnection);
                warnings.Throw(RelationalEventId.PossibleIncorrectResultsUsingLikeOperator);
                warnings.Throw(RelationalEventId.PossibleUnintendedUseOfEqualsWarning);
                warnings.Throw(RelationalEventId.QueryClientEvaluationWarning);
            });
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Remove cascading deletes.
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<Student>()
                .Property(p => p.FullName)
                .HasComputedColumnSql($"[{nameof(Student.LastName)}] + ','  + [{nameof(Student.FirstName)}]");

            builder.EnableAutoHistory();
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