using System;
using System.Collections.Generic;

namespace onlan5.Models
{
    public partial class Sach
    {
        public Sach()
        {
            MuonSaches = new HashSet<MuonSach>();
        }

        public int MaSach { get; set; }
        public string? TenSach { get; set; }
        public string? TacGia { get; set; }
        public int? NamXuatBan { get; set; }

        public virtual ICollection<MuonSach> MuonSaches { get; set; }
    }
}
