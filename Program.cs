using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EasyBoxClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void CheckRunning()
        {
            int ProceedingCount = 0;
            System.Diagnostics.Process[] Processes; Processes = System.Diagnostics.Process.GetProcessesByName("easybox01");//进程名称
            foreach (System.Diagnostics.Process IsProcedding in Processes)
            {
                if (IsProcedding.ProcessName == "easybox01")//进程名称
                {
                    ProceedingCount += 1;

                }
                if (ProceedingCount > 1)
                {
                    DialogResult result; result = MessageBox.Show("Easybox已经在运行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (System.Diagnostics.Process myProcess in Processes)
                    {
                        myProcess.Kill();
                    }
                }
            }
        }
        static void Main()
        {
            CheckRunning();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI.LoginForm());
        }
    }
}
