using Microsoft.EntityFrameworkCore.Migrations;

namespace PuffyAmiYumi.Migrations
{
    public partial class editIMG2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageURL",
                value: "~/wwwroot/asset/Geranium.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageURL",
                value: "~/assets/Geranium.jpg");
        }
    }
}
