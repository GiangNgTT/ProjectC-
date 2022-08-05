namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VietSach")]
    public partial class VietSach
    {
        [Key]
        public int MaTG { get; set; }

        public int? MaSach { get; set; }

        [StringLength(50)]
        public string VaiTro { get; set; }

        [StringLength(50)]
        public string ViTri { get; set; }

        public virtual TacGia TacGia { get; set; }
    }
}
