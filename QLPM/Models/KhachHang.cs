using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLPM.Models
{
    [Table("KhachHang")]
    public partial class KhachHang
    {
        public KhachHang()
        {
            DatHangs = new HashSet<DatHang>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string HoVaTen { get; set; }
        [Required]
        [StringLength(15)]
        public string DienThoai { get; set; }
        [Required]
        [StringLength(255)]
        public string DiaChi { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(200)]
        public string TenDangNhap { get; set; }
        [Required]
        [StringLength(255)]
        public string MatKhau { get; set; }
        [StringLength(255)]
        public string HinhAnh { get; set; }

        [InverseProperty(nameof(DatHang.KhachHang))]
        public virtual ICollection<DatHang> DatHangs { get; set; }
    }
}
