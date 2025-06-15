using System;
using System.Collections.Generic;

namespace onlan4.Models
{
    public partial class DuAn
    {
        public int MaDa { get; set; }
        public string? TenDuAn { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public int? MaNv { get; set; }

        public virtual NhanVien? MaNvNavigation { get; set; }
    }
}
