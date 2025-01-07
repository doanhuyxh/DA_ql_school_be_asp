using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeApi.Migrations
{
    /// <inheritdoc />
    public partial class update_faculty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MajorId",
                table: "Faculty",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MajorId",
                table: "Faculty");
        }
    }
}
