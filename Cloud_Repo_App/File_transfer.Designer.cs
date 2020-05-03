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
            this.SuspendLayout();
            // 
            // Upload_button
            // 
            this.Upload_button.Location = new System.Drawing.Point(157, 326);
            this.Upload_button.Name = "Upload_button";
            this.Upload_button.Size = new System.Drawing.Size(77, 29);
            this.Upload_button.TabIndex = 0;
            this.Upload_button.Text = "Upload";
            this.Upload_button.UseVisualStyleBackColor = true;
            this.Upload_button.Click += new System.EventHandler(this.Upload_button_Click);
            // 
            // File_transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.Upload_button);
            this.Name = "File_transfer";
            this.Text = "File_transfer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.File_transfer_FormClosing);
            this.Load += new System.EventHandler(this.File_transfer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Upload_button;
    }
}