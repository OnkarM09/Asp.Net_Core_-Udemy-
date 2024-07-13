using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace New_Revision.Migrations
{
    public partial class TitleColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "MovieName",
                table: "Heroes",
                newName: "Title");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_Title",
                table: "Heroes",
                column: "Title");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Movies_Title",
                table: "Heroes",
                column: "Title",
                principalTable: "Movies",
                principalColumn: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Movies_Title",
                table: "Heroes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_Title",
                table: "Heroes");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Heroes",
                newName: "MovieName");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "MovieId");
        }
    }
}
