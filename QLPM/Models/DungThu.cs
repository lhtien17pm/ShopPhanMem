using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLPM.Models
{
    [Table("DungThu")]
    public partial class DungThu
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("SanPhamID")]
        public int? SanPhamId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ThoiGianDungThu { get; set; }

        [ForeignKey(nameof(SanPhamId))]
        [InverseProperty("DungThus")]
        public virtual SanPham SanPham { get; set; }
    }
}
