﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22.Xmpp;
using S22.Xmpp.Client;

namespace Xampple
{
    public class JabberCore
    {
        string Login, Server, Password, SelectedContact;
        MessageForm messageForm;
        public static XmppClient client = new XmppClient("default", "default", "default");
        public void StartConnecting(string login, string server, string password)
        {
            Login = login;
            Server = server;
            Password = password;
            XmppClient tempClient = new XmppClient(Server, Login, Password);
            client = tempClient;
            client.Connect();
            messageForm = new MessageForm();
            messageForm.Show();
            foreach (var item in client.GetRoster())
                messageForm.GetRosterListBox().Items.Add(item.Jid);
            
            messageForm.GetLogTextBox().Text = "Connected as " + client.Jid;
            //client.SendMessage("drStrangeL0ve@jabber.ru", "Testing message");
        }
        public void SelectContact(string contact)
        {
            SelectedContact = contact;
        }
        public void SendMessage(string messageText)
        {
            client.SendMessage(SelectedContact, messageText);            
        }
    }
}
