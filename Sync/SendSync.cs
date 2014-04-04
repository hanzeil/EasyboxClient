using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace EasyboxClient.Sync
{
    class SendSync
    {
        private String fileName;
        private String relativePath;
        private String hostName;
        private String syncType;
        private String syncPath;
        // IP地址
        private IPAddress Addr = IPAddress.Parse("117.121.25.234");  // xdtic
        // 指定端口
        private const int PORT = 8888;
        Byte[] fileData = new Byte[8192];
        private Socket s;
        public SendSync(String syncType, String hostName, String fileName,String syncPath)
        {
            this.fileName = fileName;
            this.hostName = hostName;
            this.syncType = syncType;
            this.syncPath = syncPath;
            Thread t = new Thread(new ThreadStart(run));
            t.Start();
        }
        public void run()
        {
            try
            {
                // 指定端口和IP绑定
                IPEndPoint ephost = new IPEndPoint(Addr, PORT);
                // 初始化socket新实例   （ 地址族 + 套接字类型 + 协议 ）
                this.s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                s.Connect(ephost);
                //将同步类型发送给服务器
                SendStringByUTF8(syncType);
                //send this client's hostname;
                SendStringByUTF8(hostName);
                //send this client's relativePash(file's name);
                relativePath = GetRelativePath(fileName);
                SendStringByUTF8(relativePath);
            }catch (SocketException)
            {
                MessageBox.Show("您已与服务器断开，同步失败！", "Easybox");
            } 
            if (syncType.Equals("Send"))
            {
                SendFile();
            }
            else
            {
                s.Close();
            }
        }
        public void SendFile()
        {
            try
            {
                FileStream aFile = new FileStream(fileName, FileMode.Open);
                while (true)
                {
                    int len = aFile.Read(fileData, 0, 8191);
                    if(0==len)
                    {
                        break;
                    } 
                    s.Send(fileData, len, SocketFlags.None);
                }
                s.Close();
                aFile.Close();
            }catch(Exception)
            {
                MessageBox.Show("文件传输错误，系统正在尝试修复！", "Easybox");
            } 
        }
        private String GetRelativePath(String path)
        {
            return path.Substring(path.LastIndexOf(syncPath+"\\") + syncPath.Length);
        }
        private void SendStringByUTF8(String target)
        {
            byte[] buf = System.Text.Encoding.UTF8.GetBytes(target);
            s.Send(buf, buf.Length, SocketFlags.None);
            Thread.Sleep(500);
        }
    }
}
