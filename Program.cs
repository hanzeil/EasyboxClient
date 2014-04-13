using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Easybox
{
    public class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        System.Threading.Mutex mutex;//注意，此变量要定义为成员变量，而不是局部变量
        private bool CheckMultiInstance()
        {
            bool createdNew = true;
            mutex = new System.Threading.Mutex(true, "_TEST_Mutex_", out createdNew);//这种在系统多用户下，每个用户能启动一个程序进程。
            //mutex = new System.Threading.Mutex(true, "Global\\_TEST_Mutex_", out createdNew);//这种在系统中，不管几个用户，只能存在一个这样的程序进程
            if (!createdNew)
            {
                MessageBox.Show("Easybox is already running.","Easybox");
            }
            return createdNew;
        }
        [STAThread]
        static void Main()
        {

            //测试
            //判断是否已经有一个该程序在运行
            if (new Program().CheckMultiInstance())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new UI.LoginForm());
            }
        }
    }
}
