using Microsoft.EntityFrameworkCore.Migrations;

namespace FlagApp.Migrations
{
    public partial class ImageUrlstring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flags",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "154-turkey.png");

            migrationBuilder.UpdateData(
                table: "Flags",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "199-argentina.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flags",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flags",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: null);
        }
    }
}
