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
        public void ThemSanPham(string masp, string tensp, string loaisp, string ngaylap, int gia, string sl)
        {
            string strSQL = string.Format("Insert Into SANPHAM  Values('{0}',N'{1}',N'{2}',{3},{4},'{5}')",masp,tensp,loaisp,ngaylap,gia/1000,sl);
            db.ExecuteNonQuery(strSQL);
        }
        public void CapNhatSanPham(string masp, string tensp, string loaisp, string ngaylap, string gia, string sl)
        {
            string str = string.Format("Update SANPHAM set MASP = '{0}',TENSP =N'{1}',LOAISP =N'{2}',NGAYNHAP = {3},GIA ={4}/1000, SOLUONG ={5} where MASP = '{6}'", masp, tensp, loaisp,ngaylap, gia,sl, masp);
            db.ExecuteNonQuery(str);
        }
        public void XoaSanPham(string masp)
        {
            string sql = "Delete from SANPHAM where MASP = '"+masp+"'";
            db.ExecuteNonQuery(sql);
        }
        public DataTable HienChiPhiVatLieu(string thang, string nam)
        {
            string sql = string.Format("Select TENSP, NGAYNHAP,GIA from SANPHAM where MONTH(NGAYNHAP)='{0}' AND YEAR(NGAYNHAP)='{1}'",thang,nam);
            return db.Execute(sql);
        }
        public DataTable HienThang()
        {
            string sql = "SELECT MONTH(NGAYNHAP) AS [NGAYNHAP] FROM SANPHAM GROUP BY MONTH(NGAYNHAP)";
            return db.Execute(sql);
        }
        public DataTable HienNam()
        {
            string sql = "SELECT YEAR(NGAYNHAP) AS [NAMNHAP] FROM SANPHAM GROUP BY YEAR(NGAYNHAP)";
            return db.Execute(sql);
        }
    }
}
