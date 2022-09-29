using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _20220929_Querying.Migrations
{
    public partial class add_parcalarClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcalar_Urunler_UrunId",
                table: "Parcalar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Urunler",
                table: "Urunler");

            migrationBuilder.RenameTable(
                name: "Urunler",
                newName: "Urunlerim");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Urunlerim",
                table: "Urunlerim",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcalar_Urunlerim_UrunId",
                table: "Parcalar",
                column: "UrunId",
                principalTable: "Urunlerim",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcalar_Urunlerim_UrunId",
                table: "Parcalar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Urunlerim",
                table: "Urunlerim");

            migrationBuilder.RenameTable(
                name: "Urunlerim",
                newName: "Urunler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Urunler",
                table: "Urunler",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcalar_Urunler_UrunId",
                table: "Parcalar",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "Id");
        }
    }
}
