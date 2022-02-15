using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLPM.Models
{
    [Table("DatHang")]
    public partial class DatHang
    {
        public DatHang()
        {
            DatHangChiTiets = new HashSet<DatHangChiTiet>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NhanVienID")]
        public int? NhanVienId { get; set; }
        [Column("KhachHangID")]
        public int? KhachHangId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayDatHang { get; set; }

        [ForeignKey(nameof(KhachHangId))]
        [InverseProperty("DatHangs")]
        public virtual KhachHang KhachHang { get; set; }
        [ForeignKey(nameof(NhanVienId))]
        [InverseProperty("DatHangs")]
        public virtual NhanVien NhanVien { get; set; }
        [InverseProperty(nameof(DatHangChiTiet.DatHang))]
        public virtual ICollection<DatHangChiTiet> DatHangChiTiets { get; set; }
    }
}
