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

        public void setButton(bool val)
        {
            btnPhanquyen.Enabled = val;
            btnDangxuat.Enabled = val;
            btnNhanvien.Enabled = val;
            btnChucvu.Enabled = val;
            btnBophan.Enabled = val;
            btnPhancong.Enabled = val;
            btnBangpc.Enabled = val;
            btnPhancongnv.Enabled = val;
            btnLuong.Enabled=val;
            btnVatlieu.Enabled=val;
            btnChung.Enabled=val;
            btnKhac.Enabled = val; ;
            btnDoanhthu.Enabled = val;
            btnNhacc.Enabled = val;
            btnDondh.Enabled = val;
            btnChitiet.Enabled = val;
            btnDathang.Enabled = val;
            btnPhieunhap.Enabled = val;
            btnPhieuxuat.Enabled = val;
            btnXuatkho.Enabled = val;
            btnKho.Enabled = val;
            btnQuanlykho.Enabled = val;
            btnNguyenlieu.Enabled = val;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            btnDangNhap.Enabled = false;
            btnDangKy.Enabled = false;
            setButton(true);
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
            foreach (Form f in this.MdiChildren)
                if (f.Name == "DangKy")
                {
                    f.Activate();
                    return;
                }
            DangKy dk = new DangKy();
            dk.MdiParent = this;
            dk.Show();
        }

        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*foreach (Form f in this.MdiChildren)
                if (f.Name == "DangNhap")
                {
                    f.Activate();
                    return;
                }*/
            DangNhap dn = new DangNhap();
            //dn.MdiParent = this;
            this.Hide();
            dn.Show();
        }

        private void btnDangxuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setButton(false);
            DangNhap dn = new DangNhap();
            Hide();
            dn.Show();
            
        }

        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThemsp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void btnNhanvien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form f in this.MdiChildren)
                if (f.Name == "FormNhanvien")
                {
                    f.Activate();
                    return;
                }
            FormNhanvien nv = new FormNhanvien();
            nv.MdiParent = this;
            nv.Show();
        }

        private void btnBophan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach(Form f in this.MdiChildren)
                if(f.Name=="Bophan")
                {
                    f.Activate();
                    return;
                }
                Bophan bp = new Bophan();
                bp.MdiParent = this;
                bp.Show();
        }

        private void btnKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form f in this.MdiChildren)
                if (f.Name == "TTsanpham")
                {
                    f.Activate();
                    return;
                }
            TTsanpham bp = new TTsanpham();
            bp.MdiParent = this;
            bp.Show();
        }

        private void btnSaoluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Database db = new Database();
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                string BackupFile = dlg.SelectedPath;
                db.BackupDatabase(BackupFile);
                MessageBox.Show("Backup thành công", "Thành công");
            }
        }

        private void btnPhuchoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Backup Files(*.bak)|*.bak|All Files(*.*)|*.*";
            dlg.FilterIndex = 0;
            if(dlg.ShowDialog()==DialogResult.OK)
            {

            }
        }

        private void btnNhanvien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form NhanVien = new FormNhanvien();
            NhanVien.Show();
        }
    }
}
