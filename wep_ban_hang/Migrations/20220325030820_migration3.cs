using Microsoft.EntityFrameworkCore.Migrations;

namespace wep_ban_hang.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "soluong",
                table: "hoadon");

            migrationBuilder.AddColumn<int>(
                name: "soluong",
                table: "sanpham",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "soluong",
                table: "sanpham");

            migrationBuilder.AddColumn<int>(
                name: "soluong",
                table: "hoadon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
