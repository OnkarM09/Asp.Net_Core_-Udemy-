using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace New_Revision.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Power = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "MovieName", "Name", "Power", "Rank" },
                values: new object[] { 1, "Ironman", "Ironman", "Rich", 1 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Title" },
                values: new object[] { 1, "Ironman" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
