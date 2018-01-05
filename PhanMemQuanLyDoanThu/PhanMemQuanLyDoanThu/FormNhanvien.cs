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
        NhanVien nv = new NhanVien();
        public FormNhanvien()
        {
            InitializeComponent();
        }

        void HienThiNhanVien()
        {
            DataTable dt = nv.LayDSNhanvien();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                ListViewItem lvi = lsvNhanVien.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());

            }
        }

        private void FormNhanvien_Load(object sender, EventArgs e)
        {

        }

        
    }
}