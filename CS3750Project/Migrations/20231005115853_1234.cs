using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS3750Project.Migrations
{
    /// <inheritdoc />
    public partial class _1234 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeDue",
                table: "Assignment",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "DayDue",
                table: "Assignment",
                newName: "Day");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Assignment",
                newName: "TimeDue");

            migrationBuilder.RenameColumn(
                name: "Day",
                table: "Assignment",
                newName: "DayDue");
        }
    }
}
