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
    public partial class FormKhachHang : Form
    {
        public bool themmoi = false;
        KhachHang kh = new KhachHang();
        public FormKhachHang()
        {
            InitializeComponent();
        }
        void setNull()
        {
            txtDiaChi.Text = "";
            txtSoDT.Text = "";
            txtTenKH.Text = "";
        }

        void setButton(bool val)
        {
            txtTenKH.Enabled = !val;
            txtSoDT.Enabled = !val;
            txtDiaChi.Enabled = !val;
            btnThem.Enabled = val;
            btnXoa.Enabled = val;
            btnSua.Enabled = val;
            btnLuu.Enabled = !val;
            btnKhongLuu.Enabled = !val;
        }
        void HienThiKhachHang()
        {
            lsvKhachHang.Items.Clear();
            DataTable dt = kh.LayDSKH();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvKhachHang.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }
        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            int witdhScreen = Screen.PrimaryScreen.WorkingArea.Width;
            int heightScreen = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = witdhScreen;
            this.Height = heightScreen;
            setNull();
            setButton(true);
            HienThiKhachHang();
            AcceptButton = btnThem;
            txtTenKH.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            setButton(false);
            txtTenKH.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvKhachHang.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không ? ", "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    kh.XoaKH(lsvKhachHang.SelectedItems[0].SubItems[0].Text);
                    lsvKhachHang.Items.RemoveAt(lsvKhachHang.SelectedIndices[0]);
                    setNull();
                }
            }
            else
                MessageBox.Show("Bạn phải chọn nhân viên cần xóa");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtTenKH.Focus();
            if (lsvKhachHang.SelectedIndices.Count > 0)
            {
                themmoi = false;
                setButton(false);
            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cập nhật", "Sửa mẫu tin");
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            setButton(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (themmoi)
            {
                kh.ThemKH(txtTenKH.Text,txtSoDT.Text,txtDiaChi.Text);
                MessageBox.Show("Thêm mới thành công");
                setButton(true);
            }
            else
            {
                kh.CapNhatKH(lsvKhachHang.SelectedItems[0].SubItems[0].Text, txtTenKH.Text,txtSoDT.Text,txtDiaChi.Text);
                MessageBox.Show("Cập nhật thành công");
                setButton(true);
            }
            HienThiKhachHang();
            setNull();
        }

        private void lsvKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvKhachHang.SelectedIndices.Count > 0)
            {
                txtTenKH.Text = lsvKhachHang.SelectedItems[0].SubItems[1].Text;
                txtSoDT.Text = lsvKhachHang.SelectedItems[0].SubItems[2].Text;
                txtDiaChi.Text = lsvKhachHang.SelectedItems[0].SubItems[3].Text;
            }
        }
    }
}
