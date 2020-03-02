using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Cloud_Repo_App
{
    public partial class Register : Form
    {
        Entry_point controller;
        SQL_conn sqlConn;

        public Register(Entry_point mainForm, SQL_conn sqlControl)
        {
            InitializeComponent();
            controller = mainForm;
            sqlConn = sqlControl;
        }

        private void Register_Load(object sender, EventArgs e)
        {
            ResetErrorMessages();
            LoadWindowSettings();
        }

        private void ResetErrorMessages()
        {
            UsernameTaken_label.Hide();
            EmailInUse_label.Hide();
            EmailDoesNotMatch_label.Hide();
            CantConnect_label.Hide();
            PasswordDoesNotMatch_label.Hide();
            InvalidUsername_label.Hide();
            InvalidEmail_label.Hide();
            InvalidPassword_label.Hide();
            InvalidName_label.Hide();
        }

        private void ClearTextInputs()
        {
            RegisterName_textbox.Text = "";
            RegisterUsername_textbox.Text = "";
            RegisterEmail_textbox.Text = "";
            RegisterReEmail_textbox.Text = "";
            RegisterPassword_textbox.Text = "";
            RegisterRePassword_textbox.Text = "";
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Create_button_Click(object sender, EventArgs e)
        {
            Create_button.Enabled = false;
            ResetErrorMessages();
            bool inputsValid = true;

            if (!(sqlConn.CheckConnection()))
            {
                inputsValid = false;
                CantConnect_label.Show();
            }
            if (String.IsNullOrEmpty(RegisterName_textbox.Text))
            {
                inputsValid = false;
                InvalidName_label.Show();
            }
            if (String.IsNullOrEmpty(RegisterUsername_textbox.Text))
            {
                inputsValid = false;
                InvalidUsername_label.Show();
            }
            else if (sqlConn.CheckIfUserExists(RegisterUsername_textbox.Text))
            {
                inputsValid = false;
                UsernameTaken_label.Show();
            }
            if (String.IsNullOrEmpty(RegisterEmail_textbox.Text) || !(RegisterEmail_textbox.Text.Contains(@"@")) || !(RegisterEmail_textbox.Text.Contains(@".")))
            {
                inputsValid = false;
                InvalidEmail_label.Show();
            }
            else if (sqlConn.CheckIfEmailExists(RegisterEmail_textbox.Text))
            {
                inputsValid = false;
                EmailInUse_label.Show();
            }
            if (!(String.Equals(RegisterEmail_textbox.Text, RegisterReEmail_textbox.Text)))
            {
                inputsValid = false;
                EmailDoesNotMatch_label.Show();
            }
            if (String.IsNullOrEmpty(RegisterPassword_textbox.Text))
            {
                inputsValid = false;
                InvalidPassword_label.Show();
            }
            if (!(String.Equals(RegisterPassword_textbox.Text, RegisterRePassword_textbox.Text)))
            {
                inputsValid = false;
                PasswordDoesNotMatch_label.Show();
            }
            if (inputsValid)
            {
                
                sqlConn.AddUser(RegisterUsername_textbox.Text, RegisterName_textbox.Text, RegisterEmail_textbox.Text, CreateHashedPassword(RegisterPassword_textbox.Text, (RegisterName_textbox.Text + RegisterEmail_textbox.TextLength + "*auK7LUbAB0HGQSV")));
                ResetErrorMessages();
                ClearTextInputs();
                StoreWindowSettings();
                controller.CurrentState = (int)EnumState.Login;
            }
            Create_button.Enabled = true;
        }

        private string CreateHashedPassword(string password, string salt)
        {
            byte[] newSalt = Encoding.ASCII.GetBytes(salt);
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, newSalt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(newSalt, 0, hashBytes, 0 ,16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            StoreWindowSettings();
            ResetErrorMessages();
            ClearTextInputs();
            controller.CurrentState = (int)EnumState.Login;
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

    }
}
