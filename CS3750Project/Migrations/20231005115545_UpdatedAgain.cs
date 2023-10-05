using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS3750Project.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateDue",
                table: "Assignment",
                newName: "DayDue");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeDue",
                table: "Assignment",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeDue",
                table: "Assignment");

            migrationBuilder.RenameColumn(
                name: "DayDue",
                table: "Assignment",
                newName: "DateDue");
        }
    }
}
