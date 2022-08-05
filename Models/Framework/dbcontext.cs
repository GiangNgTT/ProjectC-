using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.Framework
{
    public partial class dbcontext : DbContext
    {
        public dbcontext()
            : base("name=dbcontext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<ChiTietDatHang> ChiTietDatHangs { get; set; }
        public virtual DbSet<ChuDe> ChuDes { get; set; }
        public virtual DbSet<DonDatHang> DonDatHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<VietSach> VietSaches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.UserAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.PassAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDatHang>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonDatHang>()
                .HasMany(e => e.ChiTietDatHangs)
                .WithRequired(e => e.DonDatHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhaXuatBan>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.GiaBan)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sach>()
                .Property(e => e.AnhBia)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.ChiTietDatHangs)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TacGia>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<TacGia>()
                .HasOptional(e => e.VietSach)
                .WithRequired(e => e.TacGia);
        }
    }
}
