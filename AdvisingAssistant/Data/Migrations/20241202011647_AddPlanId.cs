using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvisingAssistant.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPlanId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_DegreePlans_DegreePlanId",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "DegreePlanId",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_DegreePlans_DegreePlanId",
                table: "Course",
                column: "DegreePlanId",
                principalTable: "DegreePlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_DegreePlans_DegreePlanId",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "DegreePlanId",
                table: "Course",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_DegreePlans_DegreePlanId",
                table: "Course",
                column: "DegreePlanId",
                principalTable: "DegreePlans",
                principalColumn: "Id");
        }
    }
}
