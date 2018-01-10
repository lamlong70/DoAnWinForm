using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PhanMemQuanLyDoanThu
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public void Skins()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "Springtime";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnPhanquyen.Enabled = false;
            Skins();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show("Bạn có muốn thoát không ?", "Thông Báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr==DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnDangky_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form dangky = new DangKy();
            dangky.Show();
        }

        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form dangnhap = new DangNhap();
            dangnhap.Show();
        }

        private void btnDangxuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnPhanquyen.Enabled = false;
        }

        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThemsp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form ttSanpham = new TTsanpham();
            ttSanpham.Show();
        }

        private void btnNhanvien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form NhanVien = new FormNhanvien();
            NhanVien.Show();
        }
    }
}
