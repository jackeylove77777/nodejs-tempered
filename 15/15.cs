


using System.Diagnostics;


try
{
    using var echo = new Process();
    echo.StartInfo.FileName = "echo";
    echo.StartInfo.UseShellExecute = false;
    using var netstat = new Process();



    netstat.StartInfo.UseShellExecute = false;//不使用Shell
    netstat.StartInfo.FileName = "netstat";
    netstat.StartInfo.Arguments = "-an";
    netstat.StartInfo.UseShellExecute = false;
    netstat.StartInfo.RedirectStandardOutput = true;
    netstat.Start();

    echo.StartInfo.Arguments = netstat.StandardOutput.ReadToEnd();
    Console.WriteLine("================================== echo output =========================================");
    echo.Start();
}
catch (Exception ex)
{
    throw;
}
