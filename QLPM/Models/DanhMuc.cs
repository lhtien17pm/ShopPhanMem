using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLPM.Models
{
    [Table("DanhMuc")]
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string TenDanhMuc { get; set; }

        [InverseProperty(nameof(SanPham.DanhMuc))]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
