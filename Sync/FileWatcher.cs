using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Easybox.Sync
{
    class FileWatcher
    {
        FileSystemWatcher watcher = new FileSystemWatcher();
        string LastChangeFileName;
        string path;
        string hostName;
        SendSync sendSync1 = null, sendSync2 = null, sendSync3 = null, sendSync4 = null;
        public FileWatcher(string hostName,string path)
        {
            this.hostName = hostName;
            this.path = path;
            watcher.Path = path;
            watcher.IncludeSubdirectories = true;
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.CreationTime | NotifyFilters.Size
                               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.*";
        }

        public void StartWatch()
        {
            watcher.EnableRaisingEvents = true;

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            //Console.ReadKey();
        }
        public void StopWatch() 
        {
            watcher.EnableRaisingEvents = false;
        }

        // Define the event handlers.
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            //if ((!(LastChangeFileName == e.Name)) )
            if ((!(LastChangeFileName == e.Name)) && (!IsTmpFile(e.Name)))
            {
                sendSync1=new SendSync("Send", hostName, e.FullPath,path);
                LastChangeFileName = e.Name;
                // 100ms 后取消对重复文件改变的屏蔽
                Thread th = new Thread(new ThreadStart(
                    delegate()
                    {
                        Thread.Sleep(100);
                        LastChangeFileName = "";
                    }
                ));
                th.Start();
            }
        }

        private void OnDeleted(object source, FileSystemEventArgs e)
        {
            if (!IsTmpFile(e.Name))
            {
                sendSync2 = new SendSync("Delete", hostName, e.FullPath, path);
            }

        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            if (!IsTmpFile(e.Name))
            {
                sendSync3 = new SendSync("Delete", hostName, e.OldFullPath, path);
                sendSync4 = new SendSync("Send", hostName, e.FullPath, path);
            }
           // Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
        private Boolean IsTmpFile(string FileName) 
        {
          /* if(false)
            if ((FileName[0] == '~'))
             if ((FileName[0] == '~') || (FileName.Substring(FileName.Length - 4, 4) == ".tmp") || (FileName.Substring(FileName.Length - 2, 2) == "00"))
                return true;
            else*/
                return false;
        }
        public void Abort(){
            StopWatch();
            if (sendSync1 != null) { sendSync1.Abort(); }
            if (sendSync2 != null) { sendSync2.Abort(); }
            if (sendSync3 != null) { sendSync3.Abort(); }
            if (sendSync4 != null) { sendSync4.Abort(); }
        }
    }
}
