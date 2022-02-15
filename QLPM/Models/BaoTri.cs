using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLPM.Models
{
    [Table("BaoTri")]
    public partial class BaoTri
    {
        public BaoTri()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ThoiGianBT", TypeName = "date")]
        public DateTime? ThoiGianBt { get; set; }

        [InverseProperty(nameof(SanPham.BaoTri))]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
