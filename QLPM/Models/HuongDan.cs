using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLPM.Models
{
    [Table("HuongDan")]
    public partial class HuongDan
    {
        public HuongDan()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(255)]
        public string Video { get; set; }
        [StringLength(255)]
        public string TaiLieu { get; set; }

        [InverseProperty(nameof(SanPham.HuongDan))]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
