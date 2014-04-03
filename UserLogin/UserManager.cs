using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace EasyboxClient.UserLogin
{
    class UserManager
    {
        public String user;
        public String pass;
        QueryDatabase querydb=new QueryDatabase();
        public bool Login(){
            if (user == string.Empty)
            {
                MessageBox.Show("用户名称不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!querydb.IsUserExit(user))
            {
                MessageBox.Show("用户名不存在！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!querydb.IsPassRight(user,pass))
            {
                MessageBox.Show("密码错误！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
            
        }
        public bool Register()
        {
            if (user == string.Empty)
            {
                MessageBox.Show("用户名称不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (querydb.IsUserExit(user))
            {
                MessageBox.Show("用户名已存在！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else 
            {
                querydb.AddUser(user, pass);
                MessageBox.Show("注册成功", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
        }
        public static String GetMD5Hash(String input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] res = md5.ComputeHash(Encoding.Default.GetBytes(input), 0, input.Length);
            char[] temp = new char[res.Length];
            System.Array.Copy(res, temp, res.Length);
            return new String(temp);
        } 
    }
}
