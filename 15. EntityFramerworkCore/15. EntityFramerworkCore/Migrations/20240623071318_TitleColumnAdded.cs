using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _15._EntityFramerworkCore.Migrations
{
    public partial class TitleColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_JobDetails_JobDetailsJobTitle",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_JobDetailsJobTitle",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "JobDetailsJobTitle",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_JobTitle",
                table: "Persons",
                column: "JobTitle");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_JobDetails_JobTitle",
                table: "Persons",
                column: "JobTitle",
                principalTable: "JobDetails",
                principalColumn: "JobTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_JobDetails_JobTitle",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_JobTitle",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobDetailsJobTitle",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_JobDetailsJobTitle",
                table: "Persons",
                column: "JobDetailsJobTitle");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_JobDetails_JobDetailsJobTitle",
                table: "Persons",
                column: "JobDetailsJobTitle",
                principalTable: "JobDetails",
                principalColumn: "JobTitle");
        }
    }
}
