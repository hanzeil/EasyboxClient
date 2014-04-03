using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//引用类库
using MySql.Data.MySqlClient;//导入用MySql的包 
using System.Data;//引用DataTable 

namespace EasyBoxClient.UserLogin
{
    public class ConnectMysql
    {
        private String host="xdtic.com";
        private String port="3306";
         #region  建立MySql数据库连接
        public MySqlConnection GetCon()
        {
            string str_sqlcon = "server=" + host + ";user id=easybox;password=ruanjiangongcheng;database=easybox;";
            MySqlConnection mysqlconn = new MySqlConnection(str_sqlcon);
            return mysqlconn;
        }
        #endregion
    }
}
