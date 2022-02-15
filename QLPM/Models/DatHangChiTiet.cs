using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLPM.Models
{
    [Table("DatHangChiTiet")]
    public partial class DatHangChiTiet
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("DatHangID")]
        public int? DatHangId { get; set; }
        [Column("SanPhamID")]
        public int? SanPhamId { get; set; }
        public int? DonGia { get; set; }
        [StringLength(255)]
        public string GhiChu { get; set; }

        [ForeignKey(nameof(DatHangId))]
        [InverseProperty("DatHangChiTiets")]
        public virtual DatHang DatHang { get; set; }
        [ForeignKey(nameof(SanPhamId))]
        [InverseProperty("DatHangChiTiets")]
        public virtual SanPham SanPham { get; set; }
    }
}
