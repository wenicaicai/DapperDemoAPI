using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Sockets_UDP
{
    public class SocketServerBeta
    {
        int recv;
        byte[] data = new byte[1024];

        public void TryUDPServer()
        {
            StringBuilder stringBuilder = new StringBuilder();
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 8001);
            Socket newSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            newSocket.Bind(ip);
            stringBuilder.Append($"This is Server,hostName is {Dns.GetHostName()}");
            stringBuilder.Append("Waiting for a client.");

            EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            //??ref
            recv = newSocket.ReceiveFrom(data, ref remote);
            stringBuilder.Append($"Message recevice from {remote.ToString()}");
            stringBuilder.Append(Encoding.ASCII.GetString(data, 0, recv));

            string welcome = "Hello World!This is Server_Beta ..";
            data = Encoding.ASCII.GetBytes(welcome);

            newSocket.SendTo(data, data.Length, SocketFlags.None, remote);
            newSocket.Close();
        }


    }
}
