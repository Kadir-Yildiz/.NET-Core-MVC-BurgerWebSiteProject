using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCHamburgerProjesi.Migrations
{
    public partial class menuId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siparisler_Menuler_SeciliMenuId",
                table: "Siparisler");

            migrationBuilder.DropIndex(
                name: "IX_Siparisler_SeciliMenuId",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "SeciliMenuId",
                table: "Siparisler");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Siparisler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_MenuId",
                table: "Siparisler",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Siparisler_Menuler_MenuId",
                table: "Siparisler",
                column: "MenuId",
                principalTable: "Menuler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siparisler_Menuler_MenuId",
                table: "Siparisler");

            migrationBuilder.DropIndex(
                name: "IX_Siparisler_MenuId",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Siparisler");

            migrationBuilder.AddColumn<int>(
                name: "SeciliMenuId",
                table: "Siparisler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_SeciliMenuId",
                table: "Siparisler",
                column: "SeciliMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Siparisler_Menuler_SeciliMenuId",
                table: "Siparisler",
                column: "SeciliMenuId",
                principalTable: "Menuler",
                principalColumn: "Id");
        }
    }
}
