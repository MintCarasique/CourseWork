using System;
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
        MessageForm messageForm;
        public void StartConnecting(string login, string server, string password)
        {
            XmppClient client = new XmppClient(server, login, password);
            client.Connect();
            messageForm = new MessageForm();           
            messageForm.Show();
            messageForm.GetLogTextBox().Text = "Connected as " + client.Jid;
            client.SendMessage("drStrangeL0ve@jabber.ru", "Testing message");
        }
        public void SendMessage(string contact, string message)
        {
            
        }
    }
}
