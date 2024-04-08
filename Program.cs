using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ConsoleApp17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 12345);
            client.EnableBroadcast = true;

            client.Client.Bind(new IPEndPoint(IPAddress.Any, 0));
            while (true)
            {
                byte[] receivedData = client.Receive(ref endPoint);
                string receivedText = Encoding.ASCII.GetString(receivedData);
                Console.WriteLine("Current Time: " + receivedText);
            }
        }
    }
}
