using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class NhanVienDAO : Dataprovider
    {
        public List<NhanVienDTO> getNV()
        {
            Connect();
            List<NhanVienDTO> list = new List<NhanVienDTO>();
            string sql = "SELECT *FROM NhanVien";

            string MaNhanVien;
            string TenNhanVien;
            string GioiTinh;
            string DiaChi;
            string DienThoai;
            DateTime NgaySinh;
            try
            {
                SqlDataReader dr = ExecuteReader(sql);
                while (dr.Read())
                {
                    MaNhanVien = dr.GetString(0);
                    TenNhanVien = dr.GetString(1);
                    GioiTinh = dr.GetString(2);
                    DiaChi = dr.GetString(3);
                    DienThoai = dr.GetString(4);
                    NgaySinh = dr.GetDateTime(5);

                   // NhanVienDTO kh = new NhanVienDTO(MaNhanVien, TenNhanVien, GioiTinh, DiaChi, DienThoai);
                    NhanVienDTO kh = new NhanVienDTO(MaNhanVien, TenNhanVien, GioiTinh, DiaChi, DienThoai,NgaySinh);
                    list.Add(kh);
                }
                dr.Close();
                return list;
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                DisConnect();
            }
        }
        public int them(NhanVienDTO nv)
        {         
            try
            {
                string sql = "INSERT INTO NhanVien VALUES (N'" + nv.MaNhanVien + "',N'" + nv.TenNhanVien + "',N'" + nv.GioiTinh + "' ,N'" + nv.DiaChi + "',N'" + nv.DienThoai + "','"+nv.NgaySinh+"')";
                int NumberOfRow = ExcuteNonquery(sql);
                return NumberOfRow;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int xoa(string MaNhanVien)
        {
            try
            {
                string sql = "DELETE FROM NhanVien WHERE MaNhanVien = N'" + MaNhanVien + "'";
                int NumberOfRow = ExcuteNonquery(sql);
                return NumberOfRow;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }

        public int sua(NhanVienDTO acc)
        {
            Connect();
            try
            {
                string sql = "UPDATE NhanVien SET TenNhanVien = N'" + acc.TenNhanVien + "', GioiTinh = N'" + acc.GioiTinh + "',DiaChi=N'" + acc.DiaChi + "',DienThoai=N'" + acc.DienThoai + "',NgaySinh='"+acc.NgaySinh+"' WHERE MaNhanVien = N'" + acc.MaNhanVien + "' ";
                int NumberOfRow = ExcuteNonquery(sql);
                return NumberOfRow;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public List<NhanVienDTO> getvnValue(string name)
        {
            Connect();
            List<NhanVienDTO> list = new List<NhanVienDTO>();
            string sql = "SELECT *FROM NhanVien WHERE MaNhanVien =N'"+name+"'";

            string MaNhanVien;
            string TenNhanVien;
            string GioiTinh;
            string DiaChi;
            string DienThoai;
            DateTime NgaySinh;
            try
            {
                SqlDataReader dr = ExecuteReader(sql);
                while (dr.Read())
                {
                    MaNhanVien = dr.GetString(0);
                    TenNhanVien = dr.GetString(1);
                    GioiTinh = dr.GetString(2);
                    DiaChi = dr.GetString(3);
                    DienThoai = dr.GetString(4);
                    NgaySinh = dr.GetDateTime(5);

                    
                    NhanVienDTO kh = new NhanVienDTO(MaNhanVien, TenNhanVien, GioiTinh, DiaChi, DienThoai, NgaySinh);
                    list.Add(kh);
                }
                dr.Close();
                return list;
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                DisConnect();
            }
        }
    }
}
