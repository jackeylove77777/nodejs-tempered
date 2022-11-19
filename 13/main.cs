
using System.Diagnostics;
try
{
    using var myProcess = new Process();
    myProcess.StartInfo.UseShellExecute = false;//不使用Shell
    myProcess.StartInfo.FileName = "ping";
    myProcess.StartInfo.Arguments = "www.baidu.com";
    myProcess.Start();
}
catch (Exception ex)
{
    throw;
}

try
{
    using var myProcess = new Process();
    myProcess.StartInfo.FileName = "notepad.exe";
    myProcess.StartInfo.CreateNoWindow = true;
    myProcess.Start();
    myProcess.WaitForExit();
    //while (!myProcess.HasExited)
    //{
    //    Thread.Sleep(50);
    //}
    Console.WriteLine("end");
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    throw;
}