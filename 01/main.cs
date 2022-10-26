//using System;
//using System.IO;

//获取命令行输入
var str = Console.ReadLine();
Console.WriteLine(str); //调用的是标准输出流的方法Console.Out.WriteLine(str)

//标准输出流
Console.Out.WriteLine("stdout");
Console.Error.WriteLine("error");

//C#更便捷的地方是，标准输入流，输出流以及错误流可以在程序内指定

var inputFile = @".\input.txt";
var outputFile = @".\output.txt";
using(var input = new StreamReader(inputFile))
using(var output = new StreamWriter(outputFile))
{
    Console.SetIn(input);//设置标准输入流
    Console.SetOut(output);//设置标准输出流
    var line = "";
    while((line = input.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
}

var errorFile = @".\err.txt";
var errOutput = new StreamWriter(errorFile);
//设置标准错误流
Console.SetError(errOutput);
Console.Error.WriteLine("some error!\r error!");
errOutput.Close();

//设置以上各种流之后，可以修改回原本
var stdin = new StreamReader(Console.OpenStandardInput());
var stdout = new StreamWriter(Console.OpenStandardOutput());
var stderr = new StreamWriter(Console.OpenStandardError());
Console.SetIn(stdin);
Console.SetOut(stdout);
Console.SetError(stderr);


