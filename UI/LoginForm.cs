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



        //单击登陆按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            UserLogin.UserManager usma = new UserLogin.UserManager();
            usma.user = textBox1.Text;
            //usma.pass = textBox2.Text;
            usma.pass = UserLogin.UserManager.GetMD5Hash(textBox2.Text);
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
                new Sync.TimingSyncThread(hostName, FilePath);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //注册
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm reg = new RegisterForm();
            DialogResult dr = reg.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.Show();
            }
        }
        //双击托盘图标事件
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(FilePath);
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
                if (usma.Login())
                {
                    this.notifyIcon1.Visible = true;
                    string hostName = usma.user + "+" + Dns.GetHostName();
                    new Sync.TimingSyncThread(hostName, FilePath);

                }
                else 
                {
                    this.Show();
                    this.ShowInTaskbar = true;
                }
            }
        }

        //点击退出事件
        private void Exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
        //点击注销事件
        private void Logout_Click(object sender, EventArgs e)
        {
            File.Delete("test.txt");
            this.Close();
        }
        //点击更改目录事件
        private void ChangeMenu_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                FilePath = FolderBrowserDialog1.SelectedPath;
                MessageBox.Show(FolderBrowserDialog1.SelectedPath, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
