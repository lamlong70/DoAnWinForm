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
using System.Windows.Forms;


namespace PhanMemQuanLyDoanThu
{
    public partial class DangNhap : DevExpress.XtraEditors.XtraForm
    {
        public String conString = @"Data Source="+SystemInformation.ComputerName+";Initial Catalog=QUANLYDOANHTHUDA;Integrated Security=True";
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
            Hide();
            dangky.Show();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection sqlCon = new SqlConnection(conString))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT Count(*) FROM DANGKY
                                        WHERE TENDANGNHAP=@uname and 
                                        MATKHAU=@pass",sqlCon);
                cmd.Parameters.AddWithValue("@uname", txtTendn.Text);
                cmd.Parameters.AddWithValue("@pass", txtMatkhau.Text);
                int result = (int)cmd.ExecuteScalar();
                if (result > 0)
                {
<<<<<<< HEAD
                    DataTable dt = nv.PhanQuyen();
                    frmMain child = new frmMain();

                    if (dt.Rows[0][0].ToString() == "admin")
                    {
                        MessageBox.Show("chào mừng admin:  " + txtTendn.Text);
                        
                        child.setButton(true);
                        child.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("chào mừng nhân viên:  " + txtTendn.Text);
                        
                        child.setButton(true);
                        child.Show();
                        this.Hide();

                    }

=======
                    XtraMessageBox.Show("Đăng nhập thành công");
                    frmMain Child = new frmMain();
                    Child.setButton(true);
                    Child.Show();
                    this.Hide();
>>>>>>> 0958b6a8d5f38a7dfc63c7ca8d7edcbfe70df963
                }
                else
                {
                    XtraMessageBox.Show("Đăng nhập thất bại");
                }

            }
        }
        
        private void DangNhap_Load(object sender, EventArgs e)
        {
           
            AcceptButton = btnOk;
        }

        private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
