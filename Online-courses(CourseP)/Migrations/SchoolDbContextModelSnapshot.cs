﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Online_courses_CourseP_.Domain;

#nullable disable

namespace Online_courses_CourseP_.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "C782F5B4-C240-488D-9D48-C14721A72FF6",
                            Name = "owner",
                            NormalizedName = "OWNER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ID");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = "62C64EF0-D03A-4E61-97D3-D05AC21DAD14",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "58e492a0-bab8-4f36-86f8-679cc4e00792",
                            Email = "owner@email.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "OWNER@EMAIL.COM",
                            NormalizedUserName = "OWNER",
                            PasswordHash = "AQAAAAIAAYagAAAAEC9k1sXDi1ZUlMAzCziKuO/AOZqNd3iE7/aJRSyLolVCl6JeVwcQ/At40M/U7uwmYw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "owner"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "62C64EF0-D03A-4E61-97D3-D05AC21DAD14",
                            RoleId = "C782F5B4-C240-488D-9D48-C14721A72FF6"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.AffiliationAgreement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GroupId")
                        .HasColumnType("int")
                        .HasColumnName("GroupID");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("StudentID");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("StudentId");

                    b.ToTable("AffiliationAgreements");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ__Categori__737584F646C24595")
                        .IsUnique();

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Компьютерные науки"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Языки"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Социальные"
                        });
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdminId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("AdminID");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<DateTime?>("Duration")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("Skill")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SkillLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SkillLevelID")
                        .HasDefaultValueSql("((1))");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SkillLevelId");

                    b.HasIndex(new[] { "Name" }, "UQ__Courses__737584F665D5E82B")
                        .IsUnique();

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Beginning")
                        .HasColumnType("date");

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<DateTime?>("Ending")
                        .HasColumnType("date");

                    b.Property<string>("TutorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("TutorID");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TutorId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Beginning")
                        .HasColumnType("datetime");

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("GroupId")
                        .HasColumnType("int")
                        .HasColumnName("GroupID");

                    b.Property<int>("LessonTypeId")
                        .HasColumnType("int")
                        .HasColumnName("LessonTypeID");

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("TeacherID");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("GroupId");

                    b.HasIndex("LessonTypeId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.LessonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LessonType1")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("LessonType");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "LessonType1" }, "UQ__LessonTy__37BD1F00FA5A85C0")
                        .IsUnique();

                    b.ToTable("LessonTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LessonType1 = "Лекция"
                        },
                        new
                        {
                            Id = 2,
                            LessonType1 = "Практика"
                        },
                        new
                        {
                            Id = 3,
                            LessonType1 = "Лабораторное занятие"
                        },
                        new
                        {
                            Id = 4,
                            LessonType1 = "Семинар"
                        });
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.ResponsibilityAgreement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("TeacherID");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("ResponsibilityAgreements");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.SkillLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SkillLevel1")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("SkillLevel");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "SkillLevel1" }, "UQ__SkillLev__CC3A070146936DE4")
                        .IsUnique();

                    b.ToTable("SkillLevels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SkillLevel1 = "Начальный"
                        },
                        new
                        {
                            Id = 2,
                            SkillLevel1 = "Продвинутый"
                        },
                        new
                        {
                            Id = 3,
                            SkillLevel1 = "Профессиональный"
                        });
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.SystemUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Name")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Surname")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasDiscriminator().HasValue("SystemUser");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Client", b =>
                {
                    b.HasBaseType("Online_courses_CourseP_.Domain.SchoolEntities.SystemUser");

                    b.Property<decimal?>("Obligation")
                        .HasColumnType("money");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Employee", b =>
                {
                    b.HasBaseType("Online_courses_CourseP_.Domain.SchoolEntities.SystemUser");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("money");

                    b.Property<DateTime?>("WorkExperience")
                        .HasColumnType("date");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Student", b =>
                {
                    b.HasBaseType("Online_courses_CourseP_.Domain.SchoolEntities.Client");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Admin", b =>
                {
                    b.HasBaseType("Online_courses_CourseP_.Domain.SchoolEntities.Employee");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Teacher", b =>
                {
                    b.HasBaseType("Online_courses_CourseP_.Domain.SchoolEntities.Employee");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Tutor", b =>
                {
                    b.HasBaseType("Online_courses_CourseP_.Domain.SchoolEntities.Employee");

                    b.HasDiscriminator().HasValue("Tutor");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.AffiliationAgreement", b =>
                {
                    b.HasOne("Online_courses_CourseP_.Domain.SchoolEntities.Group", "Group")
                        .WithMany("AffiliationAgreements")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_AffiliationAgreements_GroupID");

                    b.HasOne("Online_courses_CourseP_.Domain.SchoolEntities.Student", "Student")
                        .WithMany("AffiliationAgreements")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_AffiliationAgreements_StudentID");

                    b.Navigation("Group");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Course", b =>
                {
                    b.HasOne("Online_courses_CourseP_.Domain.SchoolEntities.Admin", "Admin")
                        .WithMany("Courses")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Courses_AdminID");

                    b.HasOne("Online_courses_CourseP_.Domain.SchoolEntities.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Courses_CategoryID");

                    b.HasOne("Online_courses_CourseP_.Domain.SchoolEntities.SkillLevel", "SkillLevel")
                        .WithMany("Courses")
                        .HasForeignKey("SkillLevelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Courses_SkillLevelID");

                    b.Navigation("Admin");

                    b.Navigation("Category");

                    b.Navigation("SkillLevel");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Group", b =>
                {
                    b.HasOne("Online_courses_CourseP_.Domain.SchoolEntities.Course", "Course")
                        .WithMany("Groups")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Groups_CourseID");

                    b.HasOne("Online_courses_CourseP_.Domain.SchoolEntities.Tutor", "Tutor")
                        .WithMany("Groups")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Groups_TutorID");

                    b.Navigation("Course");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Lesson", b =>
                {
                    b.HasOne("Online_courses_CourseP_.Domain.SchoolEntities.Course", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Lessons_CourseID");

                    b.HasOne("Online_courses_CourseP_.Domain.SchoolEntities.Group", "Group")
                        .WithMany("Lessons")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Lessons_GroupID");

                    b.HasOne("Online_courses_CourseP_.Domain.SchoolEntities.LessonType", "LessonType")
                        .WithMany("Lessons")
                        .HasForeignKey("LessonTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Lessons_LessonTypeID");

                    b.HasOne("Online_courses_CourseP_.Domain.SchoolEntities.Teacher", "Teacher")
                        .WithMany("Lessons")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Lessons_TeacherID");

                    b.Navigation("Course");

                    b.Navigation("Group");

                    b.Navigation("LessonType");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.ResponsibilityAgreement", b =>
                {
                    b.HasOne("Online_courses_CourseP_.Domain.SchoolEntities.Course", "Course")
                        .WithMany("ResponsibilityAgreements")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ResponsibilityAgreements_CourseID");

                    b.HasOne("Online_courses_CourseP_.Domain.SchoolEntities.Teacher", "Teacher")
                        .WithMany("ResponsibilityAgreements")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ResponsibilityAgreements_TeacherID");

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Category", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Course", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Lessons");

                    b.Navigation("ResponsibilityAgreements");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Group", b =>
                {
                    b.Navigation("AffiliationAgreements");

                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.LessonType", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.SkillLevel", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Student", b =>
                {
                    b.Navigation("AffiliationAgreements");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Admin", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Teacher", b =>
                {
                    b.Navigation("Lessons");

                    b.Navigation("ResponsibilityAgreements");
                });

            modelBuilder.Entity("Online_courses_CourseP_.Domain.SchoolEntities.Tutor", b =>
                {
                    b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}
