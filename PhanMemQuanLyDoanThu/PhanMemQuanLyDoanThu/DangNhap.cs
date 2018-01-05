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
using System.Data.SqlClient;


namespace PhanMemQuanLyDoanThu
{
    public partial class DangNhap : DevExpress.XtraEditors.XtraForm
    {
        public String conString = @"Data Source=TP500LA;Initial Catalog=QUANLYDOANHTHU;Integrated Security=True";
        NhanVien nv = new NhanVien();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            Form dangky = new DangKy();
            dangky.Show();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show("Bạn có muốn huỷ không ?", "Thông Báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(conString))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT Count(*) FROM NHANVIEN 
                                        WHERE TENDANGNHAP=@uname and 
                                        MATKHAU=@pass",sqlCon);
                cmd.Parameters.AddWithValue("@uname", txtTendn.Text);
                cmd.Parameters.AddWithValue("@pass", txtMatkhau.Text);
                int result = (int)cmd.ExecuteScalar();
                if (result > 0)
                    MessageBox.Show("Đăng nhập thành công");
                else
                    MessageBox.Show("Đăng nhập thất bại");
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            AcceptButton = btnOk;
        }
    }
}