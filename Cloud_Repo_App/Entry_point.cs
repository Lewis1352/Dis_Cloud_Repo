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
    public enum EnumState
    {
        DefaultState,
        Register,
        Login,
        LoggedIn
    }

    public partial class Entry_point : Form
    {

        Login loginForm;
        Register registerForm;
        SQL_conn sqlConn;
        File_transfer fileForm;

        private int currentState;

        public int CurrentState
        {
            get
            {
                return currentState;
            }
            set
            {
                currentState = value;
                StateChangeHandler(currentState);
            }
        }

        private string currentUser;

        public string CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
            }
        }

        public Entry_point()
        {
            InitializeComponent();
            sqlConn = new SQL_conn();
            loginForm = new Login(this, sqlConn);
            registerForm = new Register(this, sqlConn);
            fileForm = new File_transfer(this, sqlConn);
        }

        private void DisplayLoginForm()
        {
            registerForm.Hide();
            fileForm.Hide();
            loginForm.LoadWindowSettings();
            loginForm.Show();
        }

        private void DisplayRegisterForm()
        {
            loginForm.Hide();
            fileForm.Hide();
            registerForm.LoadWindowSettings();
            registerForm.Show();
        }

        private void DisplayFileForm()
        {
            loginForm.Hide();
            registerForm.Hide();
            fileForm.LoadWindowSettings();
            fileForm.Show();
        }

        private void StateChangeHandler(int state)
        {
            if (state == (int)EnumState.Login)
            {
                DisplayLoginForm();
            }
            if (state == (int)EnumState.Register)
            {
                DisplayRegisterForm();
            }
            if (state == (int)EnumState.LoggedIn)
            {
                DisplayFileForm();
            }
        }

        private void Entry_point_Shown(object sender, EventArgs e)
        {
            StoreWindowSettings();
            CurrentState = (int)EnumState.Login;
            this.Hide();
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
    }
}
