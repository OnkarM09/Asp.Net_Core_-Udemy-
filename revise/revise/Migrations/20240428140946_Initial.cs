using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace revise.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author" },
                values: new object[] { 1, "Maverick" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author" },
                values: new object[] { 2, "Elon Musk" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author" },
                values: new object[] { 3, "Akira Toriyama" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
