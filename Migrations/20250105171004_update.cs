using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeApi.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarPath",
                table: "Admission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthCertificatePath",
                table: "Admission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CitizenIdentificationCardAfterPath",
                table: "Admission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CitizenIdentificationCardBeforPath",
                table: "Admission",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarPath",
                table: "Admission");

            migrationBuilder.DropColumn(
                name: "BirthCertificatePath",
                table: "Admission");

            migrationBuilder.DropColumn(
                name: "CitizenIdentificationCardAfterPath",
                table: "Admission");

            migrationBuilder.DropColumn(
                name: "CitizenIdentificationCardBeforPath",
                table: "Admission");
        }
    }
}
