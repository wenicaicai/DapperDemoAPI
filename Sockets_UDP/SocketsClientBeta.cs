using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Sockets_UDP
{
    public class SocketsClientBeta
    {
        public void TrySocketClient()
        {

            StringBuilder stringBuilder = new StringBuilder();
            //UDP
            byte[] data = new byte[1024];
            stringBuilder.Append($"This is Client,host name is {Dns.GetHostName()}");

            //设置服务端IP与端口
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8001);
            //定义Socekst的 网络类型，数据连接类型和网络协议UDP
            Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            string welcome = "Hello World!I am Client_Beta ^_^.";
            data = Encoding.UTF8.GetBytes(welcome);
            //向服务端发送数据，此时客户端通过本机哪个IP与端口发送数据是随机的

            //该信息被存放在socket中。

            //服务端接收到信息会得到客户端的发送地址，服务端利用这个地址向客户端

            //发送消息，客户端直接利用这个socket就可以接收数据，从而无需bind

            socketServer.SendTo(data, data.Length, SocketFlags.None, ip);
            EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            data = new byte[1024];

            //获得的Remote是服务端地址
            int recv = socketServer.ReceiveFrom(data, ref remote);
            stringBuilder.Append($"Receive from {remote.ToString()}");
            stringBuilder.Append($"Server msg: {Encoding.ASCII.GetString(data, 0, recv)}");
            stringBuilder.Append("THE END.");
            socketServer.Close();
        }
    }
}
