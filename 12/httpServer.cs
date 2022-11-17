
using System.Net;
using System.Text;

if (!HttpListener.IsSupported)
{
    Console.WriteLine("your os not support HttpClient class");
}
const string ADDR = @"http://127.0.0.1:8001/";
var server = new HttpListener();
//添加监听地址
server.Prefixes.Add(ADDR);
server.Start();
while (true)
{
    var context = server.GetContext();
    var res = context.Response;
    var req = context.Request;
    var client_addr = req.UserHostAddress;
    var buffer = Encoding.UTF8.GetBytes($"\"<html><body><h1>Hello World! {client_addr}</h1></body></html>\"");

    res.ContentLength64 = buffer.Length;
    res.ContentType = "text/html";
    res.OutputStream.Write(buffer, 0, buffer.Length);
    res.Close();
}