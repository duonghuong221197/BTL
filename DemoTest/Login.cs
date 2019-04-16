using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTest
{
    public class Login
    {
        public static string ktdangnhap(string user, string pass)
        {
            string u = "admin";
            string p = "sa";

            if (user != u || pass != p || user == "" || pass == "" ||
                (user != u && pass != p) || (user == "" && pass == "") ||
                (user != u && pass == "") || (user == "" && pass != p))
            {
                return "0";
            }
            else return "1";

        }
    }
}
