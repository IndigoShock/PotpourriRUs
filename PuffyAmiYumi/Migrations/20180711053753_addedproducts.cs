using Microsoft.EntityFrameworkCore.Migrations;

namespace PuffyAmiYumi.Migrations
{
    public partial class addedproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "../asset/Geranium.jpg", 11.99m, "Karma-Patchouli-Potpourri", 100 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "../asset/RoseScented.jpg", 11.99m, "Karma-Rose-Potpourri", 100 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "../asset/VanillaScented.jpg", 11.99m, "Karma-Vanilla-Potpourri", 100 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "../asset/JasmineScented.jpg", 11.99m, "Karma-Jasmine-Potpourri", 100 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "../asset/Sandalwood.jpg", 11.99m, "Karma-Sandalwood-Potpourri", 100 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "../asset/Lavender.jpg", 11.99m, "Karma-Lavender-Potpourri", 100 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "../asset/SandalwoodSpice.jpg", 12.99m, "Esscents-Sandalwood-Spice-Potpourri", 100 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "../asset/Geranium.jpg", 12.99m, "Esscents-Geranium-Potpourri", 100 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "../asset/MorningBlossom.jpg", 12.99m, "Esscents-Morning-Blossom-Potpourri", 100 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "../asset/JasmineTea.jpg", 12.99m, "Esscents-Jasmine-Tea-Potpourri", 100 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "", 0m, "", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "", 0m, "", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "", 0m, "", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "", 0m, "", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "", 0m, "", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "", 0m, "", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "", 0m, "", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "", 0m, "", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "", 0m, "", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "ImageURL", "Price", "ProductName", "Stock" },
                values: new object[] { "", 0m, "", 0 });
        }
    }
}
