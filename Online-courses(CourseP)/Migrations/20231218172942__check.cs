using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_courses_CourseP_.Migrations
{
    /// <inheritdoc />
    public partial class _check : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "ID",
                keyValue: "62C64EF0-D03A-4E61-97D3-D05AC21DAD14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2a4c5218-6a02-43db-ae54-d95851c05144", "AQAAAAIAAYagAAAAEE1z+tJiR4l+4juscvclWUNMf2EDsAWHOprxBjUDcKYsI0hTktbAnjqHk8F8M5L2Ag==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "ID",
                keyValue: "62C64EF0-D03A-4E61-97D3-D05AC21DAD14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "217b808f-5268-404c-9f87-007917450238", "AQAAAAIAAYagAAAAEIIDMErKtU+SNECGDSBqqSyj+sVbHTjuQfScDIXvsGmBmz5pENVQ24AbLPwqpUDncQ==" });
        }
    }
}
