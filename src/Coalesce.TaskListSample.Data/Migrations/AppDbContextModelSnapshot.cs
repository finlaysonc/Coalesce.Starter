using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Coalesce.TaskListSample.Data;

namespace Coalesce.TaskListSample.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Credits");

                    b.Property<int>("DepartmentID");

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("CourseID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.CourseAssignment", b =>
                {
                    b.Property<int>("CourseAssignmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseID");

                    b.Property<int>("InstructorID");

                    b.HasKey("CourseAssignmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("InstructorID");

                    b.ToTable("CourseAssignments");
                });

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<int?>("InstructorID");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("StartDate");

                    b.HasKey("DepartmentID");

                    b.HasIndex("InstructorID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseID");

                    b.Property<int?>("Grade");

                    b.Property<int>("StudentID");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FullName");

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("InstructorID");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.OfficeAssignment", b =>
                {
                    b.Property<int>("InstructorID");

                    b.Property<string>("Location")
                        .HasMaxLength(50);

                    b.HasKey("InstructorID");

                    b.ToTable("OfficeAssignments");
                });

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FullName")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("[LastName] + ','  + [FirstMidName]");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("StudentID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.Course", b =>
                {
                    b.HasOne("Coalesce.TaskListSample.Data.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentID");
                });

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.CourseAssignment", b =>
                {
                    b.HasOne("Coalesce.TaskListSample.Data.Models.Course", "Course")
                        .WithMany("CourseAssignments")
                        .HasForeignKey("CourseID");

                    b.HasOne("Coalesce.TaskListSample.Data.Models.Instructor", "Instructor")
                        .WithMany("CourseAssignments")
                        .HasForeignKey("InstructorID");
                });

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.Department", b =>
                {
                    b.HasOne("Coalesce.TaskListSample.Data.Models.Instructor", "Administrator")
                        .WithMany()
                        .HasForeignKey("InstructorID");
                });

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.Enrollment", b =>
                {
                    b.HasOne("Coalesce.TaskListSample.Data.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseID");

                    b.HasOne("Coalesce.TaskListSample.Data.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID");
                });

            modelBuilder.Entity("Coalesce.TaskListSample.Data.Models.OfficeAssignment", b =>
                {
                    b.HasOne("Coalesce.TaskListSample.Data.Models.Instructor", "Instructor")
                        .WithOne("OfficeAssignment")
                        .HasForeignKey("Coalesce.TaskListSample.Data.Models.OfficeAssignment", "InstructorID");
                });
        }
    }
}
