using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
namespace PhanMemQuanLyDoanThu
{
    public partial class FormNhaCungCap : Form
    {
        NhaCungCap ncc = new NhaCungCap();
        bool themmoi = false;
        public FormNhaCungCap()
        {
            InitializeComponent();
        }

        private void FormNhaCungCap_Load(object sender, EventArgs e)
        {
            int witdhScreen = Screen.PrimaryScreen.WorkingArea.Width;
            int heightScreen = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = witdhScreen;
            this.Height = heightScreen;
            HienThiNhaCungCap();
            setButton(true);
            setNull();
        }
        public void HienThiNhaCungCap()
        {
            lsvNhaCungCap.Items.Clear();
            DataTable dt = ncc.LayNhaCungCap();
            if(dt.Rows.Count > 0)
            {
                for(int i =0; i<dt.Rows.Count;i++)
                {
                    ListViewItem lvi = lsvNhaCungCap.Items.Add(dt.Rows[i][1].ToString());
                    lvi.SubItems.Add(dt.Rows[i][0].ToString());
                    lvi.SubItems.Add(dt.Rows[i][2].ToString());
                    lvi.SubItems.Add(dt.Rows[i][3].ToString());
                }
            }
        }
        public void setButton (bool val)
        {
            btnThem.Enabled = val;
            btnXoa.Enabled = val;
            btnSua.Enabled = val;
            btnThoat.Enabled = val;
            btnLuu.Enabled = !val;
            btnHuy.Enabled = !val;
        }
        public void setNull()
        {
            txtDiachi.Text = "";
            txtHotline.Text = "";
            txtMa.Text = "";
            txtTen.Text = "";
        }

        private void lsvNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhaCungCap.SelectedIndices.Count > 0)
            {
                txtMa.Text = lsvNhaCungCap.SelectedItems[0].SubItems[0].Text;
                txtTen.Text = lsvNhaCungCap.SelectedItems[0].SubItems[1].Text;
                txtDiachi.Text = lsvNhaCungCap.SelectedItems[0].SubItems[2].Text;
                txtHotline.Text = lsvNhaCungCap.SelectedItems[0].SubItems[3].Text;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormNhaCungCap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn muốn thoát ?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(lsvNhaCungCap.SelectedItems.Count > 0)
            {
                for(int i =0; i<lsvNhaCungCap.Items.Count;i++)
                {
                    if(lsvNhaCungCap.Items[i].Selected == true)
                    {
                        ncc.XoaNhaCungCap(lsvNhaCungCap.Items[i].SubItems[0].Text);
                        lsvNhaCungCap.Items[i].Remove();
                        i--;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Xin chọn nhà cung cấp muốn xóa ");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            setButton(false);
            setNull();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(themmoi == true)
            {
                ncc.ThemNhaCungCap(txtTen.Text, txtDiachi.Text, txtHotline.Text);
                HienThiNhaCungCap();
                setButton(true);
                setNull();
            }
            else
            {
                ncc.SuaNhaCungCap(txtMa.Text,txtTen.Text,txtDiachi.Text,txtHotline.Text);
                HienThiNhaCungCap();
                setButton(true);
                setNull();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            setNull();
            setButton(false);
            lsvNhaCungCap.MultiSelect = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setNull();
            setButton(true);
        }
    }
}
