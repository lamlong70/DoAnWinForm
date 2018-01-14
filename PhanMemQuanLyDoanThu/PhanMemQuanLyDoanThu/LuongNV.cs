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
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
            }
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
            HienBoPhan();
            HienChucVu();
            HienThiLuongNV();
        }
    }
}
