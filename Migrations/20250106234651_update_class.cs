using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeApi.Migrations
{
    /// <inheritdoc />
    public partial class update_class : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "StudentClass",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MajorId",
                table: "StudentClass",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "StudentClass",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "StudentClass");

            migrationBuilder.DropColumn(
                name: "MajorId",
                table: "StudentClass");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "StudentClass");
        }
    }
}
