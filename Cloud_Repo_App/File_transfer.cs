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
    public partial class File_transfer : Form
    {

        Entry_point controller;
        SQL_conn sqlConn;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        FolderBrowserDialog openBrowserDialog = new FolderBrowserDialog();
        DialogResult deleteBoxResult = new DialogResult();

        public File_transfer(Entry_point mainForm, SQL_conn sqlControl)
        {
            InitializeComponent();
            controller = mainForm;
            sqlConn = sqlControl;
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

        private void File_transfer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void File_transfer_Load(object sender, EventArgs e)
        {
            LoadWindowSettings();
            Show_current_files();
        }

        private void Upload_button_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = openFileDialog.SafeFileName;
                sqlConn.UploadFile(filePath, fileName, controller.CurrentUser);
                Show_current_files();
            }
        }

        private void Show_current_files()
        {
            List<string> files = sqlConn.getFileList(controller.CurrentUser);
            file_listBox.Items.Clear();
            foreach (var name in files)
            {
                if (!file_listBox.Items.Contains(name))
                {
                    file_listBox.Items.Add(name);
                }
            }
        }

        private void Reset_list()
        {
            file_listBox.Items.Clear();
        }

        private void LogOut_button_Click(object sender, EventArgs e)
        {
            Reset_list();
            controller.CurrentState = (int)EnumState.Login;
        }

        private void Download_button_Click(object sender, EventArgs e)
        {
            if (openBrowserDialog.ShowDialog() == DialogResult.OK)
            {


                string downloadLocation = openBrowserDialog.SelectedPath;
                sqlConn.DownloadFile(downloadLocation, file_listBox.SelectedItem.ToString(), controller.CurrentUser);
            }
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            if (file_listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select file to delete", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                deleteBoxResult = MessageBox.Show("Are you sure you want to delete?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (deleteBoxResult == DialogResult.Yes)
                {
                    sqlConn.RemoveFile(file_listBox.SelectedItem.ToString(), controller.CurrentUser);
                    Show_current_files();
                }
            }
        }
    }
}
