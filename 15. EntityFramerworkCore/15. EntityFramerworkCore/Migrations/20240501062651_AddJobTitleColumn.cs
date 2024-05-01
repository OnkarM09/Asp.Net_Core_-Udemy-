using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _15._EntityFramerworkCore.Migrations
{
    public partial class AddJobTitleColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobDetailsJobTitle",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Persons",
                type: "nvarchar(max)",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Persons");
        }
    }
}
