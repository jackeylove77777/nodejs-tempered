

using System.Net;
using System.Net.Sockets;
using System.Text;

string receiveStr = "";
byte[] receiveBytes = null;
IPAddress ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
IPEndPoint ipLocalEndPoint = new(ipAddress, 11000);
UdpClient server = new UdpClient(ipLocalEndPoint);
while (true)
{
    try
    {
        receiveBytes = server.Receive(ref ipLocalEndPoint);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        break;
    }
    receiveStr = Encoding.Default.GetString(receiveBytes);
    Console.WriteLine($"server received: {receiveStr}");
}



