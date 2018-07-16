using Microsoft.EntityFrameworkCore.Migrations;

namespace PuffyAmiYumi.Migrations
{
    public partial class editIMG3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageURL",
                value: "asset/Patchouli.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImageURL",
                value: "asset/RoseScented.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageURL",
                value: "asset/VanillaScented.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImageURL",
                value: "asset/JasmineScented.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImageURL",
                value: "asset/Sandalwood.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                column: "ImageURL",
                value: "asset/Lavender.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                column: "ImageURL",
                value: "asset/SandalwoodSpice.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                column: "ImageURL",
                value: "asset/Geranium.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                column: "ImageURL",
                value: "asset/MorningBlossom.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                column: "ImageURL",
                value: "asset/JasmineTea.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageURL",
                value: "~/wwwroot/asset/Geranium.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImageURL",
                value: "~/asset/RoseScented.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageURL",
                value: "~/asset/VanillaScented.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImageURL",
                value: "~/asset/JasmineScented.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImageURL",
                value: "~/asset/Sandalwood.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                column: "ImageURL",
                value: "~/asset/Lavender.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                column: "ImageURL",
                value: "~/asset/SandalwoodSpice.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                column: "ImageURL",
                value: "~/asset/Geranium.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                column: "ImageURL",
                value: "~/asset/MorningBlossom.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                column: "ImageURL",
                value: "~/asset/JasmineTea.jpg");
        }
    }
}
