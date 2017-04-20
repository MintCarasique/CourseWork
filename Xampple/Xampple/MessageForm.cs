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
        public ListBox GetLogListBox()
        {
            return LogListBox;
        }
        public ListBox GetRosterListBox()
        {
            return RosterListBox;
        }
        public TextBox GetInputData()
        {
            return InputFieldTextBox;
        }
        private void SendButton_Click(object sender, EventArgs e)
        {
            client.SendMessage(InputFieldTextBox.Text);
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {

        }

        private void RosterListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            client.SelectContact(RosterListBox.SelectedItem.ToString());
        }
    }
}
