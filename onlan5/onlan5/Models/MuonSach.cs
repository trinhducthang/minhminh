using System;
using System.Collections.Generic;

namespace onlan5.Models
{
    public partial class MuonSach
    {
        public int MaMuon { get; set; }
        public DateTime? NgayMuon { get; set; }
        public DateTime? NgayTra { get; set; }
        public int? MaSach { get; set; }

        public virtual Sach? MaSachNavigation { get; set; }
    }
}
