using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//引用类库
using MySql.Data.MySqlClient;//导入用MySql的包 
using System.Data;//引用DataTable 
using System.Windows.Forms;
namespace Easybox.UserLogin
{
    public class ConnectMysql
    {
        private String host="xdtic.com";
         #region  建立MySql数据库连接
        public MySqlConnection GetCon()
        {
            MySqlConnection mysqlconn;
            try
            {
                string str_sqlcon = "server=" + host + ";user id=easybox;password=ruanjiangongcheng;database=easybox;";
                mysqlconn = new MySqlConnection(str_sqlcon);
                return mysqlconn;
            }
            catch (MySqlException)
            {
                MessageBox.Show("您已与服务器断开，请稍后再试！", "Easybox");
                return null;
            }
        }
        #endregion
    }
}
