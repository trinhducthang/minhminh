using System;
using System.Collections.Generic;

namespace onlan2.Models
{
    public partial class BenhNhan
    {
        public BenhNhan()
        {
            HoSoBenhAns = new HashSet<HoSoBenhAn>();
        }

        public int MaBn { get; set; }
        public string? HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? DiaChi { get; set; }

        public virtual ICollection<HoSoBenhAn> HoSoBenhAns { get; set; }
    }
}
