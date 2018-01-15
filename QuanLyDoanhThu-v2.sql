CREATE DATABASE QUANLYDOANHTHUDA
ON  PRIMARY 
( NAME = N'QUANLYDOANHTHUDA', FILENAME = N'D:\DoAnWinform\PhanMemQuanLyDoanThu\QUANLYDOANHTHUDA.mdf')
 LOG ON 
( NAME = N'QUANLYDOANHTHUDA_log', FILENAME = N'D:\DoAnWinform\PhanMemQuanLyDoanThu\QUANLYDOANHTHUDA_log.ldf')
GO

DROP DATABASE QUANLYDOANHTHUDA;
CREATE TABLE KHACHHANG(
	MAKH INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	TENKH NVARCHAR (24) NOT NULL,
	SODT INT UNIQUE,
	DIACHI NVARCHAR (100)
);
	
CREATE TABLE DANGKY(
	TENDANGNHAP VARCHAR (21) NOT NULL UNIQUE,
	MATKHAU VARCHAR (15) NOT NULL,
);
CREATE TABLE NHANVIEN(
	MANV INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	TENNV NVARCHAR (24) NOT NULL,
	MACHUCVU CHAR (10) FOREIGN KEY REFERENCES CHUCVU(MACHUCVU), 
	MABOPHAN CHAR (10) FOREIGN KEY REFERENCES BOPHAN(MABOPHAN),
	NGAYSINH DATETIME,
	NGAYVAOLAM DATETIME,
	DIENTHOAI CHAR,
	GIOITINH CHAR (5),
	DIACHI NVARCHAR(100),
);
CREATE TABLE LUONG(
	MANV INT NOT NULL FOREIGN KEY REFERENCES NHANVIEN(MANV),
	LUONGCOBAN DECIMAL NOT NULL,
);
CREATE TABLE CHUCVU(
	MACHUCVU CHAR(10) PRIMARY KEY,
	TENCHUCVU NVARCHAR(24)
);
CREATE TABLE BOPHAN(
	MABOPHAN CHAR(10) PRIMARY KEY,
	TENBOPHAN NVARCHAR(24)
);
CREATE TABLE SANPHAM(
	MASP CHAR (8) NOT NULL PRIMARY KEY,
	TENSP NVARCHAR (21) NOT NULL,
	LOAISP NVARCHAR (21) NOT NULL,
	NGAYNHAP DATETIME,
	GIA MONEY NOT NULL,
	SOLUONG INT NOT NULL,
);
CREATE TABLE HOADON(
	MAHD INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	MANV INT FOREIGN KEY REFERENCES NHANVIEN(MANV),
	MAKH INT FOREIGN KEY REFERENCES KHACHHANG(MAKH),
	NGAYTAO DATETIME,
);

CREATE TABLE CHITIETHOADON (
	MAHD INT NOT NULL FOREIGN KEY REFERENCES HOADON (MAHD),
	MASP CHAR(8) NOT NULL FOREIGN KEY REFERENCES SANPHAM(MASP),
	SOLUONG INT ,
	DONGIA FLOAT ,
	THANHTIEN FLOAT ,
);

select TENDANGNHAP
from NHANVIEN
<<<<<<< HEAD
where TENNV=N'Lâm Thành Long'
=======

where TENNV=N'Lâm Thành Long'

Update NHANVIEN 
set TENNV = N'Phạm Quốc Quân',MACHUCVU ='NV',MABOPHAN ='PV',NGAYSINH = 10/10/1997 ,NGAYVAOLAM = 20/10/2017, DIENTHOAI =12345678,GIOITINH =N'Nam',DIACHI=N'Q.12' 
where MANV = 3

Select MANV, TENNV, TENCHUCVU,TENBOPHAN,NGAYSINH,NGAYVAOLAM,DIENTHOAI,GIOITINH,DIACHI From NHANVIEN A, CHUCVU B, BOPHAN C Where A.MACHUCVU=B.MACHUCVU AND A.MABOPHAN=C.MABOPHAN AND A.MABOPHAN = 'NB'

where TENNV=N'Lâm Thành Long'

Select * from SANPHAM

Update SANPHAM set MASP = 'BM',TENSP =N'Bột Mì',LOAISP =N'Bột',NGAYNHAP = 12/02/2018 ,GIA =10000, SOLUONG =5 where MASP = 'BM'
>>>>>>> 8334b33d1542c16012334ab1c9a2651242bd13bc

ALTER DATABASE QUANLYDOANHTHUDA SET MULTI_USER WITH ROLLBACK IMMEDIATE;
GO
USE master
GO
RESTORE DATABASE QUANLYDOANHTHUDA FROM DISK= 'D:\\Backup\\QUANLYDOANHTHUDA-636513116361972100.bak' WITH REPLACE;

use master

ALTER TABLE LUONG ADD  LUONGCOBAN DECIMAL
ALTER TABLE LUONG MODIFY COLUMN LUONGCOBAN DECIMAL

SELECT A.MANV,TENNV,TENBOPHAN,TENCHUCVU,LUONGCOBAN,LUONGCOBAN*0.2 AS PHUCAP,LUONGCOBAN+(LUONGCOBAN*0.2) AS TONG FROM NHANVIEN A,BOPHAN B,CHUCVU C, LUONG D WHERE A.MANV=D.MANV AND A.MABOPHAN = B.MABOPHAN AND A.MACHUCVU=C.MACHUCVU

SELECT TENNV,A.MABOPHAN,A.MACHUCVU,LUONGCOBAN,PHUCAP,LUONGCOBAN+PHUCAP AS TONG FROM NHANVIEN A,BOPHAN B,CHUCVU C, LUONG D WHERE A.MANV=D.MANV AND A.MABOPHAN = B.MABOPHAN AND A.MACHUCVU=C.MACHUCVU

UPDATE LUONG SET LUONGCOBAN=10000 WHERE MANV = 1 ;

SELECT MONTH(NGAYNHAP) AS [NGAYNHAP] FROM SANPHAM GROUP BY MONTH(NGAYNHAP)

SELECT YEAR(NGAYNHAP) AS [NAMNHAP] FROM SANPHAM GROUP BY YEAR(NGAYNHAP)

ALTER DATABASE QUANLYDOANHTHUDA SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
ALTER DATABASE QUANLYDOANHTHUDA SET ONLINE;

ALTER DATABASE QUANLYDOANHTHUDA MODIFY FILE 
(
   Name = QUANLYDOANHTHUDAdb,
   Filename = 'D:\DoAnWinform\PhanMemQuanLyDoanThu\QUANLYDOANHTHUDAdb.MDF'
);

ALTER DATABASE QUANLYDOANHTHUDA MODIFY FILE 
(
   Name = QUANLYDOANHTHUDAdb_log, 
   Filename = 'D:\DoAnWinform\PhanMemQuanLyDoanThu\QUANLYDOANHTHUDAdb_log.LDF'
);

ALTER DATABASE QUANLYDOANHTHUDA SET ONLINE;
ALTER DATABASE QUANLYDOANHTHUDA SET MULTI_USER;