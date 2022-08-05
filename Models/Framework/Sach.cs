namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]

    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            ChiTietDatHangs = new HashSet<ChiTietDatHang>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSach { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tên sản phẩm")]
        public string TenSach { get; set; }

        [DisplayName("Giá")]
        public decimal? GiaBan { get; set; }

        [DisplayName("Mô tả sản phẩm")]
        public string MoTa { get; set; }

        [StringLength(50)]
        [DisplayName("Hình ảnh SP")]
        public string AnhBia { get; set; }
        [DisplayName("Ngày cập nhật")]
        public DateTime? NgayCapNhat { get; set; }
        [DisplayName("Số lượng tồn")]
        public int? SoLuongTon { get; set; }
        [DisplayName("Mã chủ đề")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? MaCD { get; set; }
        [DisplayName("Mã NXB")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? MaNXB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatHang> ChiTietDatHangs { get; set; }

        public virtual ChuDe ChuDe { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }
    }
}
