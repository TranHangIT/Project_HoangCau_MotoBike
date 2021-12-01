using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LayoutNhom08.Models
{
    public partial class ShopMotoBikes : DbContext
    {
        public ShopMotoBikes()
            : base("name=ShopMotoBikes")
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<Hang> Hangs { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.Hangs)
                .WithRequired(e => e.DanhMuc)
                .HasForeignKey(e => e.MaDM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.Hangs1)
                .WithRequired(e => e.DanhMuc1)
                .HasForeignKey(e => e.MaDM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.Hangs2)
                .WithRequired(e => e.DanhMuc2)
                .HasForeignKey(e => e.MaDM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.DonHang)
                .HasForeignKey(e => e.MaDH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHangs1)
                .WithRequired(e => e.DonHang1)
                .HasForeignKey(e => e.MaDH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHangs2)
                .WithRequired(e => e.DonHang2)
                .HasForeignKey(e => e.MaDH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hang>()
                .Property(e => e.GiaTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hang>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.Hang)
                .HasForeignKey(e => e.MaHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hang>()
                .HasMany(e => e.ChiTietDonHangs1)
                .WithRequired(e => e.Hang1)
                .HasForeignKey(e => e.MaHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hang>()
                .HasMany(e => e.ChiTietDonHangs2)
                .WithRequired(e => e.Hang2)
                .HasForeignKey(e => e.MaHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.DonHangs)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.MaTK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.DonHangs1)
                .WithRequired(e => e.TaiKhoan1)
                .HasForeignKey(e => e.MaTK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.DonHangs2)
                .WithRequired(e => e.TaiKhoan2)
                .HasForeignKey(e => e.MaTK)
                .WillCascadeOnDelete(false);
        }
    }
}
