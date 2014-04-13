namespace EasyboxClient.UI
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
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.PictureBox();
            this.TurnToReg = new System.Windows.Forms.PictureBox();
            this.TurnToLogin = new System.Windows.Forms.PictureBox();
            this.buttonRegister = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.PictureBox();
            this.buttonMin = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnToReg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnToLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMin)).BeginInit();
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
            // textBoxPass
            // 
            this.textBoxPass.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPass.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPass.ForeColor = System.Drawing.Color.Silver;
            this.textBoxPass.Location = new System.Drawing.Point(78, 286);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(131, 22);
            this.textBoxPass.TabIndex = 5;
            this.textBoxPass.Tag = "";
            this.textBoxPass.Text = "Password";
            this.textBoxPass.UseSystemPasswordChar = true;
            this.textBoxPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPass_KeyDown);
            this.textBoxPass.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxPass_KeyUp);
            this.textBoxPass.Validated += new System.EventHandler(this.textBoxPass_Validated);
            // 
            // textBoxUser
            // 
            this.textBoxUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUser.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUser.ForeColor = System.Drawing.Color.Silver;
            this.textBoxUser.Location = new System.Drawing.Point(77, 247);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(132, 22);
            this.textBoxUser.TabIndex = 4;
            this.textBoxUser.Text = "Username";
            this.textBoxUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUser_KeyDown);
            this.textBoxUser.Validated += new System.EventHandler(this.textBoxUser_Validated);
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogin.Image = global::EasyboxClient.Properties.Resources.Right;
            this.buttonLogin.Location = new System.Drawing.Point(164, 340);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(46, 46);
            this.buttonLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonLogin.TabIndex = 11;
            this.buttonLogin.TabStop = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            this.buttonLogin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonBoxLogin_MouseDown);
            this.buttonLogin.MouseLeave += new System.EventHandler(this.buttonBoxLogin_MouseLeave);
            this.buttonLogin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonBoxLogin_MouseMove);
            // 
            // TurnToReg
            // 
            this.TurnToReg.BackColor = System.Drawing.Color.Transparent;
            this.TurnToReg.Image = global::EasyboxClient.Properties.Resources.Register;
            this.TurnToReg.Location = new System.Drawing.Point(46, 340);
            this.TurnToReg.Margin = new System.Windows.Forms.Padding(2);
            this.TurnToReg.Name = "TurnToReg";
            this.TurnToReg.Size = new System.Drawing.Size(46, 46);
            this.TurnToReg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TurnToReg.TabIndex = 12;
            this.TurnToReg.TabStop = false;
            this.TurnToReg.Click += new System.EventHandler(this.TurnToReg_Click);
            this.TurnToReg.DragLeave += new System.EventHandler(this.TurnToReg_DragLeave);
            this.TurnToReg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TurnToReg_MouseDown);
            this.TurnToReg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TurnToReg_MouseMove);
            // 
            // TurnToLogin
            // 
            this.TurnToLogin.BackColor = System.Drawing.Color.Transparent;
            this.TurnToLogin.Image = global::EasyboxClient.Properties.Resources.Left;
            this.TurnToLogin.Location = new System.Drawing.Point(46, 340);
            this.TurnToLogin.Name = "TurnToLogin";
            this.TurnToLogin.Size = new System.Drawing.Size(46, 46);
            this.TurnToLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TurnToLogin.TabIndex = 13;
            this.TurnToLogin.TabStop = false;
            this.TurnToLogin.Visible = false;
            this.TurnToLogin.Click += new System.EventHandler(this.TurnToLogin_Click);
            this.TurnToLogin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TurnToLogin_MouseDown);
            this.TurnToLogin.MouseLeave += new System.EventHandler(this.TurnToLogin_MouseLeave);
            this.TurnToLogin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TurnToLogin_MouseMove);
            // 
            // buttonRegister
            // 
            this.buttonRegister.BackColor = System.Drawing.Color.Transparent;
            this.buttonRegister.Image = global::EasyboxClient.Properties.Resources.Right;
            this.buttonRegister.Location = new System.Drawing.Point(164, 340);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(46, 46);
            this.buttonRegister.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonRegister.TabIndex = 14;
            this.buttonRegister.TabStop = false;
            this.buttonRegister.Visible = false;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            this.buttonRegister.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonBoxRegister_MouseDown);
            this.buttonRegister.MouseLeave += new System.EventHandler(this.buttonBoxRegister_MouseLeave);
            this.buttonRegister.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonBoxRegister_MouseMove);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.Image = global::EasyboxClient.Properties.Resources.Close;
            this.buttonExit.Location = new System.Drawing.Point(219, 0);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(43, 21);
            this.buttonExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonExit.TabIndex = 15;
            this.buttonExit.TabStop = false;
            this.buttonExit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonExit_MouseClick);
            this.buttonExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonExit_MouseDown);
            this.buttonExit.MouseLeave += new System.EventHandler(this.buttonExit_MouseLeave);
            this.buttonExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonExit_MouseMove);
            // 
            // buttonMin
            // 
            this.buttonMin.BackColor = System.Drawing.Color.Transparent;
            this.buttonMin.Image = global::EasyboxClient.Properties.Resources.Min;
            this.buttonMin.Location = new System.Drawing.Point(194, 0);
            this.buttonMin.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMin.Name = "buttonMin";
            this.buttonMin.Size = new System.Drawing.Size(26, 21);
            this.buttonMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonMin.TabIndex = 16;
            this.buttonMin.TabStop = false;
            this.buttonMin.Click += new System.EventHandler(this.buttonMin_Click);
            this.buttonMin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMin_MouseDown);
            this.buttonMin.MouseLeave += new System.EventHandler(this.buttonMin_MouseLeave);
            this.buttonMin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonMin_MouseMove);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.checkBox1.Location = new System.Drawing.Point(46, 318);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 21);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "我同意条款";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::EasyboxClient.Properties.Resources.UI;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(262, 443);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonMin);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.TurnToLogin);
            this.Controls.Add(this.TurnToReg);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.Deactivate += new System.EventHandler(this.LoginForm_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnToReg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnToLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMin)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem ToolStripLogout;
        private System.Windows.Forms.ToolStripMenuItem ToolStripChangeMenu;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        private System.Windows.Forms.PictureBox buttonLogin;
        private System.Windows.Forms.PictureBox TurnToReg;
        private System.Windows.Forms.PictureBox TurnToLogin;
        private System.Windows.Forms.PictureBox buttonRegister;
        private System.Windows.Forms.PictureBox buttonExit;
        private System.Windows.Forms.PictureBox buttonMin;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

