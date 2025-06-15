using System;
using System.Collections.Generic;

namespace onlan4.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            DuAns = new HashSet<DuAn>();
        }

        public int MaNv { get; set; }
        public string? HoTen { get; set; }
        public string? ChucVu { get; set; }
        public string? PhongBan { get; set; }

        public virtual ICollection<DuAn> DuAns { get; set; }
    }
}
