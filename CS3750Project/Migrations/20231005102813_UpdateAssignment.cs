using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS3750Project.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAssignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Assignment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_ClassId",
                table: "Assignment",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Class_ClassId",
                table: "Assignment",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Class_ClassId",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_ClassId",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Assignment");
        }
    }
}
