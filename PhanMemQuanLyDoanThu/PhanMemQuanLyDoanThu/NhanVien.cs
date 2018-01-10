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
            string strSQL = "Select MANV, TENNV, TENCHUCVU,TENBOPHAN,NGAYSINH,NGAYVAOLAM,DIENTHOAI,GIOITINH,DIACHI From NHANVIEN A, CHUCVU B, BOPHAN C Where A.MACHUCVU=B.MACHUCVU AND A.MABOPHAN=C.MABOPHAN";
            DataTable dt = db.Execute(strSQL);
            //Goi phuong thuc truy xuat du lieu 
            return dt;
        }
        public void ThemNhanVien(string tendn, string matkhau)
        {
            string strSQL = string.Format("Insert Into DANGKY  Values('{0}','{1}')",tendn,matkhau);
            db.ExecuteNonQuery(strSQL);
        }
        public void ThemNhanVienDS(string tennv,string ma_chucvu, string ma_bophan, string ngaysinh,string ngayvao, string dt, string gioitinh, string diachi)
        {
            string strSQL = string.Format("Insert Into NHANVIEN Values(N'{0}','{1}','{2}','{3}','{4}','{5}',N'{6}',N'{7}')",tennv,ma_chucvu,ma_bophan,ngaysinh,ngayvao,dt,gioitinh,diachi);
            db.ExecuteNonQuery(strSQL);
        }

        public DataTable LayBoPhan()
        {
            string strSQL = "Select * from BOPHAN";
            DataTable dt = db.Execute(strSQL);
            return dt;
        }
        public DataTable LayChucVu()
        {
            string strSQL = "Select * from CHUCVU";
            DataTable dt = db.Execute(strSQL);
            return dt;
        }
    }
}
