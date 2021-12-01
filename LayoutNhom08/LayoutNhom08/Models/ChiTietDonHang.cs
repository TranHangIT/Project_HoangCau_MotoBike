namespace LayoutNhom08.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHang { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDH { get; set; }

        public int SoLuongDat { get; set; }

        public virtual Hang Hang { get; set; }

        public virtual Hang Hang1 { get; set; }

        public virtual Hang Hang2 { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual DonHang DonHang1 { get; set; }

        public virtual DonHang DonHang2 { get; set; }
    }
}
