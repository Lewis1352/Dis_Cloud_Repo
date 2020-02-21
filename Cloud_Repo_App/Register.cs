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
    public partial class Register : Entry_point
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Create_button_Click(object sender, EventArgs e)
        {
            DisplayLoginForm();
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            DisplayLoginForm();
        }
    }
}
