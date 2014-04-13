using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
namespace Easybox.Sync
{
    class ReceiveSync
    {
        Socket s;
        String syncType;
        String fileName;
        String syncPath;
        Byte[] fileData = new Byte[8192*10];
        public ReceiveSync(Socket s, String syncPath)
        {
            this.s = s;
            this.syncPath = syncPath;
            try
            {
                while (true)
                {
                    //接收需要同步的类型
                    syncType = getStringFromUTF8(new byte[20]);
                    //接收文件名
                    fileName = getStringFromUTF8(new byte[50]);
                    fileName = fileName.Substring(fileName.IndexOf('/') + 1);
                    fileName = syncPath + "\\" + fileName;
                    if (syncType.Equals("Send"))
                    {
                        ReceiveFile();
                        continue;
                    }
                    else if (syncType.Equals("Delete"))
                    {
                        File.Delete(fileName);
                        continue;
                    }
                    break;
                }
            }
            catch(Exception){
                MessageBox.Show("文件传输错误，系统正在尝试修复！", "Easybox");
            }
            
        }
        private void ReceiveFile()
        {
            try
            {
                //接收文件大小
                String fileLengthString = getStringFromUTF8(new byte[30]);
                long fileLength = long.Parse(fileLengthString);
               //打开文件流开始传输
                FileStream aFile = new FileStream(fileName, FileMode.Create);
                int receivedLenth = 0;
                while (receivedLenth < fileLength)
                {
                    int read = s.Receive(fileData, SocketFlags.None);
                    receivedLenth += read;
                    if (read == 0)
                    {
                        break;
                    }
                    aFile.Write(fileData, 0, read);
                }
                aFile.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
        private String getStringFromUTF8(byte[] buf)
        {
            int read = s.Receive(buf, SocketFlags.None);
            byte[] buf2 = new byte[read];
            for (int i = 0; i < read; i++)
            {
                buf2[i] = buf[i];
            }
                return System.Text.Encoding.UTF8.GetString(buf2);
        }
    }
}
