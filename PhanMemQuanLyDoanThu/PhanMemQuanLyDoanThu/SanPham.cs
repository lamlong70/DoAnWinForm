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
        public void CapNhatNhanVien(string manv, string tennv, string ma_chucvu, string ma_bophan, string ngaysinh, string ngayvao, string dt, string gioitinh, string diachi)
        {
            string str = string.Format("Update NHANVIEN set TENNV = N'{0}',MACHUCVU ='{1}',MABOPHAN ='{2}',NGAYSINH = {3},NGAYVAOLAM ={4}, DIENTHOAI ={5},GIOITINH =N'{6}',DIACHI=N'{7}' where MANV = {8}", tennv, ma_chucvu, ma_bophan, ngaysinh, ngayvao, dt, gioitinh, diachi, manv);
            db.ExecuteNonQuery(str);

        }
    }
}
