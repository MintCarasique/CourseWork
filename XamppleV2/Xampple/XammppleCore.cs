using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22.Xmpp.Client;

namespace Xampple
{
    class XamppleCore
    {
        static XmppClient client = new XmppClient("default", "default", "default");
        public void StartConnecting(string Username, string Server, string Password)
        {
            client = new XmppClient(Server, Username, Password);
            try
            {
                client.Connect();
            }
            catch
            {
                LoginForm.loginForm.ShowMessage();
            }


            MainForm.mainForm.GetMessageBox().Items.Add("Connected");
            }
    }
}
