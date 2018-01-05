using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PhanMemQuanLyDoanThu
{
    class NhanVien
    {
        Database db;
        SqlDataReader DRD;
        public NhanVien()
        {
            db = new Database();
        }
        public DataTable LayDSNhanvien()
        {
            string strSQL = "Select Manhanvien, HoTenNhanVien, Ngaysinh,Diachi,Dienthoai, TenBangcap From Nhanvien N, BANGCAP B Where N.MaBangCap=B.MaBangCap";
            DataTable dt = db.Execute(strSQL);
            //Goi phuong thuc truy xuat du lieu 
            return dt;
        }
        public void ThemNhanVien(string tennv, string tendn, string matkhau)
        {
            string strSQL = string.Format("Insert Into NHANVIEN  Values(N'{0}',NULL,NULL,'{1}','{2}')",tennv,tendn,matkhau);
            db.ExecuteNonQuery(strSQL);
        }
        
    }
}
