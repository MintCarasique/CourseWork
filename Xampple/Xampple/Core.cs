using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22.Xmpp;
using S22.Xmpp.Client;
using S22.Xmpp.Im;

namespace Xampple
{
    public class JabberCore
    {
        string Login, Server, Password, SelectedContact;
        static MessageForm messageForm = new MessageForm();
        
        public static XmppClient client = new XmppClient("default", "default", "default");
        public void StartConnecting(string login, string server, string password)
        {
            Login = login;
            Server = server;
            Password = password;
            XmppClient tempClient = new XmppClient(Server, Login, Password);            
            client = tempClient;
            client.Message += OnNewMessage;
            client.Connect();
            messageForm.Show();
            foreach (var item in client.GetRoster())
                messageForm.GetRosterListBox().Items.Add(item.Jid);            
            messageForm.GetLogTextBox().Text = "Connected as " + client.Username + '@' + client.Hostname;
        }
        public void SelectContact(string contact)
        {
            SelectedContact = contact;
        }
        public void SendMessage(string messageText)
        {
            client.SendMessage(SelectedContact, messageText);
            messageForm.GetLogListBox().Items.Add("<" + client.Jid + ">: " + messageText);           
        }

        public static void OnNewMessage(object sender, MessageEventArgs e)
        {
            messageForm.GetLogListBox().Items.Add("<" + e.Jid + ">:" + e.Message.Body);
        }
    }
}
