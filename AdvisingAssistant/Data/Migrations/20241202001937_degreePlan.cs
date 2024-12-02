using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvisingAssistant.Data.Migrations
{
    /// <inheritdoc />
    public partial class degreePlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DegreePlanId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DegreePlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreePlans", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_DegreePlanId",
                table: "Course",
                column: "DegreePlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_DegreePlans_DegreePlanId",
                table: "Course",
                column: "DegreePlanId",
                principalTable: "DegreePlans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_DegreePlans_DegreePlanId",
                table: "Course");

            migrationBuilder.DropTable(
                name: "DegreePlans");

            migrationBuilder.DropIndex(
                name: "IX_Course_DegreePlanId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "DegreePlanId",
                table: "Course");
        }
    }
}
