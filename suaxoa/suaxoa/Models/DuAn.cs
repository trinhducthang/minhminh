using System;
using System.Collections.Generic;

namespace suaxoa.Models
{
    public partial class DuAn
    {
        public string MaDa { get; set; } = null!;
        public string? TenDuAn { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string? MaNv { get; set; }

        public virtual NhanVien? MaNvNavigation { get; set; }
    }
}
