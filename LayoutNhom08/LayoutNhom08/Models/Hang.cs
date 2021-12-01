namespace LayoutNhom08.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hang")]
    public partial class Hang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            ChiTietDonHangs1 = new HashSet<ChiTietDonHang>();
            ChiTietDonHangs2 = new HashSet<ChiTietDonHang>();
        }

        [Key]
        public int MaHang { get; set; }

        public int MaDM { get; set; }

        [Required(ErrorMessage ="Tên sản phẩm không được để trống!")]
        [StringLength(100)]
        public string TenHang { get; set; }

        [StringLength(50)]
        public string ThuongHieu { get; set; }

        [StringLength(100)]
        public string LoaiXe { get; set; }

        [Required(ErrorMessage = "Giá tiền của sản phẩm không được để trống!")]
        [Column(TypeName = "money")]
        public decimal GiaTien { get; set; }

        [Column(TypeName = "ntext")]
        [DataType(DataType.MultilineText)]
        public string MoTaHang { get; set; }

        [StringLength(50)]
        public string MauSac { get; set; }

        [Required(ErrorMessage = "Số lượng sản phẩm không được để trống!")]
        public int SoLuong { get; set; }

        [StringLength(50)]
        public string Anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs2 { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        public virtual DanhMuc DanhMuc1 { get; set; }

        public virtual DanhMuc DanhMuc2 { get; set; }
    }
}
