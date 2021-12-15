using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWars.Migrations
{
    public partial class AddedIsDeletedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Characters",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Characters");
        }
    }
}
