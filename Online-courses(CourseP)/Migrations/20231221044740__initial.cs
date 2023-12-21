using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Online_courses_CourseP_.Migrations
{
    /// <inheritdoc />
    public partial class _initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Obligation = table.Column<decimal>(type: "money", nullable: true),
                    WorkExperience = table.Column<DateTime>(type: "date", nullable: true),
                    Salary = table.Column<decimal>(type: "money", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LessonTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SkillLevels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillLevel = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLevels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SkillLevelID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    Duration = table.Column<DateTime>(type: "date", nullable: true),
                    AdminID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Courses_AdminID",
                        column: x => x.AdminID,
                        principalTable: "AspNetUsers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Courses_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Courses_SkillLevelID",
                        column: x => x.SkillLevelID,
                        principalTable: "SkillLevels",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beginning = table.Column<DateTime>(type: "date", nullable: true),
                    Ending = table.Column<DateTime>(type: "date", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    TutorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Groups_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Groups_TutorID",
                        column: x => x.TutorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ResponsibilityAgreements",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsibilityAgreements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ResponsibilityAgreements_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ResponsibilityAgreements_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "AspNetUsers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AffiliationAgreements",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliationAgreements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AffiliationAgreements_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AffiliationAgreements_StudentID",
                        column: x => x.StudentID,
                        principalTable: "AspNetUsers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    LessonTypeID = table.Column<int>(type: "int", nullable: false),
                    Beginning = table.Column<DateTime>(type: "datetime", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lessons_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Lessons_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Lessons_LessonTypeID",
                        column: x => x.LessonTypeID,
                        principalTable: "LessonTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Lessons_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "AspNetUsers",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "C782F5B4-C240-488D-9D48-C14721A72FF6", null, "owner", "OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "ID", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "62C64EF0-D03A-4E61-97D3-D05AC21DAD14", 0, "86b756de-c57b-4e61-9990-d171fd23e9b2", "IdentityUser", "owner@email.com", true, false, null, "OWNER@EMAIL.COM", "OWNER", "AQAAAAIAAYagAAAAEKeaLu1bGs+XvuYn79S2lgZwdbngjOPqWc1PY4BEgtxFAeJjtYMAQlyXw341V8TP4A==", null, false, "", false, "owner" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Компьютерные науки" },
                    { 2, "Языки" },
                    { 3, "Социальные" }
                });

            migrationBuilder.InsertData(
                table: "LessonTypes",
                columns: new[] { "ID", "LessonType" },
                values: new object[,]
                {
                    { 1, "Лекция" },
                    { 2, "Практика" },
                    { 3, "Лабораторное занятие" },
                    { 4, "Семинар" }
                });

            migrationBuilder.InsertData(
                table: "SkillLevels",
                columns: new[] { "ID", "SkillLevel" },
                values: new object[,]
                {
                    { 1, "Начальный" },
                    { 2, "Продвинутый" },
                    { 3, "Профессиональный" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "C782F5B4-C240-488D-9D48-C14721A72FF6", "62C64EF0-D03A-4E61-97D3-D05AC21DAD14" });

            migrationBuilder.CreateIndex(
                name: "IX_AffiliationAgreements_GroupID",
                table: "AffiliationAgreements",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_AffiliationAgreements_StudentID",
                table: "AffiliationAgreements",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Categori__737584F646C24595",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AdminID",
                table: "Courses",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryID",
                table: "Courses",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SkillLevelID",
                table: "Courses",
                column: "SkillLevelID");

            migrationBuilder.CreateIndex(
                name: "UQ__Courses__737584F665D5E82B",
                table: "Courses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CourseID",
                table: "Groups",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TutorID",
                table: "Groups",
                column: "TutorID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseID",
                table: "Lessons",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_GroupID",
                table: "Lessons",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LessonTypeID",
                table: "Lessons",
                column: "LessonTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherID",
                table: "Lessons",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "UQ__LessonTy__37BD1F00FA5A85C0",
                table: "LessonTypes",
                column: "LessonType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResponsibilityAgreements_CourseID",
                table: "ResponsibilityAgreements",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsibilityAgreements_TeacherID",
                table: "ResponsibilityAgreements",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "UQ__SkillLev__CC3A070146936DE4",
                table: "SkillLevels",
                column: "SkillLevel",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AffiliationAgreements");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "ResponsibilityAgreements");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "LessonTypes");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "SkillLevels");
        }
    }
}
