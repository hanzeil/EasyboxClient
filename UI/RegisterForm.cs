using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyBoxClient.UI
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserLogin.UserManager usma = new UserLogin.UserManager();
            usma.user = textBox1.Text;
            //usma.pass = textBox2.Text;
            usma.pass = UserLogin.UserManager.GetMD5Hash(textBox2.Text);
            if (usma.Register())
            {
                this.Close();
            }
            
        }

    }
}
