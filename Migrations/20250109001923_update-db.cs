using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeApi.Migrations
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfile_Faculty_FacultyId",
                table: "StudentProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfile_Major_MajorId",
                table: "StudentProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfile_StudentClass_StudentClassId",
                table: "StudentProfile");

            migrationBuilder.AlterColumn<int>(
                name: "StudentClassId",
                table: "StudentProfile",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MajorId",
                table: "StudentProfile",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FacultyId",
                table: "StudentProfile",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfile_Faculty_FacultyId",
                table: "StudentProfile",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfile_Major_MajorId",
                table: "StudentProfile",
                column: "MajorId",
                principalTable: "Major",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfile_StudentClass_StudentClassId",
                table: "StudentProfile",
                column: "StudentClassId",
                principalTable: "StudentClass",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfile_Faculty_FacultyId",
                table: "StudentProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfile_Major_MajorId",
                table: "StudentProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfile_StudentClass_StudentClassId",
                table: "StudentProfile");

            migrationBuilder.AlterColumn<int>(
                name: "StudentClassId",
                table: "StudentProfile",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MajorId",
                table: "StudentProfile",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FacultyId",
                table: "StudentProfile",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfile_Faculty_FacultyId",
                table: "StudentProfile",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfile_Major_MajorId",
                table: "StudentProfile",
                column: "MajorId",
                principalTable: "Major",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfile_StudentClass_StudentClassId",
                table: "StudentProfile",
                column: "StudentClassId",
                principalTable: "StudentClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
