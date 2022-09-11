using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCHamburgerProjesi.Migrations
{
    public partial class ekstraId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EkstraId",
                table: "Siparis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EkstraId",
                table: "Siparis",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
