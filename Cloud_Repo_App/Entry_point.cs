﻿using System;
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
        Login
    }

    public partial class Entry_point : Form
    {

        Login loginForm;
        Register registerForm;
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

        public Entry_point()
        {
            InitializeComponent();
            loginForm = new Login(this);
            registerForm = new Register(this);
        }

        private void DisplayLoginForm()
        {
            registerForm.Hide();
            loginForm.Show();
        }

        private void DisplayRegisterForm()
        {
            registerForm.Show();
            loginForm.Hide();
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