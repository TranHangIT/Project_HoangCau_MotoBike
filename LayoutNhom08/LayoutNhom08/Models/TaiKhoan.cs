namespace LayoutNhom08.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            DonHangs = new HashSet<DonHang>();
            DonHangs1 = new HashSet<DonHang>();
            DonHangs2 = new HashSet<DonHang>();
        }

        [Key]
        public int MaTK { get; set; }

        [Required]
        [StringLength(30)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(20)]
        public string TenDN { get; set; }

        [Required]
        [StringLength(30)]
        public string MatKhau { get; set; }

        public bool Quyen { get; set; }

        public bool TrangThai { get; set; }

        [Required]
        [StringLength(10)]
        public string SoDienThoai { get; set; }

        [StringLength(40)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs2 { get; set; }
    }
}
