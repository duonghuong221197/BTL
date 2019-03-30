using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class HoaDonBanDTO
    {
        public string MaHDBan { get; set; }
        public string  MaNV { get; set; }
        public DateTime NgayBan { get; set; }
        public string  MaKhach { get; set; }
      

        public HoaDonBanDTO(string mahdban,string manv,DateTime ngayban,string makhach)
        {
            MaHDBan = mahdban;
            MaNV = manv;
            NgayBan = ngayban;
            MaKhach = makhach;
           
        }
    }
}
