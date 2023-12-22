using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain;

public partial class SchoolDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) {}

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AffiliationAgreement> AffiliationAgreements { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<LessonType> LessonTypes { get; set; }

    public virtual DbSet<ResponsibilityAgreement> ResponsibilityAgreements { get; set; }

    public virtual DbSet<SkillLevel> SkillLevels { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Tutor> Tutors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "C782F5B4-C240-488D-9D48-C14721A72FF6",
            Name = "owner",
            NormalizedName = "OWNER"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "62C64EF0-D03A-4E61-97D3-D05AC21DAD14",
            UserName = "owner",
            NormalizedUserName = "OWNER",
            Email = "owner@email.com",
            NormalizedEmail = "OWNER@EMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "ownerPassword"),
            SecurityStamp = string.Empty
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "C782F5B4-C240-488D-9D48-C14721A72FF6",
            UserId = "62C64EF0-D03A-4E61-97D3-D05AC21DAD14"
        });

        modelBuilder.Entity<SchoolEntities.SystemUser>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(15);
            entity.Property(e => e.Patronymic).HasMaxLength(15);
            entity.Property(e => e.Surname).HasMaxLength(15);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Salary).HasColumnType("money");
            entity.Property(e => e.WorkExperience).HasColumnType("date");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(e => e.Obligation).HasColumnType("money");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("ID");
        });

        modelBuilder.Entity<AffiliationAgreement>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Group).WithMany(p => p.AffiliationAgreements)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AffiliationAgreements_GroupID");

            entity.HasOne(d => d.Student).WithMany(p => p.AffiliationAgreements)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AffiliationAgreements_StudentID");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.Name, "UQ__Categori__737584F646C24595").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Компьютерные науки"

            },
            new Category
            {
                Id = 2,
                Name = "Языки"

            },
            new Category
            {
                Id = 3,
                Name = "Социальные"

            });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasIndex(e => e.Name, "UQ__Courses__737584F665D5E82B").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Duration).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Skill).HasMaxLength(50);
            entity.Property(e => e.SkillLevelId)
                .HasDefaultValueSql("((1))")
                .HasColumnName("SkillLevelID");

            entity.HasOne(d => d.Admin).WithMany(p => p.Courses)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Courses_AdminID");

            entity.HasOne(d => d.Category).WithMany(p => p.Courses)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Courses_CategoryID");

            entity.HasOne(d => d.SkillLevel).WithMany(p => p.Courses)
                .HasForeignKey(d => d.SkillLevelId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Courses_SkillLevelID");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Beginning).HasColumnType("date");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Ending).HasColumnType("date");
            entity.Property(e => e.TutorId).HasColumnName("TutorID");

            entity.HasOne(d => d.Course).WithMany(p => p.Groups)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Groups_CourseID");

            entity.HasOne(d => d.Tutor).WithMany(p => p.Groups)
                .HasForeignKey(d => d.TutorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Groups_TutorID");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Beginning).HasColumnType("datetime");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.LessonTypeId).HasColumnName("LessonTypeID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Course).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Lessons_CourseID");

            entity.HasOne(d => d.Group).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Lessons_GroupID");

            entity.HasOne(d => d.LessonType).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.LessonTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Lessons_LessonTypeID");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Lessons_TeacherID");
        });

        modelBuilder.Entity<LessonType>(entity =>
        {
            entity.HasIndex(e => e.LessonType1, "UQ__LessonTy__37BD1F00FA5A85C0").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.LessonType1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LessonType");
        });

        modelBuilder.Entity<LessonType>().HasData(
            new LessonType
            {
                Id = 1,
                LessonType1 = "Лекция"
            },
            new LessonType
            {
                Id = 2,
                LessonType1 = "Практика"
            },
            new LessonType
            {
                Id = 3,
                LessonType1 = "Лабораторное занятие"
            },
            new LessonType
            {
                Id = 4,
                LessonType1 = "Семинар"
            });

        modelBuilder.Entity<ResponsibilityAgreement>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Course).WithMany(p => p.ResponsibilityAgreements)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ResponsibilityAgreements_CourseID");

            entity.HasOne(d => d.Teacher).WithMany(p => p.ResponsibilityAgreements)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ResponsibilityAgreements_TeacherID");
        });

        modelBuilder.Entity<SkillLevel>(entity =>
        {
            entity.HasIndex(e => e.SkillLevel1, "UQ__SkillLev__CC3A070146936DE4").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.SkillLevel1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SkillLevel");
        });

        modelBuilder.Entity<SkillLevel>().HasData(
            new SkillLevel
            {
                Id = 1,
                SkillLevel1 = "Начальный"
            },
            new SkillLevel
            {
                Id = 2,
                SkillLevel1 = "Продвинутый"
            },
            new SkillLevel
            {
                Id = 3,
                SkillLevel1 = "Профессиональный"
            });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("ID");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("ID");
        });

        modelBuilder.Entity<Tutor>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
