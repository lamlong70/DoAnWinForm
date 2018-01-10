using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PhanMemQuanLyDoanThu
{
    public partial class FormNhanvien : DevExpress.XtraEditors.XtraForm
    {
        public bool themmoi = false;
        NhanVien nv = new NhanVien();
        public FormNhanvien()
        {
            InitializeComponent();
        }

        void setNull()
        {
            txtHoten.Text = "";
            txtDiachi.Text = "";
            txtDienThoai.Text = "";
        }

        void setButton(bool val)
        {
            txtHoten.Enabled = !val;
            txtDienThoai.Enabled = !val;
            txtDiachi.Enabled = !val;
            dtpNgayLam.Enabled = !val;
            dtpNgaySinh.Enabled = !val;
            cboBoPhan.Enabled = !val;
            cboChucVu.Enabled = !val;
            cmbGioitinh.Enabled = !val;
            btnThem.Enabled = val;
            btnXoa.Enabled = val;
            btnSua.Enabled = val;
            btnLuu.Enabled = !val;
            btnHuy.Enabled = !val;
        }

            void HienBoPhan()
        {
            DataTable dt = nv.LayBoPhan();
            cboBoPhan.DataSource = dt;
            cboBoPhan.DisplayMember = "TENBOPHAN";
            cboBoPhan.ValueMember = "MABOPHAN";
        }
        void HienChucVu()
        {
            DataTable dt = nv.LayChucVu();
            cboChucVu.DataSource = dt;
            cboChucVu.DisplayMember = "TENCHUCVU";
            cboChucVu.ValueMember = "MACHUCVU";
        }
        void HienGioiTinh()
        {
            cmbGioitinh.DisplayMember = "Nam";
            cmbGioitinh.DisplayMember = "Nữ";
        }
        void HienThiNhanVien()
        {
            lsvNhanVien.Items.Clear();
            DataTable dt = nv.LayDSNhanvien();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                ListViewItem lvi = lsvNhanVien.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
                lvi.SubItems.Add(dt.Rows[i][6].ToString());
                lvi.SubItems.Add(dt.Rows[i][7].ToString());
                lvi.SubItems.Add(dt.Rows[i][8].ToString());
            }
        }

        private void FormNhanvien_Load(object sender, EventArgs e)
        {
            setNull();
            setButton(true);
            HienThiNhanVien();
            HienBoPhan();
            HienChucVu();
            HienGioiTinh();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            setButton(false);
            txtHoten.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedIndices.Count > 0)
            {
                themmoi = false;
                setButton(false);
            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cập nhật", "Sửa mẫu tin");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setButton(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ngaysinh = String.Format("{0:MM/dd/yyyy}",dtpNgaySinh.Value);
            string ngaylam = String.Format("{0:MM/dd/yyyy}", dtpNgayLam.Value);
            if (themmoi)
            {
                nv.ThemNhanVienDS(txtHoten.Text,cboChucVu.SelectedValue.ToString(),cboBoPhan.SelectedValue.ToString(),ngaysinh,ngaylam,txtDienThoai.Text,cmbGioitinh.Text,txtDiachi.Text);
                MessageBox.Show("Thêm mới thành công");
            }
            else
            {
                nv.CapNhatNhanVien(lsvNhanVien.SelectedItems[0].SubItems[0].Text, txtHoten.Text, cboChucVu.SelectedValue.ToString(), cboBoPhan.SelectedValue.ToString(), ngaysinh, ngaylam, txtDienThoai.Text, cmbGioitinh.Text, txtDiachi.Text);
                MessageBox.Show("Cập nhật thành công");
            }
            HienThiNhanVien();
            setNull();

        }

        private void lsvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedIndices.Count > 0)
            {
                txtHoten.Text = lsvNhanVien.SelectedItems[0].SubItems[1].Text;
                cboChucVu.SelectedIndex = cboChucVu.FindString(lsvNhanVien.SelectedItems[0].SubItems[2].Text);
                cboBoPhan.SelectedIndex = cboBoPhan.FindString(lsvNhanVien.SelectedItems[0].SubItems[3].Text);
                //Chuyen sang kieu dateTime
                dtpNgaySinh.Value = DateTime.Parse(lsvNhanVien.SelectedItems[0].SubItems[4].Text);
                dtpNgayLam.Value = DateTime.Parse(lsvNhanVien.SelectedItems[0].SubItems[5].Text);
                txtDienThoai.Text = lsvNhanVien.SelectedItems[0].SubItems[6].Text;
                cmbGioitinh.SelectedIndex = cmbGioitinh.FindString(lsvNhanVien.SelectedItems[0].SubItems[7].Text);
                txtDiachi.Text = lsvNhanVien.SelectedItems[0].SubItems[8].Text;
                
                //Tìm vị trí của Tên bằng cấp trong Combobox
               

            }
        }
    }
}