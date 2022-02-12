﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wep_ban_hang.Data;

namespace wep_ban_hang.Migrations
{
    [DbContext(typeof(wep_ban_hangContext))]
    partial class wep_ban_hangContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("wep_ban_hang.Areas.Admin.Models.cthoadon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("gia")
                        .HasColumnType("int");

                    b.Property<int>("hoadonid")
                        .HasColumnType("int");

                    b.Property<int>("sanphamid")
                        .HasColumnType("int");

                    b.Property<int>("soluong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("hoadonid");

                    b.HasIndex("sanphamid");

                    b.ToTable("cthoadon");
                });

            modelBuilder.Entity("wep_ban_hang.Areas.Admin.Models.ctsanpham", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("tenloaisanpham")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("trangthai")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("ctsanpham");
                });

            modelBuilder.Entity("wep_ban_hang.Areas.Admin.Models.giohang", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("sanphamid")
                        .HasColumnType("int");

                    b.Property<int>("soluong")
                        .HasColumnType("int");

                    b.Property<int>("taikhoanid")
                        .HasColumnType("int");

                    b.Property<bool>("trangthai")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("sanphamid");

                    b.HasIndex("taikhoanid");

                    b.ToTable("giohang");
                });

            modelBuilder.Entity("wep_ban_hang.Areas.Admin.Models.hoadon", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("diachi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mahd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("makh")
                        .HasColumnType("int");

                    b.Property<DateTime>("ngaylap")
                        .HasColumnType("datetime2");

                    b.Property<string>("sodt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("soluong")
                        .HasColumnType("int");

                    b.Property<int?>("taikhoanid")
                        .HasColumnType("int");

                    b.Property<int>("thanhtien")
                        .HasColumnType("int");

                    b.Property<bool>("trangthai")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("taikhoanid");

                    b.ToTable("hoadon");
                });

            modelBuilder.Entity("wep_ban_hang.Areas.Admin.Models.nhasanxuat", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("diachi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hinhanh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sdt")
                        .HasColumnType("int");

                    b.Property<string>("tennsx")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("trangthai")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("nhasanxuat");
                });

            modelBuilder.Entity("wep_ban_hang.Areas.Admin.Models.sanpham", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ctsanphamsid")
                        .HasColumnType("int");

                    b.Property<string>("danhgia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("gia")
                        .HasColumnType("int");

                    b.Property<string>("hinhanh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lspham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("nhasanxuatid")
                        .HasColumnType("int");

                    b.Property<string>("nsxuat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tensanpham")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("trangthai")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("ctsanphamsid");

                    b.HasIndex("nhasanxuatid");

                    b.ToTable("sanpham");
                });

            modelBuilder.Entity("wep_ban_hang.Areas.Admin.Models.taikhoan", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("diachi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("hinhanh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hoten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isadmin")
                        .HasColumnType("bit");

                    b.Property<string>("matkhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tendangnhap")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("trangthai")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("taikhoan");
                });

            modelBuilder.Entity("wep_ban_hang.Areas.Admin.Models.cthoadon", b =>
                {
                    b.HasOne("wep_ban_hang.Areas.Admin.Models.hoadon", "hoadons")
                        .WithMany("cthoadons")
                        .HasForeignKey("hoadonid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wep_ban_hang.Areas.Admin.Models.sanpham", "sanphams")
                        .WithMany("cthoadons")
                        .HasForeignKey("sanphamid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hoadons");

                    b.Navigation("sanphams");
                });

            modelBuilder.Entity("wep_ban_hang.Areas.Admin.Models.giohang", b =>
                {
                    b.HasOne("wep_ban_hang.Areas.Admin.Models.sanpham", "sanpham")
                        .WithMany("giohangs")
                        .HasForeignKey("sanphamid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wep_ban_hang.Areas.Admin.Models.taikhoan", "taikhoans")
                        .WithMany()
                        .HasForeignKey("taikhoanid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("sanpham");

                    b.Navigation("taikhoans");
                });

            modelBuilder.Entity("wep_ban_hang.Areas.Admin.Models.hoadon", b =>
                {
                    b.HasOne("wep_ban_hang.Areas.Admin.Models.taikhoan", "taikhoan")
                        .WithMany()
                        .HasForeignKey("taikhoanid");

                    b.Navigation("taikhoan");
                });

            modelBuilder.Entity("wep_ban_hang.Areas.Admin.Models.sanpham", b =>
                {
                    b.HasOne("wep_ban_hang.Areas.Admin.Models.ctsanpham", "ctsanphams")
                        .WithMany("sanphams")
                        .HasForeignKey("ctsanphamsid");

                    b.HasOne("wep_ban_hang.Areas.Admin.Models.nhasanxuat", "nhasanxuat")
                        .WithMany()
                        .HasForeignKey("nhasanxuatid");

                    b.Navigation("ctsanphams");

                    b.Navigation("nhasanxuat");
                });

            modelBuilder.Entity("wep_ban_hang.Areas.Admin.Models.ctsanpham", b =>
                {
                    b.Navigation("sanphams");
                });

            modelBuilder.Entity("wep_ban_hang.Areas.Admin.Models.hoadon", b =>
                {
                    b.Navigation("cthoadons");
                });

            modelBuilder.Entity("wep_ban_hang.Areas.Admin.Models.sanpham", b =>
                {
                    b.Navigation("cthoadons");

                    b.Navigation("giohangs");
                });
#pragma warning restore 612, 618
        }
    }
}
