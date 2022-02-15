using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QLPM.Models;

#nullable disable

namespace QLPM.Data
{
    public partial class QLPhanMemContext : DbContext
    {
        public QLPhanMemContext()
        {
        }

        public QLPhanMemContext(DbContextOptions<QLPhanMemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BaoTri> BaoTris { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DatHang> DatHangs { get; set; }
        public virtual DbSet<DatHangChiTiet> DatHangChiTiets { get; set; }
        public virtual DbSet<DungThu> DungThus { get; set; }
        public virtual DbSet<HuongDan> HuongDans { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ADMIN\\SQLEXPRESS;Database=QLPhanMem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DatHang>(entity =>
            {
                entity.HasOne(d => d.KhachHang)
                    .WithMany(p => p.DatHangs)
                    .HasForeignKey(d => d.KhachHangId)
                    .HasConstraintName("FK__DatHang__KhachHa__22AA2996");

                entity.HasOne(d => d.NhanVien)
                    .WithMany(p => p.DatHangs)
                    .HasForeignKey(d => d.NhanVienId)
                    .HasConstraintName("FK__DatHang__NhanVie__21B6055D");
            });

            modelBuilder.Entity<DatHangChiTiet>(entity =>
            {
                entity.HasOne(d => d.DatHang)
                    .WithMany(p => p.DatHangChiTiets)
                    .HasForeignKey(d => d.DatHangId)
                    .HasConstraintName("FK__DatHangCh__DatHa__25869641");

                entity.HasOne(d => d.SanPham)
                    .WithMany(p => p.DatHangChiTiets)
                    .HasForeignKey(d => d.SanPhamId)
                    .HasConstraintName("FK__DatHangCh__SanPh__267ABA7A");
            });

            modelBuilder.Entity<DungThu>(entity =>
            {
                entity.HasOne(d => d.SanPham)
                    .WithMany(p => p.DungThus)
                    .HasForeignKey(d => d.SanPhamId)
                    .HasConstraintName("FK__DungThu__ThoiGia__1B0907CE");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasOne(d => d.BaoTri)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.BaoTriId)
                    .HasConstraintName("FK__SanPham__BaoTriI__182C9B23");

                entity.HasOne(d => d.DanhMuc)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.DanhMucId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SanPham__DanhMuc__173876EA");

                entity.HasOne(d => d.HuongDan)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.HuongDanId)
                    .HasConstraintName("FK__SanPham__HuongDa__164452B1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
