using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DevExpress.XtraEditors;

namespace PhanMemQuanLyDoanThu
{

    
    
    class NhaCungCap
    {
        Database db;
        public NhaCungCap()
        {
            db = new Database();
        }
        public DataTable LayNhaCungCap()
        {
            string str = "Select * from nhacungcap";
            DataTable dt =db.Execute(str);
            return dt;
        }

    }
}
