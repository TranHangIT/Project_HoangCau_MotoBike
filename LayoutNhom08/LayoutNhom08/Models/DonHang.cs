namespace LayoutNhom08.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            ChiTietDonHangs1 = new HashSet<ChiTietDonHang>();
            ChiTietDonHangs2 = new HashSet<ChiTietDonHang>();
        }

        [Key]
        public int MaDH { get; set; }

        public DateTime NgayDat { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string DiaChiGiaoHang { get; set; }

        public int TinhTrangDH { get; set; }

        public int MaTK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs2 { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        public virtual TaiKhoan TaiKhoan1 { get; set; }

        public virtual TaiKhoan TaiKhoan2 { get; set; }
    }
}
