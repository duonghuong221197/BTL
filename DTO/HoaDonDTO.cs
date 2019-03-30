using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class HoaDonDTO
    {
        public string MaHD { get; set; }
        public string MaHang { get; set; }
        public string MaNhanVien { get; set; }
        public string  MaKhach { get; set; }
        public float SoLuong { get; set; }
       
        public float DonGia { get; set; }
        public float ThanhTien { get; set; }
        public DateTime NgayBan { get; set; }
        

        public HoaDonDTO(string mahd , string mahang,string man,string makhach ,float dongia,float soluong , float thanhtien,DateTime ngayban) 
        {
            MaHD = mahd;
            MaHang = mahang;
            SoLuong = soluong;
            MaKhach = makhach;
            DonGia = dongia;
            
            ThanhTien = thanhtien;
            MaNhanVien = man;
            NgayBan = ngayban;
        }

        public HoaDonDTO(string mahd, string mahang, float soluong, float thanhtien)
        {
            MaHD = mahd;
            MaHang = mahang;
            SoLuong = soluong;           
            ThanhTien = thanhtien;
            
        }
    }
}
