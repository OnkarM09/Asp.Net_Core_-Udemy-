using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _15._EntityFramerworkCore.Migrations
{
    public partial class JobDetailsTableAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobDetails",
                columns: table => new
                {
                    JobTitle = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDetails", x => x.JobTitle);
                });

            migrationBuilder.InsertData(
                table: "JobDetails",
                columns: new[] { "JobTitle", "Salary" },
                values: new object[,]
                {
                    { "Back-End Developer", 899999.0 },
                    { "Database Developer", 799999.0 },
                    { "Front-End Developer", 999999.0 },
                    { "Full Stack Developer", 99999999999.0 },
                    { "Graphic Designer", 599999.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobDetails");
        }
    }
}
