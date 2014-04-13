using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
namespace Easybox.Sync
{   
    class TimingSyncThread
    {
        private String hostName;
        private Socket s;
        private const int PORT = 6666;
        // IP地址
        private IPAddress Addr = IPAddress.Parse("117.121.25.234"); //xdtic
        String syncPath;
        FileWatcher Watcher;
        Thread t;
        public TimingSyncThread(String hostName, String syncPath)
        {
            Watcher = new FileWatcher(hostName, syncPath);
            this.hostName = hostName;
            this.syncPath = syncPath;
            t = new Thread(new ThreadStart(run));
            t.Start();
        }
        public void run()
        {
            while (true)
            {
                try
                {
                     // 指定端口和IP绑定
                    IPEndPoint ephost = new IPEndPoint(Addr, PORT);
                    // 初始化socket新实例   （ 地址族 + 套接字类型 + 协议 ）
                    this.s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    s.Connect(ephost);
                    //发送客户端主机名，请求同步
                    SendStringByUTF8(hostName);
                    //开始同步
                    new ReceiveSync(s, syncPath);
                    s.Close();
                }
                catch (SocketException)
                {
                    MessageBox.Show("您已与服务器断开，请检查网络！", "Easybox");
                }      
                Watcher.StartWatch();
                //设置同步时间
                Thread.Sleep(10000);
                Watcher.StopWatch(); 
            }
        }
        private void SendStringByUTF8(String target)
        {
            byte[] buf = System.Text.Encoding.UTF8.GetBytes(target);
            s.Send(buf, buf.Length, SocketFlags.None);
            Thread.Sleep(500);
        }
        public void Abort(){
            t.Abort();
            Watcher.Abort();
        }
    }
}
