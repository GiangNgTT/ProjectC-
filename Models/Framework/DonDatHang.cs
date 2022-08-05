namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonDatHang")]
    public partial class DonDatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonDatHang()
        {
            ChiTietDatHangs = new HashSet<ChiTietDatHang>();
        }

        [Key]
        public int SoDH { get; set; }

        public int? MaKH { get; set; }

        public DateTime? NgayDH { get; set; }

        public DateTime? NgayGiao { get; set; }

        public bool? DaThanhToan { get; set; }

        public bool? TinhTrangGiaoHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatHang> ChiTietDatHangs { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
