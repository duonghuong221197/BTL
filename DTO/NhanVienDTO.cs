using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DTO
{
    public class NhanVienDTO
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public DateTime NgaySinh { get; set; }

        public NhanVienDTO(string manhanvien, string tennhanvien, string gioitinh, string diachi, string dienthoai, DateTime ngaysinh)
        {
            this.MaNhanVien = manhanvien;
            this.TenNhanVien = tennhanvien;
            this.GioiTinh = gioitinh;
            this.DiaChi = diachi;
            this.DienThoai = dienthoai;
            this.NgaySinh = ngaysinh;
        }
    }
}
