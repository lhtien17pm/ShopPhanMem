using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLPM.Models
{
    [Table("SanPham")]
    public partial class SanPham
    {
        public SanPham()
        {
            DatHangChiTiets = new HashSet<DatHangChiTiet>();
            DungThus = new HashSet<DungThu>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("DanhMucID")]
        public int DanhMucId { get; set; }
        [StringLength(255)]
        public string TenPhanMem { get; set; }
        [StringLength(255)]
        public string NhaPhatHanh { get; set; }
        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }
        [Column("HuongDanID")]
        public int? HuongDanId { get; set; }
        [Column("BaoTriID")]
        public int? BaoTriId { get; set; }

        [ForeignKey(nameof(BaoTriId))]
        [InverseProperty("SanPhams")]
        public virtual BaoTri BaoTri { get; set; }
        [ForeignKey(nameof(DanhMucId))]
        [InverseProperty("SanPhams")]
        public virtual DanhMuc DanhMuc { get; set; }
        [ForeignKey(nameof(HuongDanId))]
        [InverseProperty("SanPhams")]
        public virtual HuongDan HuongDan { get; set; }
        [InverseProperty(nameof(DatHangChiTiet.SanPham))]
        public virtual ICollection<DatHangChiTiet> DatHangChiTiets { get; set; }
        [InverseProperty(nameof(DungThu.SanPham))]
        public virtual ICollection<DungThu> DungThus { get; set; }
    }
}
