
using System;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;

int port = 8888;
IPAddress localAddr = IPAddress.Parse("127.0.0.1");
TcpListener server = default!;
try
{
    server = new TcpListener(localAddr, port);

    //启动tcp服务器
    server.Start();

    //工作循环
    while (true)
    {
        Console.WriteLine("WAITING FOR A CONNECTION");

        //阻塞当前循环，直到有客户端连接
        TcpClient client = server.AcceptTcpClient();
        Console.WriteLine("A CLIENT Connected");

        Task.Run(() => SocketHandler(client));

    }
}
catch (SocketException ex)
{
    Console.WriteLine("SocketException : {0}", ex);
}
finally
{
    server?.Stop();
}
Console.WriteLine("\nEnter any key to Continue");
Console.ReadKey();


static void SocketHandler(TcpClient client)
{
    //读取数据缓冲字节数组
    byte[] buffer = new byte[1024];
    string data = null;


    //获取socket网络流进行读写，与客户端进行交流
    NetworkStream stream = client.GetStream();//NetworkStream和FileStream是同一层级的基础流

    int i;
    while ((i = stream.Read(buffer, 0, buffer.Length)) != 0)
    {
        data = System.Text.Encoding.ASCII.GetString(buffer, 0, i);
        Console.WriteLine("Received : {0}", data);

        //加工data，发送给客户端
        data = "Received: " + data.ToUpper();

        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

        stream.Write(msg, 0, msg.Length);
        Console.WriteLine("Send {0}", data);
    }
    client.Close();
}