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
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
        }
        JabberCore client = new JabberCore();
        public TextBox GetLogTextBox()
        {
            return LogTextBox;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {

        }
    }
}
