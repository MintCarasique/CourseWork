﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22.Xmpp.Client;
using S22.Xmpp.Im;

namespace Xampple
{
    class XamppleCore
    {
        static XmppClient client;
        public void StartConnecting(string Username, string Server, string Password)
        {
            client = new XmppClient(Server, Username, Password);
            client.Connect();
            MainForm.mainForm.GetMessageBox().Invoke(new Action(() => MainForm.mainForm.GetMessageBox().Items.Add("Connected as " + client.Username + '@' + client.Hostname)));
            client.SetStatus(S22.Xmpp.Im.Availability.Online);
            GetRosterList();  
        }
        public void GetRosterList()
        {
            foreach (var item in client.GetRoster())
                MainForm.mainForm.GetRosterComboBox().Invoke(new Action(() => MainForm.mainForm.GetRosterComboBox().Items.Add(item.Jid)));
        }
    }
}
