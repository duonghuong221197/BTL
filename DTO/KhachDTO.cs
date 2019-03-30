using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class KhachDTO
    {
        public string MaKhach { get; set; }
        public string TenKhach { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public KhachDTO(string makhach, string tenkhach, string diachi, string dienthoai)
        {
            this.MaKhach = makhach;
            this.TenKhach = tenkhach;
            this.DiaChi = diachi;
            this.DienThoai = dienthoai;
        }
    }
   
}
