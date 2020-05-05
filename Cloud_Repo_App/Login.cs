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
        SQL_conn sqlConn;

        public Login(Entry_point mainForm, SQL_conn sqlControl)
        {
            InitializeComponent();
            controller = mainForm;
            sqlConn = sqlControl;
        }

        private void Register_button_Click(object sender, EventArgs e)
        {
            StoreWindowSettings();
            controller.CurrentState = (int)EnumState.Register;   
        }

        private void Login_button_Click(object sender, EventArgs e)
        {
            Login_button.Enabled = false;
            ResetErrorMessages();
            bool inputsValid = true;

            if (!(sqlConn.CheckConnection()))
            {
                inputsValid = false;
                CantConnect_label.Show();
            }
            if (String.IsNullOrEmpty(Username_textbox.Text))
            {
                inputsValid = false;
                InvalidLogin_label.Show();
            }
            else if (!(sqlConn.CheckIfUserExists(Username_textbox.Text)))
            {
                inputsValid = false;
                InvalidLogin_label.Show();
            }
            if (String.IsNullOrEmpty(Password_textbox.Text))
            {
                inputsValid = false;
                InvalidLogin_label.Show();
            }
            else if (!(sqlConn.ValidatePassword(sqlConn.CreateHashedPassword(Password_textbox.Text, Username_textbox.Text))))
            {
                inputsValid = false;
                InvalidLogin_label.Show();
            }
            if (inputsValid)
            {            
                ResetErrorMessages();
                StoreWindowSettings();
                controller.CurrentUser = Username_textbox.Text;
                controller.CurrentState = (int)EnumState.LoggedIn;
            }

            ClearTextInputs();
            Login_button.Enabled = true;
        }

        private void ClearTextInputs()
        {
            Username_textbox.Clear();
            Password_textbox.Clear();
        }

        private void ResetErrorMessages()
        {
            InvalidLogin_label.Hide();
            CantConnect_label.Hide();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void StoreWindowSettings()
        {
            if (WindowState == FormWindowState.Maximized)
            {
                Properties.Settings.Default.Location = RestoreBounds.Location;
                Properties.Settings.Default.Size = RestoreBounds.Size;
                Properties.Settings.Default.Maximized = true;
                Properties.Settings.Default.Minimized = false;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.Location = Location;
                Properties.Settings.Default.Size = Size;
                Properties.Settings.Default.Maximized = false;
                Properties.Settings.Default.Minimized = false;
            }
            else
            {
                Properties.Settings.Default.Location = RestoreBounds.Location;
                Properties.Settings.Default.Size = RestoreBounds.Size;
                Properties.Settings.Default.Maximized = false;
                Properties.Settings.Default.Minimized = true;
            }
            Properties.Settings.Default.Save();
        }

        public void LoadWindowSettings()
        {
            if (Properties.Settings.Default.Maximized)
            {
                WindowState = FormWindowState.Maximized;
                Location = Properties.Settings.Default.Location;
                Size = Properties.Settings.Default.Size;
            }
            else if (Properties.Settings.Default.Minimized)
            {
                WindowState = FormWindowState.Minimized;
                Location = Properties.Settings.Default.Location;
                Size = Properties.Settings.Default.Size;
            }
            else
            {
                Location = Properties.Settings.Default.Location;
                Size = Properties.Settings.Default.Size;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            LoadWindowSettings();
            ResetErrorMessages();
        }

    }
}