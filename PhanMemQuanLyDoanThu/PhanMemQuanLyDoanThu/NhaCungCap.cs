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
        public void XoaNhaCungCap(string mancc)
        {
            string str = "Delete from nhacungcap where mancc = " + mancc;
            db.ExecuteNonQuery(str);
        }
        public void SuaNhaCungCap (string mancc,string tenncc,string diachi,string dienthoai)
        {
            string str = string.Format("Update nhacungcap set tenncc = N'{0}',Diachi=N'{1}',hotline='{2}' where mancc = {3}",tenncc,diachi,dienthoai,mancc);
            db.ExecuteNonQuery(str);
        }
        public void ThemNhaCungCap(string tenncc,string diachi,string dienthoai)
        {
            string str = string.Format("Insert into nhacungcap values (N'{0}',N'{1}','{2}')", tenncc, diachi, dienthoai);
            db.ExecuteNonQuery(str);
        }
    }
}
