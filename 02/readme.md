### nodejs的process类是一个全局对象，提供了对当前程序进程的一系列信息以及所在平台信息

### C#中与nodejs process类功能类似的类是Environment类，也能够访问当前进程信息以及所在操作系统信息

### Environment类只提供了当前进程所占内存大小，不能如nodejs process类一样访问分配堆内存信息

### C#的Process类更多的是提供对本地和远程进程的访问权限并使你能够启动和停止本地系统进程

Process示例启动进程示例
```
using System;
using System.Diagnostics;
using System.ComponentModel;

namespace MyProcessSample
{
    class MyProcess
    {
        public static void Main()
        {
            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    // You can start any process, HelloWorld is a do-nothing example.
                    myProcess.StartInfo.FileName = "C:\\HelloWorld.exe";
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.Start();
                    // This code assumes the process you are starting will terminate itself.
                    // Given that it is started without a window so you cannot terminate it
                    // on the desktop, it must terminate itself or you can do it programmatically
                    // from this application using the Kill method.
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```