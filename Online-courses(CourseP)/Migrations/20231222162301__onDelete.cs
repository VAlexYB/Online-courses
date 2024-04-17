using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_courses_CourseP_.Migrations
{
    /// <inheritdoc />
    public partial class _onDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_GroupID",
                table: "Lessons");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "ID",
                keyValue: "62C64EF0-D03A-4E61-97D3-D05AC21DAD14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "58e492a0-bab8-4f36-86f8-679cc4e00792", "AQAAAAIAAYagAAAAEC9k1sXDi1ZUlMAzCziKuO/AOZqNd3iE7/aJRSyLolVCl6JeVwcQ/At40M/U7uwmYw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_GroupID",
                table: "Lessons",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_GroupID",
                table: "Lessons");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "ID",
                keyValue: "62C64EF0-D03A-4E61-97D3-D05AC21DAD14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d67f3895-f5fb-4196-9859-986769e5a7f4", "AQAAAAIAAYagAAAAEBqjABVxLYXvIjAQOLbMi1JBCOJ+ke+5/wAMfWdHfERobWYBYIsC/aNb7Hje9p72lQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_GroupID",
                table: "Lessons",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
