using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Xml;

namespace Test
{
    class Program
    {


        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress[] ip = Dns.GetHostAddresses("jabber.ru");
            server.Connect(ip[0], 5222);
            Console.WriteLine("Enter hostname:");
            string hostname = Console.ReadLine();
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            InitiateConnection(server, hostname);
            StartAuthorization(server, hostname, username, password);
            BindResource(server, hostname);
            SetPresenceStatus(server, "Online");
            GetRosterList(server, hostname);
            Console.WriteLine("Enter your message:");
            string message = Console.ReadLine();
            SendMessage(server, message);
            Console.ReadKey();
        }
        public static int SendMessage(Socket server, string message)
        {

            string prefix = "<message type='chat' from='MintCarasique@jabber.ru' to='drStrangeL0ve@jabber.ru' id='et5r'><body>";
            string postfix = "</body></message>";
            string initiateConnection = prefix + message + postfix;
            byte[] msg = Encoding.UTF8.GetBytes(initiateConnection);
            byte[] bytes = new byte[server.ReceiveBufferSize];
            try
            {
                int i = server.Send(msg);
                Console.WriteLine("Sent {0} bytes.", i);
          
            }
            catch (SocketException e)
            {
                Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
                return (e.ErrorCode);
            }
            return 0;
        }
        public static int BindResource(Socket server, string hostname)
        { string prefix = "<?xml version='1.0' encoding='UTF-8'?><stream:stream to='";
                string postfix = "' xmlns='jabber:client' xmlns:stream='http://etherx.jabber.org/streams' xml:l='ru' version='1.0'>";
                string bindResource = "<iq type='set' id='1'><bind xmlns='urn:ietf:params:xml:ns:xmpp-bind'><resource>test</resource></bind></iq>";
                byte[] msg = Encoding.UTF8.GetBytes(bindResource);
                byte[] bytes = new byte[server.ReceiveBufferSize];
                try
                {
                    int i = server.Send(msg);
                    Console.WriteLine("Sent {0} bytes.", i);
                    i = server.Receive(bytes);
                    Console.WriteLine("Receive {0} bytes.", i);
                    string message = Encoding.UTF8.GetString(bytes, 0, i);
                    message = Encoding.UTF8.GetString(bytes, 0, i);
                    Console.WriteLine(message + "\n");
                }
                catch (SocketException e)
                {
                    Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
                    return (e.ErrorCode);
                }
                return 0;
            }
        public static int GetRosterList(Socket server, string hostname)
        {

            string prefix = "<?xml version='1.0' encoding='UTF-8'?><stream:stream to='";
            string postfix = "' xmlns='jabber:client' xmlns:stream='http://etherx.jabber.org/streams' xml:l='ru' version='1.0'>";
            string initiateConnection = "<iq from='MintCarasique@jabber.ru' type='get' id='roster_1'><query xmlns='jabber:iq:roster'/></iq>";
            byte[] msg = Encoding.UTF8.GetBytes(initiateConnection);
            byte[] bytes = new byte[server.ReceiveBufferSize];
            try
            {
                int i = server.Send(msg);
                Console.WriteLine("Sent {0} bytes.", i);
                i = server.Receive(bytes);
                Console.WriteLine("Receive {0} bytes.", i);
                string message = Encoding.UTF8.GetString(bytes, 0, i);
                message = Encoding.UTF8.GetString(bytes, 0, i);
                Console.WriteLine(message + "\n");
            }
            catch (SocketException e)
            {
                Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
                return (e.ErrorCode);
            }
            return 0;
        }
        public static int InitiateConnection(Socket server, string hostname)
        {

            string prefix = "<?xml version='1.0' encoding='UTF-8'?><stream:stream to='";
            string postfix = "' xmlns='jabber:client' xmlns:stream='http://etherx.jabber.org/streams' xml:l='ru' version='1.0'>";
            string initiateConnection = prefix + hostname + postfix;
            byte[] msg = Encoding.UTF8.GetBytes(initiateConnection);
            byte[] bytes = new byte[server.ReceiveBufferSize];
            try
            {
                int i = server.Send(msg);
                Console.WriteLine("Sent {0} bytes.", i);
                i = server.Receive(bytes);
                Console.WriteLine("Receive {0} bytes.", i);
                string message = Encoding.UTF8.GetString(bytes, 0, i);
                i = server.Receive(bytes);
                Console.WriteLine("Receive {0} bytes.", i);
                message = Encoding.UTF8.GetString(bytes, 0, i);
                Console.WriteLine(message + "\n");
            }
            catch (SocketException e)
            {
                Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
                return (e.ErrorCode);
            }
            return 0;
        }
        public static int SendHandshake(Socket server, string hostname)
        {

            string prefix = "<?xml version='1.0' encoding='UTF-8'?><stream:stream to='";
            string postfix = "' xmlns='jabber:client' xmlns:stream='http://etherx.jabber.org/streams' xml:l='ru' version='1.0'>";
            string initiateConnection = prefix + hostname + postfix;
            byte[] msg = Encoding.UTF8.GetBytes(initiateConnection);
            byte[] bytes = new byte[server.ReceiveBufferSize];
            try
            {
                int i = server.Send(msg);
                Console.WriteLine("Sent {0} bytes.", i);
                i = server.Receive(bytes);
                Console.WriteLine("Receive {0} bytes.", i);
                i = server.Receive(bytes);
                Console.WriteLine("Receive {0} bytes.", i);
                string message = Encoding.UTF8.GetString(bytes, 0, i);
                message = Encoding.UTF8.GetString(bytes, 0, i);
                Console.WriteLine(message + "\n");
            }
            catch (SocketException e)
            {
                Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
                return (e.ErrorCode);
            }
            return 0;
        }
        public static void SetPresenceStatus(Socket server, string Status)
        {

            string prefix = "<presence><show>chat</show><status>";
            string postfix = "</status><priority>10</priority></presence>";
            string initiateConnection = prefix + Status + postfix;
            byte[] msg = Encoding.UTF8.GetBytes(initiateConnection);
            byte[] bytes = new byte[server.ReceiveBufferSize];
            try
            {
                int i = server.Send(msg);
                Console.WriteLine("Sent {0} bytes.", i);

            }
            catch (SocketException e)
            {
                Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
            }
        }
        public static int StartAuthorization(Socket server, string hostname, string username, string password)
        {
            string plainText = "\x00" + username + "\x00" + password;
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            string PlainUserName = System.Convert.ToBase64String(plainTextBytes);
            string authorizationResponse = "<auth xmlns='urn:ietf:params:xml:ns:xmpp-sasl' mechanism='PLAIN'>" + PlainUserName + "</auth>";
            byte[] msg = Encoding.UTF8.GetBytes(authorizationResponse);
            byte[] bytes = new byte[server.ReceiveBufferSize];
            try
            {
                int i = server.Send(msg);
                Console.WriteLine("Sent {0} bytes.", i);
                i = server.Receive(bytes);
                Console.WriteLine("Receive {0} bytes.", i);
                string message = Encoding.UTF8.GetString(bytes, 0, i);
                XElement ResultPacket = XElement.Parse(message);
                Console.WriteLine(ResultPacket);
                SendHandshake(server, hostname);
            }
            catch (SocketException e)
            {
                Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
                return (e.ErrorCode);
            }
            return 0;
        }
        
    }
}
