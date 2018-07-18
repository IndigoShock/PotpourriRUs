using Microsoft.EntityFrameworkCore.Migrations;

namespace PuffyAmiYumi.Migrations
{
    public partial class addedUserID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Carts_CartID",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_CartID",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Carts",
                newName: "UserID");

            migrationBuilder.AlterColumn<string>(
                name: "CartID",
                table: "CartItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CartID1",
                table: "CartItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartID1",
                table: "CartItem",
                column: "CartID1");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Carts_CartID1",
                table: "CartItem",
                column: "CartID1",
                principalTable: "Carts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Carts_CartID1",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_CartID1",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "CartID1",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Carts",
                newName: "UserEmail");

            migrationBuilder.AlterColumn<int>(
                name: "CartID",
                table: "CartItem",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartID",
                table: "CartItem",
                column: "CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Carts_CartID",
                table: "CartItem",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
