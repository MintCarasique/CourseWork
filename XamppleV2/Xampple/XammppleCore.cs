using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Xml;
using System.Net.Sockets;
using System.Xml.Linq;
using System.Threading.Tasks;
using S22.Xmpp.Client;
using S22.Xmpp.Im;

namespace Xampple
{
    class XamppleCore
    {
        static XDocument HandshakeXML;
        static Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //static XmppClient client;
        public void StartConnecting(string Username, string Hostname, string Password)
        {
            try
            {
                IPAddress[] ip = Dns.GetHostAddresses(Hostname);
                server.Connect(ip[0], 5222);
                InitiateConnection(server, Hostname);
                StartAuthorization(server, Hostname, Username, Password);
                BindResource(server, Hostname);
                SetPresenceStatus(server, "Online");
                StartListening(server, Username, Hostname, Password);
            }
            catch (Exception e)
            {
                LoginForm.loginForm.ShowMessage(e);
            }
            //GetRosterList(server, Username, Hostname);
            //MainForm.mainForm.GetStatusLabel().Invoke(new Action(() => MainForm.mainForm.GetStatusLabel().Text = "message"));
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
            XNamespace stream = "stream";
            HandshakeXML = new XDocument(
            new XElement(stream + "stream",
                new XAttribute("to", hostname),
                new XAttribute("xmlns", "jabber:client"),
                new XAttribute(XNamespace.Xmlns + "stream", "http://etherx.jabber.org/streams"),
                new XAttribute(XNamespace.Xml + "l", "ru"),
                new XAttribute("version", "1.0")));
            string initiateConnection = prefix + hostname + postfix;
            //string initConn = HandshakeXML.ToString(SaveOptions.DisableFormatting);
            byte[] msg = Encoding.UTF8.GetBytes(initiateConnection);
            //byte[] msg = System.Text.Encoding.UTF8.GetBytes(HandshakeXML);
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
        public static int GetRosterList(Socket server, string username, string hostname)
        {
            string initiateConnection = "<iq type='get' id='3'><query xmlns='jabber:iq:roster'/></iq>";
            byte[] msg = Encoding.UTF8.GetBytes(initiateConnection);
            byte[] bytes = new byte[server.ReceiveBufferSize];
            try
            {
                int i = server.Send(msg);
                i = server.Receive(bytes);
                string message = Encoding.UTF8.GetString(bytes, 0, i);
                XDocument ResultPacket = XDocument.Parse(message);
                //foreach (XElement el in ResultPacket.Root.LastNode.E)
                //{
                //    string temp = (string)el.Attribute("jid");
                //    MainForm.mainForm.GetMessageBox().Invoke(new Action(() => MainForm.mainForm.GetMessageBox().Items.Add((string)el.Attribute("jid"))));
                //}

                Console.WriteLine(message + "\n");
            }
            catch (SocketException e)
            {
                Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
                return (e.ErrorCode);
            }
            return 0;
        }
        public void MessageSender(string message, string address)
        {
            if (server != null)
                SendMessage(server, message, address);
        }
        public static int SendMessage(Socket server, string message, string address)
        {
            string prefix = "<message type='chat' from='MintCarasique@jabber.ru' to='" + address + "' id='et5r'><body>";
            string postfix = "</body></message>";
            string initiateConnection = prefix + message + postfix;
            byte[] msg = Encoding.UTF8.GetBytes(initiateConnection);
            byte[] bytes = new byte[server.ReceiveBufferSize];
            try
            {
                int i = server.Send(msg);
                string time = DateTime.Now.ToString("hh:mm:ss");
                MainForm.mainForm.GetMessageBox().Invoke(new Action(() => MainForm.mainForm.GetMessageBox().Items.Add("(" + DateTime.Now.ToString("hh:mm:ss") + ") You: " + message)));
            }
            catch (SocketException e)
            {
                return (e.ErrorCode);
            }
            return 0;
        }

        public void StartListening(Socket server, string Username, string Hostname, string Password)
        {
            //XmppClient client = new XmppClient(Hostname, Username, Password);
            //client.Message += OnNewMessage;
            //client.Connect();
            //client.SetStatus(Availability.Online);
            while (true)
            {
                string message = null;
                byte[] bytes = new byte[server.ReceiveBufferSize];
                int bytesRec = server.Receive(bytes);
                message += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                ParseMessage(message);
                //if (message != "")
                //MainForm.mainForm.GetMessageBox().Invoke(new Action(() => MainForm.mainForm.GetMessageBox().Items.Add(message)));
            }

        }
        public void ParseMessage(string message)
        {
            XmlDocument ReceivedMessage = new XmlDocument();
            ReceivedMessage.LoadXml(message);
            string type = "";
            string User = "";
            string MessageBody = "";
            string mes = "";
            if (ReceivedMessage.FirstChild.Name == "presence")
            {
                if (ReceivedMessage.FirstChild.FirstChild == null)
                {
                    if (ReceivedMessage.FirstChild.Attributes[2].Value == "unavailable")
                    {
                        type = "logout";
                        User = ReceivedMessage.FirstChild.Attributes[0].Value;
                    }
                }
                else
                    type = ReceivedMessage.FirstChild.ChildNodes[1].Name;
            }
            else
            if (ReceivedMessage.FirstChild.Name == "message")
            {
                if ((ReceivedMessage.FirstChild.FirstChild.Name == "composing") | (ReceivedMessage.FirstChild.FirstChild.Name == "paused"))
                {
                    User = ReceivedMessage.FirstChild.Attributes[0].Value;
                    type = ReceivedMessage.FirstChild.FirstChild.Name;
                }
                if (ReceivedMessage.FirstChild.LastChild.Name == "body")
                {
                    type = "body";

                    User = ReceivedMessage.FirstChild.Attributes[0].Value;
                    MessageBody = ReceivedMessage.FirstChild.LastChild.LastChild.Value;
                }
            }
            switch (type)
            {
                case "status":
                    User = ReceivedMessage.FirstChild.Attributes[0].Value;
                    string status = ReceivedMessage.FirstChild.ChildNodes[1].InnerText;
                    mes = "(" + DateTime.Now.ToString("hh:mm:ss") + ") User " + User + " changed status to " + status + '.';
                    MainForm.mainForm.GetMessageBox().Invoke(new Action(() => MainForm.mainForm.GetMessageBox().Items.Add(mes)));
                    break;
                case "composing":
                    MainForm.mainForm.GetLogLabel().Invoke(new Action(() => MainForm.mainForm.GetLogLabel().Text = User + " is typing..."));
                    break;
                case "paused":
                    MainForm.mainForm.GetLogLabel().Invoke(new Action(() => MainForm.mainForm.GetLogLabel().Text = ""));
                    break;
                case "body":
                    mes = "(" + DateTime.Now.ToString("hh:mm:ss") + ") " + User + ": " + MessageBody; 
                    MainForm.mainForm.GetLogLabel().Invoke(new Action(() => MainForm.mainForm.GetLogLabel().Text = ""));
                    MainForm.mainForm.GetMessageBox().Invoke(new Action(() => MainForm.mainForm.GetMessageBox().Items.Add(mes)));
                    break;
                case "logout":
                    mes = "(" + DateTime.Now.ToString("hh:mm:ss") + ") " + User + " now offline.";
                    MainForm.mainForm.GetMessageBox().Invoke(new Action(() => MainForm.mainForm.GetMessageBox().Items.Add(mes)));
                    break;
            }
        }
        public static void OnNewMessage(object sender, MessageEventArgs e)
        {
            //Console.WriteLine("Message from <" + e.Jid + ">: " + e.Message.Body);
            MainForm.mainForm.GetMessageBox().Invoke(new Action(() => MainForm.mainForm.GetMessageBox().Items.Add(e.Jid + ":" + e.Message.Body)));
        }
    }
    
}