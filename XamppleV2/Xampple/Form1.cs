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
        public MainForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bool isLogged = false;
            if (!isLogged)
                LoadLoginForm();
                
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
    }
}
