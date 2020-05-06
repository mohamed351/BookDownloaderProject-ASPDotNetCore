using Microsoft.EntityFrameworkCore.Migrations;

namespace BookDownloader.Migrations
{
    public partial class AddBookInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookUrl",
                table: "books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookUrl",
                table: "books");
        }
    }
}
