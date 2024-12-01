using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvisingAssistant.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseNumber",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Prerequisite1",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Prerequisite2",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseNumber",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Prerequisite1",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Prerequisite2",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Course");
        }
    }
}
