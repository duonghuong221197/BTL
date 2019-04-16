using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoTest;

namespace Tester
{
    [TestClass]
    public class TestLogin
    {
        [TestInitialize]
        public void Setup()
        {
        }

        //1
        [TestMethod]
        public void TestNhapDungTaiKhoan()
        {
            string actual = Login.ktdangnhap("admin", "sa");
            string expected = "1";

            Assert.AreEqual(expected, actual);
        }
        //2
        [TestMethod]
        public void TestUserDung_PassKoDung()
        {
            string actual = Login.ktdangnhap("admin", "admin");
            string expected = "0";

            Assert.AreEqual(expected, actual);
        }
        //3
        [TestMethod]
        public void TestUserDung_KoNhapPass()
        {
            string actual = Login.ktdangnhap("admin", "");
            string expected = "0";

            Assert.AreEqual(expected, actual);
        }
        //4
        [TestMethod]
        public void TestUserKoDung_PassDung()
        {
            string actual = Login.ktdangnhap("ad", "sa");
            string expected = "0";

            Assert.AreEqual(expected, actual);
        }

        //5
        [TestMethod]
        public void TestKoNhapUser_Pass()
        {
            string actual = Login.ktdangnhap("", "");
            string expected = "0";

            Assert.AreEqual(expected, actual);
        }

    }


}
