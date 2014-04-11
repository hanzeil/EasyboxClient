using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace EasyboxClient.UI
{
    public partial class LoginForm : Form
    {
        Sync.TimingSyncThread t;
        public LoginForm()
        {
            InitializeComponent();
        }

        //--------窗体拖动---------
        Point mouseOff;//鼠标移动位置变量

        bool leftFlag;//标签是否为左键
        
        String FilePath="C:\\Users\\"+Environment.UserName+"\\Easybox";//同步文件夹路径

        //在窗体上按下发生事件
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//如果按下的是鼠标左键
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }

        }
        //鼠标移动的事件
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (leftFlag)//如果鼠标左键是按下的状态
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }

        }
        //鼠标松开的事件
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)//如果鼠标左键是松开的状态
            {
                leftFlag = false;//释放鼠标后标注为false;
            }

        }


        //点击注册，跳转注册页面
        private void lableRegist_Click(object sender, EventArgs e)
        {
            labelRegist.Visible = false;
            labelLogin.Visible = true;
            buttomRegister.Visible = true;
            buttonLogin.Visible = false;
        }
        //点击登陆，跳转登陆页面
        private void labelLogin_Click(object sender, EventArgs e)
        {
            labelRegist.Visible = true;
            labelLogin.Visible = false;
            buttomRegister.Visible = false;
            buttonLogin.Visible = true;
        }
        //单击登陆按钮事件
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            UserLogin.UserManager usma = new UserLogin.UserManager();
            usma.user = textBoxUser.Text;
            //usma.pass = textBox2.Text;
            usma.pass = UserLogin.UserManager.GetMD5Hash(textBoxPass.Text);
            if (usma.Login())
            {
                //暂时先放在这，如果没有FilePath，则创建之，
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                this.Hide();
                this.notifyIcon1.Visible = true;
                StreamWriter sw = new StreamWriter("test.txt",false);
                sw.WriteLine(FilePath);
                sw.WriteLine(usma.user);
                sw.Write(usma.pass);
                sw.Close();
                File.SetAttributes("test.txt", FileAttributes.Hidden);
                String hostName = usma.user + "+" + Dns.GetHostName();
                t=new Sync.TimingSyncThread(hostName, FilePath);
                
            }
        }



        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   


        //自动登陆
        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (File.Exists("test.txt")) 
            {
                this.Hide();
                this.ShowInTaskbar = false;
                StreamReader sr = new StreamReader("test.txt");
                UserLogin.UserManager usma = new UserLogin.UserManager();
                FilePath = sr.ReadLine();
                usma.user = sr.ReadLine();
                usma.pass = sr.ReadToEnd();
                sr.Close();
                if (usma.Login())
                {
                    this.notifyIcon1.Visible = true;
                    string hostName = usma.user + "+" + Dns.GetHostName();
                    t=new Sync.TimingSyncThread(hostName, FilePath);

                }
                else 
                {
                    this.Show();
                    this.ShowInTaskbar = true;
                }
            }
        }
     
        //注册
        private void buttomRegister_Click(object sender, EventArgs e)
        {
            UserLogin.UserManager usma = new UserLogin.UserManager();
            usma.user = textBoxUser.Text;
            //usma.pass = textBox2.Text;
            usma.pass = UserLogin.UserManager.GetMD5Hash(textBoxPass.Text);
            if (usma.Register())
            {
                MessageBox.Show("注册成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //回车
        private void textBoxPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)//判断是否按下Enter键
                if (buttonLogin.Visible == true)
                {
                    buttonLogin_Click(sender, e);// btnLogin.Focus();//将鼠标焦点移动到“登录”按钮
                }
                else 
                {
                    buttomRegister_Click(sender, e);
                }
        }
        //双击托盘图标事件
        private void notifyIcon1_MouseDoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(FilePath);
        }
        //点击退出事件
        private void Exit_Click(object sender, EventArgs e)
        {
            //退出同步线程
            t.Abort();
            Application.Exit();
        }
        //点击注销事件
        private void Logout_Click(object sender, EventArgs e)
        {
            File.Delete("test.txt");
            //重启程序
            t.Abort();
            textBoxUser.Text = "";
            textBoxPass.Text = "";
            this.Show();
            this.ShowInTaskbar = true;
            
        }
        //点击更改目录事件
        private void ChangeMenu_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                FilePath = FolderBrowserDialog1.SelectedPath;
                //重启程序
                t.Abort();
                File.Delete("test.txt");
                StreamWriter sw = new StreamWriter("test.txt", false);
                sw.WriteLine(FilePath);
                sw.WriteLine(textBoxUser.Text);
                sw.Write(UserLogin.UserManager.GetMD5Hash(textBoxPass.Text));
                sw.Close();
                File.SetAttributes("test.txt", FileAttributes.Hidden);
                String hostName = textBoxUser.Text + "+" + Dns.GetHostName();
                t = new Sync.TimingSyncThread(hostName, FilePath);
            }
        }

    }
}
