using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PhanMemQuanLyDoanThu
{
    class KhachHang
    {
        Database db;
        public KhachHang()
        {
            db = new Database();
        }
        public DataTable LayDSKH()
        {
            string strSQL = "Select * From KHACHHANG";
            DataTable dt = db.Execute(strSQL);
            //Goi phuong thuc truy xuat du lieu 
            return dt;
        }
        public void XoaKH(string makh)
        {
            string sql = "Delete from KHACHHANG where MAKH = " + makh;
            db.ExecuteNonQuery(sql);
        }
        public void CapNhatKH(string makh, string tenkh, string dt ,string diachi)
        {
            string str = string.Format("Update KHACHHANG set TENKH = N'{0}',DIENTHOAI ={1},DIACHI=N'{2}' where MANV = {3}",tenkh,dt,diachi,makh);
            db.ExecuteNonQuery(str);
        }
        public void ThemKH(string tenkh, string dt, string diachi)
        {
            string strSQL = string.Format("Insert Into KHACHHANG Values(N'{0}','{1}',N'{2}')",tenkh,dt,diachi);
            db.ExecuteNonQuery(strSQL);
        }
    }
}
