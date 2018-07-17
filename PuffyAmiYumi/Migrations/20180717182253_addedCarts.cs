using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuffyAmiYumi.Migrations
{
    public partial class addedCarts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserEmail = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CartID = table.Column<int>(nullable: false),
                    Purchased = table.Column<bool>(nullable: false),
                    ProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CartItem_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartID",
                table: "CartItem",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductID",
                table: "CartItem",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
