using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace wep_ban_hang.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ctsanpham",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenloaisanpham = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ctsanpham", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nhasanxuat",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tennsx = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    hinhanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sdt = table.Column<int>(type: "int", nullable: false),
                    trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhasanxuat", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "taikhoan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tendangnhap = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    matkhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hinhanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isadmin = table.Column<bool>(type: "bit", nullable: false),
                    trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taikhoan", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sanpham",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tensanpham = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    gia = table.Column<int>(type: "int", nullable: false),
                    danhgia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hinhanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lspham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ctsanphamsid = table.Column<int>(type: "int", nullable: true),
                    nsxuat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nhasanxuatid = table.Column<int>(type: "int", nullable: true),
                    trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanpham", x => x.id);
                    table.ForeignKey(
                        name: "FK_sanpham_ctsanpham_ctsanphamsid",
                        column: x => x.ctsanphamsid,
                        principalTable: "ctsanpham",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sanpham_nhasanxuat_nhasanxuatid",
                        column: x => x.nhasanxuatid,
                        principalTable: "nhasanxuat",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hoadon",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mahd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    makh = table.Column<int>(type: "int", nullable: false),
                    ngaylap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sodt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soluong = table.Column<int>(type: "int", nullable: false),
                    thanhtien = table.Column<int>(type: "int", nullable: false),
                    trangthai = table.Column<bool>(type: "bit", nullable: false),
                    taikhoanid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoadon", x => x.id);
                    table.ForeignKey(
                        name: "FK_hoadon_taikhoan_taikhoanid",
                        column: x => x.taikhoanid,
                        principalTable: "taikhoan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "giohang",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taikhoanid = table.Column<int>(type: "int", nullable: false),
                    sanphamid = table.Column<int>(type: "int", nullable: false),
                    soluong = table.Column<int>(type: "int", nullable: false),
                    trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_giohang", x => x.id);
                    table.ForeignKey(
                        name: "FK_giohang_sanpham_sanphamid",
                        column: x => x.sanphamid,
                        principalTable: "sanpham",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_giohang_taikhoan_taikhoanid",
                        column: x => x.taikhoanid,
                        principalTable: "taikhoan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cthoadon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoadonid = table.Column<int>(type: "int", nullable: false),
                    sanphamid = table.Column<int>(type: "int", nullable: false),
                    soluong = table.Column<int>(type: "int", nullable: false),
                    gia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cthoadon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cthoadon_hoadon_hoadonid",
                        column: x => x.hoadonid,
                        principalTable: "hoadon",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cthoadon_sanpham_sanphamid",
                        column: x => x.sanphamid,
                        principalTable: "sanpham",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cthoadon_hoadonid",
                table: "cthoadon",
                column: "hoadonid");

            migrationBuilder.CreateIndex(
                name: "IX_cthoadon_sanphamid",
                table: "cthoadon",
                column: "sanphamid");

            migrationBuilder.CreateIndex(
                name: "IX_giohang_sanphamid",
                table: "giohang",
                column: "sanphamid");

            migrationBuilder.CreateIndex(
                name: "IX_giohang_taikhoanid",
                table: "giohang",
                column: "taikhoanid");

            migrationBuilder.CreateIndex(
                name: "IX_hoadon_taikhoanid",
                table: "hoadon",
                column: "taikhoanid");

            migrationBuilder.CreateIndex(
                name: "IX_sanpham_ctsanphamsid",
                table: "sanpham",
                column: "ctsanphamsid");

            migrationBuilder.CreateIndex(
                name: "IX_sanpham_nhasanxuatid",
                table: "sanpham",
                column: "nhasanxuatid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cthoadon");

            migrationBuilder.DropTable(
                name: "giohang");

            migrationBuilder.DropTable(
                name: "hoadon");

            migrationBuilder.DropTable(
                name: "sanpham");

            migrationBuilder.DropTable(
                name: "taikhoan");

            migrationBuilder.DropTable(
                name: "ctsanpham");

            migrationBuilder.DropTable(
                name: "nhasanxuat");
        }
    }
}
