using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _15._EntityFramerworkCore.Migrations
{
    public partial class GenderColumnRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Persons",
                newName: "PersonGender");

            migrationBuilder.AlterColumn<string>(
                name: "PersonGender",
                table: "Persons",
                type: "varchar(8)",
                nullable: true,
                defaultValue: "Male",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonGender",
                table: "Persons",
                newName: "Gender");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Male",
                oldNullable: true);
        }
    }
}
