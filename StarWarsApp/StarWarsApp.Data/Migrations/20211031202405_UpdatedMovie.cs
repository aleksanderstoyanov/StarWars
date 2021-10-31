using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWars.Migrations
{
    public partial class UpdatedMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Moviews",
                table: "Moviews");

            migrationBuilder.RenameTable(
                name: "Moviews",
                newName: "Movies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Moviews");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Moviews",
                table: "Moviews",
                column: "Id");
        }
    }
}
