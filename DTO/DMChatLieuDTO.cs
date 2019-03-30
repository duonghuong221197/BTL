using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DTO
{
    public class DMChatLieuDTO
    {
        public string MaChatLieu { get; set; }
        public string TenChatLieu { get; set; }
        public DMChatLieuDTO(string machatlieu, string tenchatlieu)
        {
            this.MaChatLieu = machatlieu;
            this.TenChatLieu = tenchatlieu;
        }
    }
    
}
