using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _15._EntityFramerworkCore.Migrations
{
    public partial class InsertPerson_StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_InsertPerson = @"
                    CREATE PROCEDURE [dbo].[InsertPerson]
                    (@Name nvarchar(40), @Email nvarchar(40), @Age int, @BirthDate dateTime2(7))
                    AS BEGIN
                    INSERT INTO [dbo].[PERSONS](Name, Email, Age, BirthDate) VALUES (@Name, @Email, @Age, @BirthDate)
                    END
                    ";
            migrationBuilder.Sql(sp_InsertPerson);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_InsertPerson = @"
                    DROP PROCEDURE [dbo].[InsertPerson]";
            migrationBuilder.Sql(sp_InsertPerson);
        }
    }
}
