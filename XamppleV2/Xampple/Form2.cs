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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            TopMost = true;
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
        public bool isManuallyClosed = false;
        public bool ClosedByLogin = false;
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ClosedByLogin)
            {
                DialogResult ExitDialog = MessageBox.Show("Are you really want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ExitDialog == DialogResult.Yes)
                {
                    e.Cancel = false;
                    isManuallyClosed = true;
                }
                else
                    e.Cancel = true;
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isManuallyClosed)
                Application.Exit();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            isManuallyClosed = false;
            ClosedByLogin = true;
            LoginForm.ActiveForm.Close();
        }
    }
}
