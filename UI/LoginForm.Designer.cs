﻿namespace EasyboxClient.UI
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripChangeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.labelRegist = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.loginButtonBox = new System.Windows.Forms.PictureBox();
            this.registerButtionBox = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginButtonBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerButtionBox)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "easybox";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripChangeMenu,
            this.ToolStripLogout,
            this.ToolStripExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // ToolStripChangeMenu
            // 
            this.ToolStripChangeMenu.Name = "ToolStripChangeMenu";
            this.ToolStripChangeMenu.Size = new System.Drawing.Size(124, 22);
            this.ToolStripChangeMenu.Text = "更改目录";
            this.ToolStripChangeMenu.Click += new System.EventHandler(this.ChangeMenu_Click);
            // 
            // ToolStripLogout
            // 
            this.ToolStripLogout.Name = "ToolStripLogout";
            this.ToolStripLogout.Size = new System.Drawing.Size(124, 22);
            this.ToolStripLogout.Text = "注销";
            this.ToolStripLogout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // ToolStripExit
            // 
            this.ToolStripExit.Name = "ToolStripExit";
            this.ToolStripExit.Size = new System.Drawing.Size(124, 22);
            this.ToolStripExit.Text = "退出";
            this.ToolStripExit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::EasyboxClient.Properties.Resources.UI;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(262, 443);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.ForeColor = System.Drawing.Color.Transparent;
            this.buttonExit.Location = new System.Drawing.Point(232, 0);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(23, 23);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelRegist
            // 
            this.labelRegist.AutoSize = true;
            this.labelRegist.BackColor = System.Drawing.Color.Transparent;
            this.labelRegist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelRegist.ForeColor = System.Drawing.Color.Honeydew;
            this.labelRegist.Location = new System.Drawing.Point(218, 410);
            this.labelRegist.Name = "labelRegist";
            this.labelRegist.Size = new System.Drawing.Size(29, 12);
            this.labelRegist.TabIndex = 8;
            this.labelRegist.Text = "注册";
            this.labelRegist.Click += new System.EventHandler(this.lableRegist_Click);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.BackColor = System.Drawing.Color.Transparent;
            this.labelLogin.ForeColor = System.Drawing.Color.Honeydew;
            this.labelLogin.Location = new System.Drawing.Point(218, 424);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(29, 12);
            this.labelLogin.TabIndex = 10;
            this.labelLogin.Text = "登陆";
            this.labelLogin.Visible = false;
            this.labelLogin.Click += new System.EventHandler(this.labelLogin_Click);
            // 
            // textBoxPass
            // 
            this.textBoxPass.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPass.Font = new System.Drawing.Font("YouYuan", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPass.ForeColor = System.Drawing.Color.Silver;
            this.textBoxPass.Location = new System.Drawing.Point(86, 282);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(112, 15);
            this.textBoxPass.TabIndex = 5;
            this.textBoxPass.Tag = "";
            this.textBoxPass.Text = "Password";
            this.textBoxPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPass_KeyDown);
            this.textBoxPass.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxPass_KeyUp);
            this.textBoxPass.Validated += new System.EventHandler(this.textBoxPass_Validated);
            // 
            // textBoxUser
            // 
            this.textBoxUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUser.Font = new System.Drawing.Font("YouYuan", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxUser.ForeColor = System.Drawing.Color.Silver;
            this.textBoxUser.Location = new System.Drawing.Point(86, 247);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(112, 15);
            this.textBoxUser.TabIndex = 4;
            this.textBoxUser.Text = "Username";
            this.textBoxUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUser_KeyDown);
            this.textBoxUser.Validated += new System.EventHandler(this.textBoxUser_Validated);
            // 
            // loginButtonBox
            // 
            this.loginButtonBox.BackColor = System.Drawing.Color.Transparent;
            this.loginButtonBox.Image = global::EasyboxClient.Properties.Resources.Right;
            this.loginButtonBox.Location = new System.Drawing.Point(174, 339);
            this.loginButtonBox.Margin = new System.Windows.Forms.Padding(2);
            this.loginButtonBox.Name = "loginButtonBox";
            this.loginButtonBox.Size = new System.Drawing.Size(46, 54);
            this.loginButtonBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loginButtonBox.TabIndex = 11;
            this.loginButtonBox.TabStop = false;
            this.loginButtonBox.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // registerButtionBox
            // 
            this.registerButtionBox.BackColor = System.Drawing.Color.Transparent;
            this.registerButtionBox.Image = global::EasyboxClient.Properties.Resources.Left;
            this.registerButtionBox.Location = new System.Drawing.Point(0, 381);
            this.registerButtionBox.Margin = new System.Windows.Forms.Padding(2);
            this.registerButtionBox.Name = "registerButtionBox";
            this.registerButtionBox.Size = new System.Drawing.Size(46, 46);
            this.registerButtionBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.registerButtionBox.TabIndex = 12;
            this.registerButtionBox.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::EasyboxClient.Properties.Resources.UI;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(262, 443);
            this.Controls.Add(this.registerButtionBox);
            this.Controls.Add(this.loginButtonBox);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.labelRegist);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginButtonBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerButtionBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripLogout;
        private System.Windows.Forms.ToolStripMenuItem ToolStripChangeMenu;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        private System.Windows.Forms.Label labelRegist;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.PictureBox loginButtonBox;
        private System.Windows.Forms.PictureBox registerButtionBox;
    }
}

