using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xampple
{
    public partial class MainForm : Form
    {
        public static MainForm mainForm = null;
        public MainForm()
        {
            InitializeComponent();
            mainForm = this;
        }
        XamppleCore core = new XamppleCore();
        private void MainForm_Load(object sender, EventArgs e)
        {
            bool isLogged = false;
            if (!isLogged)
            {
                LoadLoginForm();            
            }
                            
        }
        public string username, server, password;
        public void StartLogin(string Username, string Server, string Password)
        {
            username = Username;
            server = Server;
            password = Password;
            MessageBackgroundWorker.RunWorkerAsync(); 
        }
        private void LoadLoginForm()
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            
        }
        public void CloseMainForm()
        {
            MainForm.ActiveForm.Close();
        }
        public ListBox GetMessageBox()
        {
            return MessageListBox;
        }
        public ComboBox GetRosterComboBox()
        {
            return RosterComboBox;
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            core.MessageSender(MessageInputTextBox.Text, RosterComboBox.Items[RosterComboBox.SelectedIndex].ToString());
            MessageInputTextBox.Text = "";
        }
        public Label GetLogLabel()
        {
            return LogLabel;
        }
        private void MessageBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            core.StartConnecting(username, server, password);
        }
    }
}
