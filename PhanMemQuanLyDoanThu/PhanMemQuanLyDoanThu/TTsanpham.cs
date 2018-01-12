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
    public partial class TTsanpham : DevExpress.XtraEditors.XtraForm
    {
        public bool themmoi = false;
        SanPham sp = new SanPham();
        public TTsanpham()
        {
            InitializeComponent();
        }
        void setNull()
        {
            txtTensp.Text = "";
            txtMasp.Text = "";
            txtGiasp.Text = "";
            txtLoaisp.Text = "";
            txtSoluong.Text = "";
        }

        void setButton(bool val)
        {
            btnThem.Enabled = val;
            btnXoa.Enabled = val;
            btnSua.Enabled = val;
            txtMasp.Enabled = !val;
            txtTensp.Enabled = !val;
            txtSoluong.Enabled = !val;
            txtLoaisp.Enabled = !val;
            txtGiasp.Enabled = !val;
            btnLuu.Enabled = !val;
            btnHuy.Enabled = !val;
        }

        void HienThiSanPham()
        {
            lsvSanPham.Items.Clear();
            DataTable dt = sp.LayDSSanPham();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvSanPham.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
                }
        }
        private void TTsanpham_Load(object sender, EventArgs e)
        {
            setNull();
            setButton(true);
            HienThiSanPham();
            AcceptButton = btnThem;
            txtTensp.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            setButton(false);
            txtTensp.Focus();
            AcceptButton = btnLuu;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtTensp.Focus();
            if (lsvSanPham.SelectedIndices.Count > 0)
            {
                themmoi = false;
                setButton(false);
                AcceptButton = btnLuu;
                txtTensp.Focus();
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
            string ngaylap = String.Format("{0:MM/dd/yyyy}", dtpNgayLap.Value);
            if (themmoi)
            {
                sp.ThemSanPham(txtMasp.Text, txtTensp.Text, txtLoaisp.Text, ngaylap,int.Parse(txtGiasp.Text), txtSoluong.Text);
                MessageBox.Show("Thêm mới thành công");
                setButton(true);
            }
            else
            {
                sp.CapNhatSanPham(lsvSanPham.SelectedItems[0].SubItems[0].Text, txtTensp.Text, txtLoaisp.Text, ngaylap, txtGiasp.Text,txtSoluong.Text);
                MessageBox.Show("Cập nhật thành công");
                setButton(true);
            }
            HienThiSanPham();
            setNull();

        }

        private void lsvSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSanPham.SelectedIndices.Count > 0)
            {
                txtMasp.Text = lsvSanPham.SelectedItems[0].SubItems[0].Text;
                txtTensp.Text = lsvSanPham.SelectedItems[0].SubItems[1].Text;
                txtLoaisp.Text = lsvSanPham.SelectedItems[0].SubItems[2].Text;                
                dtpNgayLap.Value = DateTime.Parse(lsvSanPham.SelectedItems[0].SubItems[3].Text);
                txtGiasp.Text = lsvSanPham.SelectedItems[0].SubItems[4].Text;
                txtSoluong.Text = lsvSanPham.SelectedItems[0].SubItems[5].Text;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvSanPham.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không ? ", "Xóa sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    sp.XoaSanPham(lsvSanPham.SelectedItems[0].SubItems[0].Text);
                    lsvSanPham.Items.RemoveAt(lsvSanPham.SelectedIndices[0]);
                    setNull();
                }
            }
            else
                MessageBox.Show("Bạn phải chọn sản phẩm cần xóa");
        }
    }
}