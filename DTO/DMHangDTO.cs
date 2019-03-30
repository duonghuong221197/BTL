using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class DMHangDTO
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string MaChatLieu { get; set; }
        public float SoLuong { get; set; }
        public float DonGiaNhap { get; set; }
        public float DonGiaBan { get; set; }
        public string Anh { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayXuatHD { get; set; }

        public DMHangDTO(string mahang, string tenhang, string machatlieu, float soluong, float dongianhap, float dongiaban, string anh, string ghichu, DateTime ngayxuathd)
        {
            this.MaHang = mahang;
            this.TenHang = tenhang;
            this.MaChatLieu = machatlieu;
            this.SoLuong = soluong;
            this.DonGiaNhap = dongianhap;
            this.DonGiaBan = dongiaban;
            this.Anh = anh;
            this.GhiChu = ghichu;
            this.NgayXuatHD = ngayxuathd;
           
        }

    }
}
