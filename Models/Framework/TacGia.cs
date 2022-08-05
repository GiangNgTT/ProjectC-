namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TacGia")]
    public partial class TacGia
    {
        [Key]
        public int MaTG { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTG { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        public string TieuSu { get; set; }

        [StringLength(50)]
        public string DienThoai { get; set; }

        public virtual VietSach VietSach { get; set; }
    }
}
