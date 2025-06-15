using System;
using System.Collections.Generic;

namespace suaxoa.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            DuAns = new HashSet<DuAn>();
        }

        public string MaNv { get; set; } = null!;
        public string? HoTen { get; set; }
        public string? ChucVu { get; set; }
        public string? PhongBan { get; set; }

        public virtual ICollection<DuAn> DuAns { get; set; }
    }
}
