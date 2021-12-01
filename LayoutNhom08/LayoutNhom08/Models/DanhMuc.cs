namespace LayoutNhom08.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMuc")]
    public partial class DanhMuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMuc()
        {
            Hangs = new HashSet<Hang>();
            Hangs1 = new HashSet<Hang>();
            Hangs2 = new HashSet<Hang>();
        }

        [Key]
        public int MaDM { get; set; }

        [Required(ErrorMessage ="Tên danh mục không được để trống!")]
        [StringLength(60)]
        public string TenDM { get; set; }

        [Column(TypeName = "ntext")]
        [DataType(DataType.MultilineText)]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hang> Hangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hang> Hangs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hang> Hangs2 { get; set; }
    }
}
