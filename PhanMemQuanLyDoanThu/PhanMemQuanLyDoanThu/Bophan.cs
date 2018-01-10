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
    public partial class Bophan : DevExpress.XtraEditors.XtraForm
    {
        NhanVien nv = new NhanVien();
        public Bophan()
        {
            InitializeComponent();
        }
        void HienBoPhan()
        {
            DataTable dt = nv.LayBoPhan();
            cboBoPhan.DataSource = dt;
            cboBoPhan.DisplayMember = "TENBOPHAN";
            cboBoPhan.ValueMember = "MABOPHAN";
        }
        private void Bophan_Load(object sender, EventArgs e)
        {
            HienBoPhan();
            AcceptButton = btnXem;
        }
        void HienThiNhanVien()
        {
            lsvNhanVien.Items.Clear();
            DataTable dt = nv.LayDSNhanvienBoPhan(cboBoPhan.SelectedValue.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
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
        private void btnXem_Click(object sender, EventArgs e)
        {
            HienThiNhanVien();
        }

        private void cboBoPhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}