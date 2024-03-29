﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backendf8.Models;

namespace backendf8.Migrations
{
    [DbContext(typeof(MasterDbContext))]
    [Migration("20220807110006_initDb")]
    partial class initDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ApplicationUserCourse", b =>
                {
                    b.Property<Guid>("ApplicationUsersId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CoursesID")
                        .HasColumnType("uuid");

                    b.HasKey("ApplicationUsersId", "CoursesID");

                    b.HasIndex("CoursesID");

                    b.ToTable("ApplicationUserCourse");
                });

            modelBuilder.Entity("CombinedCourseCourse", b =>
                {
                    b.Property<Guid>("CombinedCoursesID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CoursesID")
                        .HasColumnType("uuid");

                    b.HasKey("CombinedCoursesID", "CoursesID");

                    b.HasIndex("CoursesID");

                    b.ToTable("CombinedCourseCourse");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("backendf8.Models.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("backendf8.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("backendf8.Models.CombinedCourse", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("image_url")
                        .HasColumnType("text");

                    b.Property<string>("slug")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("CombinedCourses");
                });

            modelBuilder.Entity("backendf8.Models.Course", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("icon")
                        .HasColumnType("text");

                    b.Property<string>("icon_url")
                        .HasColumnType("text");

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("image_url")
                        .HasColumnType("text");

                    b.Property<bool>("is_coming_soon")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_pre_order")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_pro")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_published")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_registered")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_selling")
                        .HasColumnType("boolean");

                    b.Property<string>("last_completed_at")
                        .HasColumnType("text");

                    b.Property<int>("price")
                        .HasColumnType("integer");

                    b.Property<string>("related_course")
                        .HasColumnType("text");

                    b.Property<string>("slug")
                        .HasColumnType("text");

                    b.Property<int>("student_course")
                        .HasColumnType("integer");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.Property<int>("user_progress")
                        .HasColumnType("integer");

                    b.Property<string>("video")
                        .HasColumnType("text");

                    b.Property<string>("video_type")
                        .HasColumnType("text");

                    b.Property<string>("video_url")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("backendf8.Models.Lesson", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("Continue_ID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Course_Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Course_progress")
                        .HasColumnType("integer");

                    b.Property<Guid?>("CoursesID")
                        .HasColumnType("uuid");

                    b.Property<bool>("End_of_course")
                        .HasColumnType("boolean");

                    b.Property<bool>("End_of_free")
                        .HasColumnType("boolean");

                    b.Property<bool>("has_end_time_logging")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_completed")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_logged")
                        .HasColumnType("boolean");

                    b.Property<Guid>("last_step_id")
                        .HasColumnType("uuid");

                    b.Property<string>("learning_log")
                        .HasColumnType("text");

                    b.Property<Guid>("next_id")
                        .HasColumnType("uuid");

                    b.Property<int>("pass_percent")
                        .HasColumnType("integer");

                    b.Property<string>("track_step")
                        .HasColumnType("text");

                    b.Property<string>("user_solutions")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("CoursesID");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("ApplicationUserCourse", b =>
                {
                    b.HasOne("backendf8.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("ApplicationUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backendf8.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CombinedCourseCourse", b =>
                {
                    b.HasOne("backendf8.Models.CombinedCourse", null)
                        .WithMany()
                        .HasForeignKey("CombinedCoursesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backendf8.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("backendf8.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("backendf8.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("backendf8.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("backendf8.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backendf8.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("backendf8.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backendf8.Models.Lesson", b =>
                {
                    b.HasOne("backendf8.Models.Course", "Courses")
                        .WithMany("Lessions")
                        .HasForeignKey("CoursesID");

                    b.Navigation("Courses");
                });

            modelBuilder.Entity("backendf8.Models.Course", b =>
                {
                    b.Navigation("Lessions");
                });
#pragma warning restore 612, 618
        }
    }
}
