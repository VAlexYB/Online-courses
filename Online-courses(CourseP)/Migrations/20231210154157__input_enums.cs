using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Online_courses_CourseP_.Migrations
{
    /// <inheritdoc />
    public partial class _input_enums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "ID",
                keyValue: "62C64EF0-D03A-4E61-97D3-D05AC21DAD14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "217b808f-5268-404c-9f87-007917450238", "AQAAAAIAAYagAAAAEIIDMErKtU+SNECGDSBqqSyj+sVbHTjuQfScDIXvsGmBmz5pENVQ24AbLPwqpUDncQ==" });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SkillLevels",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SkillLevels",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SkillLevels",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "ID",
                keyValue: "62C64EF0-D03A-4E61-97D3-D05AC21DAD14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6c32fedb-04b7-4f92-9794-d0e1b71bfe2c", "AQAAAAIAAYagAAAAEPIhMkfxKgIEfsbjx4ei6kIIWBLF0ayfRpSE0RRMlIYn2qwQ03qlNPZLTIWizqpaWA==" });
        }
    }
}
