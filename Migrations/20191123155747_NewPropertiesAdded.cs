using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiService.Migrations
{
    public partial class NewPropertiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CharacterId",
                table: "Ratings",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "MaxRating",
                table: "Ratings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "MaxRating",
                table: "Ratings");
        }
    }
}
