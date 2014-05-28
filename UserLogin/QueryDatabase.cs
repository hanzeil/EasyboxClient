using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//引用类库
using System.Windows.Forms;
using MySql.Data.MySqlClient;//导入用MySql的包 
using System.Data;//引用DataTable 

namespace Easybox.UserLogin
{
    public class QueryDatabase:ConnectMysql
    {
        String table = "login";
        public DataTable Selectinfo(string sql)
        {
            MySqlConnection mysqlconn = null;
            MySqlDataAdapter sda = null;
            DataTable dt = null;
            try
            {
                mysqlconn = base.GetCon();
                sda = new MySqlDataAdapter(sql, mysqlconn);
                dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool IsUserExit(String user) {
            String sqlword = "select* from " + table + " where username='" + user + "'";
            DataTable dt = Selectinfo(sqlword);
            try
            {
                if (dt.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool IsPassRight(String user, String pass) 
        {
            String sqlword = "select* from " + table + " where username='" + user + "' AND password='" + pass + "'";
            DataTable dt = Selectinfo(sqlword);
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void AddUser(String user, String pass)
        {
            String sqlword = "insert into " + table + "(username,password)VALUES('" + user + "','" + pass + "')";
            Selectinfo(sqlword);
        }
    }
}
