﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using University_of_SL.Data;
using University_of_SL.Models;

namespace University_of_SL.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("University_of_SL.Models.Course", b =>
                {
                    b.Property<int>("CourseID");

                    b.Property<int>("Credits");

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.Property<int>("departmentID");

                    b.HasKey("CourseID");

                    b.HasIndex("departmentID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("University_of_SL.Models.CourseAssignment", b =>
                {
                    b.Property<int>("CourseID");

                    b.Property<int>("InstructorID");

                    b.HasKey("CourseID", "InstructorID");

                    b.HasIndex("InstructorID");

                    b.ToTable("CourseAssignment");
                });

            modelBuilder.Entity("University_of_SL.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Budget")
                        .HasColumnType("Money");

                    b.Property<int?>("InstructorID");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<DateTime>("StartDate");

                    b.HasKey("DepartmentID");

                    b.HasIndex("InstructorID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("University_of_SL.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseID");

                    b.Property<int?>("Grade");

                    b.Property<int>("StudentID");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("University_of_SL.Models.Instructor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("First Name")
                        .HasMaxLength(25);

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("ID");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("University_of_SL.Models.OfficeAssignment", b =>
                {
                    b.Property<int>("InstructorID");

                    b.Property<string>("Location")
                        .HasMaxLength(50);

                    b.HasKey("InstructorID");

                    b.ToTable("OfficeAssignment");
                });

            modelBuilder.Entity("University_of_SL.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnName("First_Name")
                        .HasMaxLength(20);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("University_of_SL.Models.Course", b =>
                {
                    b.HasOne("University_of_SL.Models.Department", "department")
                        .WithMany("Courses")
                        .HasForeignKey("departmentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("University_of_SL.Models.CourseAssignment", b =>
                {
                    b.HasOne("University_of_SL.Models.Course", "Course")
                        .WithMany("courseAssignments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("University_of_SL.Models.Instructor", "Instructor")
                        .WithMany("courseAssignments")
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("University_of_SL.Models.Department", b =>
                {
                    b.HasOne("University_of_SL.Models.Instructor", "Administrator")
                        .WithMany()
                        .HasForeignKey("InstructorID");
                });

            modelBuilder.Entity("University_of_SL.Models.Enrollment", b =>
                {
                    b.HasOne("University_of_SL.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("University_of_SL.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("University_of_SL.Models.OfficeAssignment", b =>
                {
                    b.HasOne("University_of_SL.Models.Instructor", "instructor")
                        .WithOne("officeAssignment")
                        .HasForeignKey("University_of_SL.Models.OfficeAssignment", "InstructorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
