

//using System;

using System;

System.Console.WriteLine(Environment.Is64BitOperatingSystem);//是否为64位系统
System.Console.WriteLine(Environment.OSVersion); //操作系统的版本
System.Console.WriteLine(Environment.WorkingSet);//当前进程的内存字节数

System.Console.WriteLine(Environment.GetCommandLineArgs()); 
System.Console.WriteLine(Environment.CommandLine);