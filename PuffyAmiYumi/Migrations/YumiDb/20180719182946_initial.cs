using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuffyAmiYumi.Migrations.YumiDb
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CartID = table.Column<int>(nullable: false),
                    Purchased = table.Column<bool>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserTag = table.Column<string>(nullable: true),
                    CheckedOut = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    SKU = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "ImageURL", "Price", "ProductName", "SKU", "Stock" },
                values: new object[,]
                {
                    { 1, "asset/Patchouli.jpg", 11.99m, "Karma-Patchouli-Potpourri", null, 100 },
                    { 2, "asset/RoseScented.jpg", 11.99m, "Karma-Rose-Potpourri", null, 100 },
                    { 3, "asset/VanillaScented.jpg", 11.99m, "Karma-Vanilla-Potpourri", null, 100 },
                    { 4, "asset/JasmineScented.jpg", 11.99m, "Karma-Jasmine-Potpourri", null, 100 },
                    { 5, "asset/Sandalwood.jpg", 11.99m, "Karma-Sandalwood-Potpourri", null, 100 },
                    { 6, "asset/Lavender.jpg", 11.99m, "Karma-Lavender-Potpourri", null, 100 },
                    { 7, "asset/SandalwoodSpice.jpg", 12.99m, "Esscents-Sandalwood-Spice-Potpourri", null, 100 },
                    { 8, "asset/Geranium.jpg", 12.99m, "Esscents-Geranium-Potpourri", null, 100 },
                    { 9, "asset/MorningBlossom.jpg", 12.99m, "Esscents-Morning-Blossom-Potpourri", null, 100 },
                    { 10, "asset/JasmineTea.jpg", 12.99m, "Esscents-Jasmine-Tea-Potpourri", null, 100 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
