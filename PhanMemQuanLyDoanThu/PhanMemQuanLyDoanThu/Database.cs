using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PhanMemQuanLyDoanThu
{
    class Database
    {
        string DataBase = "QUANLYDOANHTHUDA";
        string DataSource = "TP500LA";
        
        SqlConnection sqlConn; //Doi tuong ket noi CSDL
        SqlDataAdapter da;//Bo dieu phoi du lieu
        DataSet ds; //Doi tuong chhua CSDL khi giao tiep
        public Database()
        {
//<<<<<<< HEAD
            string strCnn = @"Data Source="+DataSource+"; Database="+DataBase+";Integrated Security = True";
//=======
        //    string strCnn = @"Data Source=TP500LA; Database=QUANLYDOANHTHUDA;Integrated Security = True";
//>>>>>>> Dan
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
        }
       
    }
}
