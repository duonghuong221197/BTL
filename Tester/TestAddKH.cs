using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoTest;
using BaiTapQLBH;
using BUS;
using DTO;
using DAO;



namespace Tester
{
    [TestClass]
    public class TestAddKH
    {
        /*
        [TestMethod]
        public void TestThemKhachHang()
        {
            string makhach = TestAddKH.DataRow[0].ToString();
            string tenkhach = TestAddKH.DataRow[1].ToString();
            string diachi = TestAddKH.DataRow[2].ToString();
            string dienthoai = TestAddKH.DataRow[3].ToString();
            bool expected = Boolean.Parse(TestAddKH.DataRow[4].ToString());
            KhachDTO khachhang = new KhachDTO(makhach, tenkhach, diachi, dienthoai);
            KhachBUS kh = new KhachBUS();
            int actual = kh.Add(khachhang);

            Assert.AreEqual(expected, actual);
        }*/

        [TestMethod]
        public void TestDataDriver()
        {

        }
    }
}
