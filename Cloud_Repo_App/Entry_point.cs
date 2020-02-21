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
        Login
    }

    public partial class Entry_point : Form
    {
        Login loginForm = new Login();
        Register registerForm = new Register();

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
            CurrentState = (int)EnumState.Login;



            this.Hide();
            loginForm.Show();
        }

        public void DisplayLoginForm()
        {
            registerForm.Hide();
            loginForm.Show();
        }

        public void DisplayRegisterForm()
        {
            registerForm.Show();
            loginForm.Hide();
        }

        private void StateChangeHandler(int state)
        {
            if (state == (int)EnumState.Login)
            {
                
            }
            if (state == (int)EnumState.Register)
            {
                
            }
        }


    }
}
