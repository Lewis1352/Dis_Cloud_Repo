namespace Cloud_Repo_App
{
    partial class File_transfer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Upload_button = new System.Windows.Forms.Button();
            this.file_listBox = new System.Windows.Forms.ListBox();
            this.LogOut_button = new System.Windows.Forms.Button();
            this.Download_button = new System.Windows.Forms.Button();
            this.Delete_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Upload_button
            // 
            this.Upload_button.Location = new System.Drawing.Point(34, 250);
            this.Upload_button.Name = "Upload_button";
            this.Upload_button.Size = new System.Drawing.Size(77, 29);
            this.Upload_button.TabIndex = 0;
            this.Upload_button.Text = "Upload";
            this.Upload_button.UseVisualStyleBackColor = true;
            this.Upload_button.Click += new System.EventHandler(this.Upload_button_Click);
            // 
            // file_listBox
            // 
            this.file_listBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.file_listBox.FormattingEnabled = true;
            this.file_listBox.ItemHeight = 16;
            this.file_listBox.Location = new System.Drawing.Point(12, 12);
            this.file_listBox.Name = "file_listBox";
            this.file_listBox.Size = new System.Drawing.Size(758, 212);
            this.file_listBox.TabIndex = 1;
            // 
            // LogOut_button
            // 
            this.LogOut_button.Location = new System.Drawing.Point(34, 467);
            this.LogOut_button.Name = "LogOut_button";
            this.LogOut_button.Size = new System.Drawing.Size(77, 29);
            this.LogOut_button.TabIndex = 2;
            this.LogOut_button.Text = "Log Out";
            this.LogOut_button.UseVisualStyleBackColor = true;
            this.LogOut_button.Click += new System.EventHandler(this.LogOut_button_Click);
            // 
            // Download_button
            // 
            this.Download_button.Location = new System.Drawing.Point(654, 250);
            this.Download_button.Name = "Download_button";
            this.Download_button.Size = new System.Drawing.Size(87, 29);
            this.Download_button.TabIndex = 3;
            this.Download_button.Text = "Download";
            this.Download_button.UseVisualStyleBackColor = true;
            this.Download_button.Click += new System.EventHandler(this.Download_button_Click);
            // 
            // Delete_button
            // 
            this.Delete_button.Location = new System.Drawing.Point(523, 250);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(87, 29);
            this.Delete_button.TabIndex = 4;
            this.Delete_button.Text = "Delete";
            this.Delete_button.UseVisualStyleBackColor = true;
            this.Delete_button.Click += new System.EventHandler(this.Delete_button_Click);
            // 
            // File_transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.Delete_button);
            this.Controls.Add(this.Download_button);
            this.Controls.Add(this.LogOut_button);
            this.Controls.Add(this.file_listBox);
            this.Controls.Add(this.Upload_button);
            this.Name = "File_transfer";
            this.Text = "File_transfer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.File_transfer_FormClosing);
            this.Load += new System.EventHandler(this.File_transfer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Upload_button;
        private System.Windows.Forms.ListBox file_listBox;
        private System.Windows.Forms.Button LogOut_button;
        private System.Windows.Forms.Button Download_button;
        private System.Windows.Forms.Button Delete_button;
    }
}