using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdvisingAssistant.Data.Migrations
{
    /// <inheritdoc />
    public partial class schedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DegreePlans",
                columns: new[] { "Id", "Major" },
                values: new object[,]
                {
                    { 1, "English" },
                    { 2, "Computer Science" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DegreePlans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DegreePlans",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
