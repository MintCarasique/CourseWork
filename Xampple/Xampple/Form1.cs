using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S22.Xmpp;
using S22.Xmpp.Client;

namespace Xampple
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }
        JabberCore core = new JabberCore();
        private void ServerNameTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void ServerTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            core.StartConnecting(JIDbox.Text, ServerNameTextBox.Text, PasswordTextBox.Text);
        }
    }
}
