using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cloud_Repo_App
{
    public partial class Login : Form
    {

        Entry_point controller;

        public Login(Entry_point mainForm)
        {
            InitializeComponent();
            controller = mainForm;
        }

        private void Register_button_Click(object sender, EventArgs e)
        {
            controller.CurrentState = (int)EnumState.Register;
        }

        private void Login_button_Click(object sender, EventArgs e)
        {
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
