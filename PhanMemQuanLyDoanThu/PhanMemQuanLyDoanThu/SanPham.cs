using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PhanMemQuanLyDoanThu
{
    class SanPham
    {
        Database db;
        SqlDataReader DRD;
        public SanPham()
        {
            db = new Database();
        }
        public DataTable LayDSSanPham()
        {
            string strSQL = "Select * From SANPHAM";
            DataTable dt = db.Execute(strSQL);
            //Goi phuong thuc truy xuat du lieu 
            return dt;
        }
        public void ThemSanPham(string masp, string tensp, string loaisp, string ngaylap, string gia, string sl)
        {
            string strSQL = string.Format("Insert Into DANGKY  Values('{0}','{1}','{2}','{3}','{4}','{5}')",masp,tensp,loaisp,ngaylap,gia,sl);
            db.ExecuteNonQuery(strSQL);
        }
    }
}
