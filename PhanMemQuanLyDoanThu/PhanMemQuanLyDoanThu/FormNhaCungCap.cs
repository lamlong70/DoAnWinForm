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
        }
        public void HienThiNhaCungCap()
        {
            DataTable dt = ncc.LayNhaCungCap();
            if(dt.Rows.Count > 0)
            {
                for(int i =0; i<dt.Rows.Count;i++)
                {
                    ListViewItem lvi = lsvNhaCungCap.Items.Add(dt.Rows[i][1].ToString());
                    lvi.SubItems.Add(dt.Rows[i][0].ToString());
                    lvi.SubItems.Add(dt.Rows[i][2].ToString());
                }
            }
        }

        private void lsvNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhaCungCap.SelectedIndices.Count > 0)
            {
                txtMa.Text = lsvNhaCungCap.SelectedItems[0].SubItems[0].Text;
                txtTen.Text = lsvNhaCungCap.SelectedItems[0].SubItems[1].Text;
                txtDiachi.Text = lsvNhaCungCap.SelectedItems[0].SubItems[2].Text;
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
    }
}
