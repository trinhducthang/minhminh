using System;
using System.Collections.Generic;

namespace onlan2.Models
{
    public partial class HoSoBenhAn
    {
        public int MaHsba { get; set; }
        public DateTime? NgayKham { get; set; }
        public string? ChuanDoan { get; set; }
        public int? MaBn { get; set; }

        public virtual BenhNhan? MaBnNavigation { get; set; }
    }
}
