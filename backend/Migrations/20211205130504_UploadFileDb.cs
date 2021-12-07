using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace way.Migrations
{
    public partial class UploadFileDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Movies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
