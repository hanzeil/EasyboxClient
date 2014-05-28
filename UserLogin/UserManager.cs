using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Easybox.UserLogin
{
    class UserManager
    {
        public String user;
        public String pass;
        public bool check;
        QueryDatabase querydb=new QueryDatabase();
        public bool Login(){
            try
            {
                if (user == string.Empty || user.Equals("Username"))
                {
                    MessageBox.Show("用户名称不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!querydb.IsUserExit(user))
                {
                    MessageBox.Show("用户名不存在！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!querydb.IsPassRight(user, pass))
                {
                    MessageBox.Show("密码错误！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("您已与服务器断开，请稍后再试！", "Easybox");
                return false;
            }
            return true;
            
        }
        public bool Register()
        {
            try
            {
                if (user == string.Empty || user.Equals("Username"))
                {
                    MessageBox.Show("用户名称不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (querydb.IsUserExit(user))
                {
                    MessageBox.Show("用户名已存在！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (pass == GetMD5Hash(string.Empty) || pass.Equals(GetMD5Hash("Password")))
                {
                    MessageBox.Show("密码不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!check)
                {
                    MessageBox.Show("请同意条款！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    querydb.AddUser(user, pass);
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("您已与服务器断开，请稍后再试！", "Easybox");
                return false;
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
