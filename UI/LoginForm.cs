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
using System.Threading;
using System.Runtime.InteropServices;

namespace Easybox.UI
{
    public partial class LoginForm : Form
    {
        Sync.TimingSyncThread t;
        [DllImportAttribute("user32.dll")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        public const Int32 AW_HOR_POSITIVE = 0x00000001;
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;
        public const Int32 AW_VER_POSITIVE = 0x00000004;
        public const Int32 AW_VER_NEGATIVE = 0x00000008;
        public const Int32 AW_CENTER = 0x00000010;
        public const Int32 AW_HIDE = 0x00010000;
        public const Int32 AW_ACTIVATE = 0x00020000;
        public const Int32 AW_SLIDE = 0x00040000;
        public const Int32 AW_BLEND = 0x00080000;
        public LoginForm()
        {
            InitializeComponent();
            textBoxUser.SelectionStart = 0;
            textBoxPass.SelectionStart = 0;
            if (!File.Exists("C:\\users\\"+Environment.UserName+"\\AppData\\Roaming\\Easybox\\test.txt"))
            {
                AnimateWindow(this.Handle, 500, AW_HOR_POSITIVE);
            }
        }

        //--------窗体拖动---------
        Point mouseOff;//鼠标移动位置变量

        bool leftFlag;//标签是否为左键
        
        String FilePath="C:\\Users\\"+Environment.UserName+"\\Documents\\Easybox";//同步文件夹路径

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

        //单击登陆按钮事件
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            UserLogin.UserManager usma = new UserLogin.UserManager();
            usma.user = textBoxUser.Text;
            usma.pass = UserLogin.UserManager.GetMD5Hash(textBoxPass.Text);
            if (usma.Login())
            {
                //暂时先放在这，如果没有FilePath，则创建之，
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                MessageBox.Show("登录成功，双击托盘图标打开同步的文件夹！", "Easybox");
                this.Hide();
                this.notifyIcon1.Visible = true;
                StreamWriter sw = new StreamWriter("C:\\users\\"+Environment.UserName+"\\AppData\\Roaming\\Easybox\\test.txt",false);
                sw.WriteLine(FilePath);
                sw.WriteLine(usma.user);
                sw.Write(usma.pass);
                sw.Close();
                File.SetAttributes("C:\\users\\"+Environment.UserName+"\\AppData\\Roaming\\Easybox\\test.txt", FileAttributes.Hidden);
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
            if (File.Exists("C:\\users\\"+Environment.UserName+"\\AppData\\Roaming\\Easybox\\test.txt")) 
            {
                this.Hide();
                this.ShowInTaskbar = false;  
                StreamReader sr = new StreamReader("C:\\users\\"+Environment.UserName+"\\AppData\\Roaming\\Easybox\\test.txt");
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
                    //this.Show();
                    this.ShowInTaskbar = true;
                }
            }
        }
     
        //注册
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            
            UserLogin.UserManager usma = new UserLogin.UserManager();
            usma.user = textBoxUser.Text;
            usma.pass = UserLogin.UserManager.GetMD5Hash(textBoxPass.Text);
            usma.check = checkBox1.Checked;
            if (usma.Register())
            {
                  MessageBox.Show("注册成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  TurnToLogin_Click(sender, e);
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
                    buttonRegister_Click(sender, e);
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
            File.Delete("C:\\users\\"+Environment.UserName+"\\AppData\\Roaming\\Easybox\\test.txt");
            //重启程序
            t.Abort();
            textBoxUser.Text = "Username";
            textBoxUser.ForeColor = Color.Silver;
            textBoxUser.SelectionStart = 0;
            textBoxPass.Text = "Passwrod";
            textBoxPass.ForeColor = Color.Silver;
            this.Show();
            this.ShowInTaskbar = true;
            textBoxUser.Focus();
            
        }
        //点击更改目录事件
        private void ChangeMenu_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                FilePath = FolderBrowserDialog1.SelectedPath;
                //重启程序
                t.Abort();
                File.Delete("C:\\users\\"+Environment.UserName+"\\AppData\\Roaming\\Easybox\\test.txt");
                StreamWriter sw = new StreamWriter("C:\\users\\"+Environment.UserName+"\\AppData\\Roaming\\Easybox\\test.txt", false);
                sw.WriteLine(FilePath);
                sw.WriteLine(textBoxUser.Text);
                sw.Write(UserLogin.UserManager.GetMD5Hash(textBoxPass.Text));
                sw.Close();
                File.SetAttributes("C:\\users\\"+Environment.UserName+"\\AppData\\Roaming\\Easybox\\test.txt", FileAttributes.Hidden);
                String hostName = textBoxUser.Text + "+" + Dns.GetHostName();
                t = new Sync.TimingSyncThread(hostName, FilePath);
            }
        }
        private void textBoxUser_KeyDown(object sender, KeyEventArgs e)
        {
           if (textBoxUser.Text == "Username")
            {
                textBoxUser.Text = "";
                textBoxUser.ForeColor = Color.Black;
                
            }
        }
        private void textBoxUser_Validated(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "")
            {
                textBoxUser.Text = "Username";
                textBoxUser.ForeColor = Color.Silver;
            }
        }
        private void textBoxPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxPass.Text == "Password")
            {
                textBoxPass.Text = "";
                textBoxPass.ForeColor = Color.Black;

            }
        }
        private void textBoxPass_Validated(object sender, EventArgs e)
        {
            if (textBoxPass.Text == "")
            {
                textBoxPass.Text = "Password";
                textBoxPass.ForeColor = Color.Silver;
            }
        }
        private void TurnToReg_Click(object sender, EventArgs e)
        {
            TurnToReg.Visible=false;
            buttonLogin.Visible = false;
            textBoxUser.Visible = false;
            textBoxPass.Visible = false;
            Application.DoEvents();
            Thread.Sleep(300);
            checkBox1.Visible = true;
            TurnToLogin.Visible = true;
            buttonRegister.Visible = true;
            textBoxUser.Visible = true;
            textBoxPass.Visible = true;
            
        }
        private void TurnToLogin_Click(object sender, EventArgs e)
        {
            TurnToLogin.Visible = false;
            buttonRegister.Visible = false;
            textBoxUser.Visible = false;
            textBoxPass.Visible = false;
            checkBox1.Visible = false;
            Application.DoEvents();
            Thread.Sleep(300);
            TurnToReg.Visible = true;
            buttonLogin.Visible = true;
            textBoxUser.Visible = true;
            textBoxPass.Visible = true;
        }

        private void buttonBoxLogin_MouseDown(object sender, MouseEventArgs e)
        {
            this.buttonLogin.Image = global::Easybox.Properties.Resources.Right_down;
        }

        private void buttonBoxLogin_MouseMove(object sender, MouseEventArgs e)
        {
            this.buttonLogin.Image = global::Easybox.Properties.Resources.Right_move;
        }

        private void buttonBoxLogin_MouseLeave(object sender, EventArgs e)
        {
            this.buttonLogin.Image = global::Easybox.Properties.Resources.Right;
        }

        private void TurnToLogin_MouseDown(object sender, MouseEventArgs e)
        {
            this.TurnToLogin.Image = global::Easybox.Properties.Resources.Left_down;
        }

        private void TurnToLogin_MouseMove(object sender, MouseEventArgs e)
        {
            this.TurnToLogin.Image = global::Easybox.Properties.Resources.Left_move;
        }

        private void TurnToLogin_MouseLeave(object sender, EventArgs e)
        {
            this.TurnToLogin.Image = global::Easybox.Properties.Resources.Left;
        }

        private void TurnToReg_DragLeave(object sender, EventArgs e)
        {
            this.TurnToReg.Image = global::Easybox.Properties.Resources.Register;
        }

        private void TurnToReg_MouseMove(object sender, MouseEventArgs e)
        {
            this.TurnToReg.Image = global::Easybox.Properties.Resources.Register_move;
        }

        private void TurnToReg_MouseDown(object sender, MouseEventArgs e)
        {
            this.TurnToReg.Image = global::Easybox.Properties.Resources.Register_down;
        }

        private void buttonBoxRegister_MouseLeave(object sender, EventArgs e)
        {
            this.buttonRegister.Image = global::Easybox.Properties.Resources.Right;
        }

        private void buttonBoxRegister_MouseDown(object sender, MouseEventArgs e)
        {
            this.buttonRegister.Image = global::Easybox.Properties.Resources.Right_down;
        }

        private void buttonBoxRegister_MouseMove(object sender, MouseEventArgs e)
        {
            this.buttonRegister.Image = global::Easybox.Properties.Resources.Right_move;
        }

        private void buttonExit_MouseDown(object sender, MouseEventArgs e)
        {
            this.buttonExit.Image = global::Easybox.Properties.Resources.Close_down;
        }

        private void buttonExit_MouseMove(object sender, MouseEventArgs e)
        {
            this.buttonExit.Image = global::Easybox.Properties.Resources.Close_move;
        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            this.buttonExit.Image = global::Easybox.Properties.Resources.Close;
        }

        private void buttonExit_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void buttonMin_MouseDown(object sender, MouseEventArgs e)
        {
            this.buttonMin.Image = global::Easybox.Properties.Resources.Min_Down;
        }

        private void buttonMin_MouseMove(object sender, MouseEventArgs e)
        {
            this.buttonMin.Image = global::Easybox.Properties.Resources.Min_move;
        }

        private void buttonMin_MouseLeave(object sender, EventArgs e)
        {
            this.buttonMin.Image = global::Easybox.Properties.Resources.Min;
        }

        private void buttonMin_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AnimateWindow(this.Handle, 500, AW_HOR_NEGATIVE + AW_HIDE);
        }

        private void LoginForm_Deactivate(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            AnimateWindow(this.Handle, 500, AW_VER_POSITIVE + AW_HIDE);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
