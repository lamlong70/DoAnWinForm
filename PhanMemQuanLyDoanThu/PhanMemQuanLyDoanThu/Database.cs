using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PhanMemQuanLyDoanThu
{
    class Database
    {
        string DataBase = "QUANLYDOANHTHUDA";
        string DataSource = SystemInformation.ComputerName;

        SqlConnection sqlConn; //Doi tuong ket noi CSDL
        SqlDataAdapter da;//Bo dieu phoi du lieu
        DataSet ds; //Doi tuong chhua CSDL khi giao tiep
        public Database()
        {
            string strCnn = @"Data Source="+DataSource+"; Database="+DataBase+";Integrated Security = True";
            sqlConn = new SqlConnection(strCnn);
        }
        
        //Phuong thuc de thuc hien cau lenh strSQL truy vân du lieu
        public DataTable Execute(string sqlStr)
        {
            da = new SqlDataAdapter(sqlStr, sqlConn);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        //Phuong thuc de thuc hien cac lenh Them, Xoa, Sua
        public void ExecuteNonQuery(string strSQL)
        {
            SqlCommand sqlcmd = new SqlCommand(strSQL, sqlConn);
            sqlConn.Open(); //Mo ket noi
            sqlcmd.ExecuteNonQuery();//Lenh hien lenh Them/Xoa/Sua
            sqlConn.Close();//Dong ket noi
        }
        public void BackupDatabase(string Link)
        {
            string strCnn = @"Data Source=" + DataSource + "; Database=" + DataBase + ";Integrated Security = True";
            sqlConn = new SqlConnection(strCnn);
            sqlConn.Open();
            string sql = "BACKUP DATABASE " + DataBase + " TO DISK = '" + Link + "\\"+DataBase+"-"+DateTime.Now.Ticks.ToString()+".bak'";
            SqlCommand sqlcmd = new SqlCommand(sql, sqlConn);
            sqlcmd.ExecuteNonQuery();
            //sqlConn.Close();
        }
        public void RestoreDatabase(string link)
        {
            string strCnn = @"Data Source=" + DataSource + "; Database=" + DataBase + ";Integrated Security = True";
            sqlConn = new SqlConnection(strCnn);
            sqlConn.Open();
            string sql = "ALTER DATABASE "+DataBase+ " SET SINGLE_USER WITH ROLLBACK IMMEDIATE; ";
            sql += "USE master; RESTORE DATABASE "+DataBase+" FROM DISK= '"+link+"' WITH REPLACE;";
            SqlCommand sqlcmd = new SqlCommand(sql, sqlConn);
            sqlcmd.ExecuteNonQuery();
            sqlConn.Close();
            sqlConn.Dispose();
        }
       
    }
}
