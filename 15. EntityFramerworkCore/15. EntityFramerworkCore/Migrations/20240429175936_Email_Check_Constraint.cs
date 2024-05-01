using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _15._EntityFramerworkCore.Migrations
{
    public partial class Email_Check_Constraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CHK_Email",
                table: "Persons",
                sql: "len(Email) > 5");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_Email",
                table: "Persons");
        }
    }
}
