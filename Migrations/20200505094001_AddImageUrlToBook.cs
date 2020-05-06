using Microsoft.EntityFrameworkCore.Migrations;

namespace BookDownloader.Migrations
{
    public partial class AddImageUrlToBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "books");
        }
    }
}
