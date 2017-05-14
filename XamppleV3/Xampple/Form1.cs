using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        public void StartLogin(string Username, string Server, string Password)
        {
            core.StartConnecting(Username, Server, Password);
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
    }
}
