using Microsoft.EntityFrameworkCore.Migrations;

namespace wep_ban_hang.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "banner",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenquangcao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    hinhanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banner", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "banner");
        }
    }
}
