using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Xml.Linq;
using System.Threading.Tasks;
using S22.Xmpp.Client;
using S22.Xmpp.Im;

namespace Xampple
{
    class XamppleCore
    {
        //static XmppClient client;
        public void StartConnecting(string Username, string Hostname, string Password)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress[] ip = Dns.GetHostAddresses("jabber.ru");
            server.Connect(ip[0], 5222);
            InitiateConnection(server, Hostname);
            StartAuthorization(server, Hostname, Username, Password);
            BindResource(server, Hostname);
            SetPresenceStatus(server, "Online");
            GetRosterList(server, Username, Hostname);
            //client = new XmppClient(Server, Username, Password);
            //client.Connect();
            //MainForm.mainForm.GetMessageBox().Invoke(new Action(() => MainForm.mainForm.GetMessageBox().Items.Add("Connected as " + client.Username + '@' + client.Hostname)));
            //client.SetStatus(S22.Xmpp.Im.Availability.Online);
            //GetRosterList();  

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
                i = server.Receive(bytes);
                string message = Encoding.UTF8.GetString(bytes, 0, i);
                i = server.Receive(bytes);
                message = Encoding.UTF8.GetString(bytes, 0, i);
                MainForm.mainForm.GetMessageBox().Invoke(new Action(() => MainForm.mainForm.GetMessageBox().Items.Add(message)));
            }
            catch (SocketException e)
            {
                return (e.ErrorCode);
            }
            return 0;
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
                i = server.Receive(bytes);
                string message = Encoding.UTF8.GetString(bytes, 0, i);
                XElement ResultPacket = XElement.Parse(message);
                MainForm.mainForm.GetMessageBox().Invoke(new Action(() => MainForm.mainForm.GetMessageBox().Items.Add(ResultPacket)));
                SendHandshake(server, hostname);
            }
            catch (SocketException e)
            {
                return (e.ErrorCode);
            }
            return 0;
        }
        public void GetRosterList()
        {
            //foreach (var item in client.GetRoster())
            //    MainForm.mainForm.GetRosterComboBox().Invoke(new Action(() => MainForm.mainForm.GetRosterComboBox().Items.Add(item.Jid)));
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
                i = server.Receive(bytes);
                i = server.Receive(bytes);
                string message = Encoding.UTF8.GetString(bytes, 0, i);
                message = Encoding.UTF8.GetString(bytes, 0, i);
                MainForm.mainForm.GetMessageBox().Invoke(new Action(() => MainForm.mainForm.GetMessageBox().Items.Add(message)));
            }
            catch (SocketException e)
            {
                Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
                return (e.ErrorCode);
            }
            return 0;
        }
        public static int BindResource(Socket server, string hostname)
        {
            string bindResource = "<iq type='set' id='1'><bind xmlns='urn:ietf:params:xml:ns:xmpp-bind'><resource>test</resource></bind></iq>";
            byte[] msg = Encoding.UTF8.GetBytes(bindResource);
            byte[] bytes = new byte[server.ReceiveBufferSize];
            try
            {
                int i = server.Send(msg);
                i = server.Receive(bytes);
                string message = Encoding.UTF8.GetString(bytes, 0, i);
                message = Encoding.UTF8.GetString(bytes, 0, i);
                MainForm.mainForm.GetMessageBox().Invoke(new Action(() => MainForm.mainForm.GetMessageBox().Items.Add(message)));
            }
            catch (SocketException e)
            {
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
                i = server.Receive(bytes);
            }
            catch (SocketException e)
            {
                //Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
            }
        }
        public static int GetRosterList(Socket server,string username, string hostname)
        {
            //string initiateConnection = "<iq from='MintCarasique@jabber.ru' type='get' id='roster_1'><query xmlns='jabber:iq:roster'/></iq>";
            string initiateConnection = "<iq type='get' id='3'><query xmlns='jabber:iq:roster'/></iq>";
            byte[] msg = Encoding.UTF8.GetBytes(initiateConnection);
            byte[] bytes = new byte[server.ReceiveBufferSize];
            try
            {
                int i = server.Send(msg);
                i = server.Receive(bytes);
                string message = Encoding.UTF8.GetString(bytes, 0, i);
                XElement ResultPacket = XElement.Parse(message);
                Console.WriteLine(message + "\n");
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
