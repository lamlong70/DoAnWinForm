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
        //SqlDataReader DRD;
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
        public DataTable PhanQuyen()
        {
            string strSQL = "Select Phanquyen from dangky";
            DataTable dt = db.Execute(strSQL);
            return dt;
        }
        public void ThemNhanVien(string tendn, string matkhau)
        {
            //string strSQL = string.Format("Insert Into NHANVIEN  Values(N'{0}',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'{1}','{2}')",tennv,tendn,matkhau);
            string str = "user";
            string strSQL = string.Format("Insert Into DANGKY  Values('{0}','{1}','{2}')", tendn, matkhau,str);

            db.ExecuteNonQuery(strSQL);
        }
        public void ThemNhanVienDS(string tennv, string ma_chucvu, string ma_bophan, string ngaysinh, string ngayvao, string dt, string gioitinh, string diachi)
        {
            string strSQL = string.Format("Insert Into NHANVIEN Values(N'{0}','{1}','{2}','{3}','{4}','{5}',N'{6}',N'{7}')", tennv, ma_chucvu, ma_bophan, ngaysinh, ngayvao, dt, gioitinh, diachi);
            db.ExecuteNonQuery(strSQL);
        }
        public void CapNhatNhanVien(string manv, string tennv, string ma_chucvu, string ma_bophan, string ngaysinh, string ngayvao, string dt, string gioitinh, string diachi)
        {
            string str = string.Format("Update NHANVIEN set TENNV = N'{0}',MACHUCVU ='{1}',MABOPHAN ='{2}',NGAYSINH = {3},NGAYVAOLAM ={4}, DIENTHOAI ={5},GIOITINH =N'{6}',DIACHI=N'{7}' where MANV = {8}", tennv, ma_chucvu, ma_bophan, ngaysinh, ngayvao, dt, gioitinh, diachi, manv);
            db.ExecuteNonQuery(str);

        }
        public void XoaNhanVien(string manv)
        {
            string sql = "Delete from NHANVIEN where MANV = " + manv;
            db.ExecuteNonQuery(sql);
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

        public DataTable LayDSNhanvienBoPhan(string mabp)
        {
            string strSQL = string.Format("Select MANV, TENNV, TENCHUCVU,TENBOPHAN,NGAYSINH,NGAYVAOLAM,DIENTHOAI,GIOITINH,DIACHI From NHANVIEN A, CHUCVU B, BOPHAN C Where A.MACHUCVU=B.MACHUCVU AND A.MABOPHAN=C.MABOPHAN AND A.MABOPHAN = '{0}'", mabp);
            DataTable dt = db.Execute(strSQL);
            //Goi phuong thuc truy xuat du lieu 
            return dt;
        }
        public DataTable LayDSNhanvienChucVu(string macv)
        {
            string strSQL = string.Format("Select MANV, TENNV, TENCHUCVU,TENBOPHAN,NGAYSINH,NGAYVAOLAM,DIENTHOAI,GIOITINH,DIACHI From NHANVIEN A, CHUCVU B, BOPHAN C Where A.MACHUCVU=B.MACHUCVU AND A.MABOPHAN=C.MABOPHAN AND A.MACHUCVU = '{0}'", macv);
            DataTable dt = db.Execute(strSQL);
            //Goi phuong thuc truy xuat du lieu 
            return dt;
        }
        public DataTable HienThiLuongNV()
        {
            string strSQL = string.Format("SELECT A.MANV,TENNV,TENBOPHAN,TENCHUCVU,LUONGCOBAN,LUONGCOBAN*0.2 AS PHUCAP,LUONGCOBAN+(LUONGCOBAN*0.2) AS TONG FROM NHANVIEN A,BOPHAN B,CHUCVU C, LUONG D WHERE A.MANV=D.MANV AND A.MABOPHAN = B.MABOPHAN AND A.MACHUCVU=C.MACHUCVU");
            DataTable dt = db.Execute(strSQL);
            return dt;
        }

        public void ThemLuong(string manv, string luong)
        {
            string str = string.Format("UPDATE LUONG SET LUONGCOBAN='{0}' WHERE MANV = {1};",luong,manv);
            db.ExecuteNonQuery(str);
        }

    }
}
