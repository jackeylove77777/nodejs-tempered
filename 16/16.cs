


using System.Diagnostics;
using System.Runtime.InteropServices;

try
{
    using (Process p = new Process())
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            p.StartInfo.FileName = "cmd.exe";
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            p.StartInfo.FileName = "/bin/bash";
        }
        p.StartInfo.UseShellExecute = false; //是否使用操作系统shell启动
        p.StartInfo.RedirectStandardInput = true; //接受来自调用程序的输入信息
        p.StartInfo.RedirectStandardOutput = true; //由调用程序获取输出信息
        p.StartInfo.RedirectStandardError = true; //重定向标准错误输出
        p.StartInfo.CreateNoWindow = false; //不显示程序窗口
        p.Start();//启动程序

        //向cmd窗口写入命令
        p.StandardInput.WriteLine("echo | netstat -an & exit");
        p.StandardInput.AutoFlush = true;

        //获取cmd窗口的输出信息
        string output = p.StandardOutput.ReadToEnd();
        p.WaitForExit();//等待程序执行完退出进程
        p.Close();
        Console.WriteLine(output);

    }

}
catch (Exception ex)
{
    throw;
}
