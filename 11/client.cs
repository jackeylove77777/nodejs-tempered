

using System.Net;
using System.Net.Sockets;
using System.Text;

IPAddress ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
IPEndPoint ipLocalEndPoint = new(ipAddress, 11000);

var client = new UdpClient();
string s = "";
Console.Write("input: ");
while (!(s = Console.ReadLine()).Equals("q"))
{
    var bytes = Encoding.Default.GetBytes(s);
    client.Send(bytes, bytes.Length, ipLocalEndPoint);
    Console.Write("input: ");
}
client.Close();
