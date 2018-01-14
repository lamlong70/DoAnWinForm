using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyDoanThu
{
    public partial class LuongNV : Form
    {
        bool themmoi = true;
        NhanVien nv = new NhanVien();
        public LuongNV()
        {
            InitializeComponent();
        }
        void HienThiLuongNV()
        {
            lsvLuongNV.Items.Clear();
            DataTable dt = nv.HienThiLuongNV();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvLuongNV.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString()+" VNĐ");
                lvi.SubItems.Add(dt.Rows[i][5].ToString()+" VNĐ");
                lvi.SubItems.Add(dt.Rows[i][6].ToString()+" VNĐ");
            }
        }
        void setNull()
        {
            txtHoten.Text = "";
            txtLuong.Text = "";
        }
        void setButtonDis(bool val)
        {
            txtHoten.Enabled = !val;
            cboBoPhan.Enabled = !val;
            cboChucVu.Enabled = !val;

        }
        void setButton(bool val)
        {
            txtLuong.Enabled = !val;
            btnSua.Enabled = val;
            btnLuu.Enabled = !val;
            btnKhongLuu.Enabled = !val;
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
        private void LuongNV_Load(object sender, EventArgs e)
        {
            //setNull();
            int witdhScreen = Screen.PrimaryScreen.WorkingArea.Width;
            int heightScreen = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = witdhScreen;
            this.Height = heightScreen;
            AcceptButton = btnSua;
            setButton(true);
            setButtonDis(true);
            HienBoPhan();
            HienChucVu();
            HienThiLuongNV();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtLuong.Focus();
            if (lsvLuongNV.SelectedIndices.Count > 0)
            {
                setButton(false);
                AcceptButton = btnLuu;
            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cập nhật", "Sửa mẫu tin");
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            setButton(true);
        }

        private void lsvLuongNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvLuongNV.SelectedIndices.Count > 0)
            {
                txtHoten.Text = lsvLuongNV.SelectedItems[0].SubItems[1].Text;
                cboBoPhan.SelectedIndex = cboBoPhan.FindString(lsvLuongNV.SelectedItems[0].SubItems[2].Text);
                cboChucVu.SelectedIndex = cboChucVu.FindString(lsvLuongNV.SelectedItems[0].SubItems[3].Text);               
                txtLuong.Text = lsvLuongNV.SelectedItems[0].SubItems[4].Text;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (themmoi)
            {
                nv.ThemLuong(lsvLuongNV.SelectedItems[0].SubItems[0].Text,txtLuong.Text);
                MessageBox.Show("Thêm thành công");
                setButton(true);
            }
            HienThiLuongNV();
            setNull();
        }
    }
}
