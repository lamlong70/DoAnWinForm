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
    public partial class DangKy : DevExpress.XtraEditors.XtraForm
    {
        NhanVien nv = new NhanVien();
        public DangKy()
        {
            InitializeComponent();
        }

        public String conString = @"Data Source="+SystemInformation.ComputerName+ "\\SQLEXPRESS;Initial Catalog=QUANLYDOANHTHU;Integrated Security=True";

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            Close();
            DangNhap dn = new DangNhap();
            dn.Show();
        }

        private void DangKy_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult dr;
            //dr = XtraMessageBox.Show("Bạn có muốn huỷ không ?", "Thông Báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dr == DialogResult.No)
            //{
            //    e.Cancel = true;
                
            //}
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(conString)) 
            {
                if (txtMatkhau.Text == "" || txtTendn.Text == "")
                    MessageBox.Show("Hãy điền đầy đủ thông tin");
                else if (txtMatkhau.Text != txtNhaplai.Text)
                    MessageBox.Show("Mật khẩu không trùng nhau");
                else
                {/*
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("ThemNV", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Tennv", txtHovaTen.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@TenDn", txtTendn.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtMatkhau.Text.Trim());
                    sqlCmd.ExecuteNonQuery();*/
                    nv.ThemNhanVien(txtTendn.Text, txtMatkhau.Text);
                    MessageBox.Show("Đăng ký thành công");
                    DangNhap dn = new DangNhap();
                    dn.Show();
                    Hide();
                    Clear();
                }
            }
        }
        void Clear()
        {
            txtTendn.Text = txtMatkhau.Text = txtNhaplai.Text = "";
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            AcceptButton = btnDangky;
        }
    }
}