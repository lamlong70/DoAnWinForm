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
    public partial class ChiPhiVatLieu : Form
    {
        SanPham sp = new SanPham();
        public ChiPhiVatLieu()
        {
            InitializeComponent();
        }
        void HienThang()
        {
            DataTable dt = sp.HienThang();
            cboThang.DataSource = dt;
            cboThang.DisplayMember = "NGAYNHAP";
            cboThang.ValueMember = "NGAYNHAP";
        }
        void HienNam()
        {
            DataTable dt = sp.HienNam();
            cboNam.DataSource = dt;
            cboNam.DisplayMember = "NAMNHAP";
            cboNam.ValueMember = "NAMNHAP";
        }
        void HienThiSanPham()
        {
            lsvDanhSachNguyenLieu.Items.Clear();
            DataTable dt = sp.HienChiPhiVatLieu(cboThang.SelectedValue.ToString(), cboNam.SelectedValue.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvDanhSachNguyenLieu.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString()+" VNĐ");
            }
        }
        private void ChiPhiVatLieu_Load(object sender, EventArgs e)
        {
            int witdhScreen = Screen.PrimaryScreen.WorkingArea.Width;
            int heightScreen = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = witdhScreen;
            this.Height = heightScreen;
            HienThang();
            HienNam();
            AcceptButton = btnXem;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            HienThiSanPham();
        }
    }
}
