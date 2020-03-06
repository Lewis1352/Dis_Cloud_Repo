namespace Cloud_Repo_App
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Username_textbox = new System.Windows.Forms.TextBox();
            this.Password_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Login_button = new System.Windows.Forms.Button();
            this.Register_button = new System.Windows.Forms.Button();
            this.InvalidLogin_label = new System.Windows.Forms.Label();
            this.CantConnect_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // Username_textbox
            // 
            this.Username_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Username_textbox.Location = new System.Drawing.Point(307, 169);
            this.Username_textbox.Name = "Username_textbox";
            this.Username_textbox.Size = new System.Drawing.Size(206, 22);
            this.Username_textbox.TabIndex = 2;
            // 
            // Password_textbox
            // 
            this.Password_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Password_textbox.Location = new System.Drawing.Point(307, 197);
            this.Password_textbox.Name = "Password_textbox";
            this.Password_textbox.PasswordChar = '*';
            this.Password_textbox.Size = new System.Drawing.Size(206, 22);
            this.Password_textbox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(127, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(508, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "Welcome to the cloud storage application";
            // 
            // Login_button
            // 
            this.Login_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Login_button.Location = new System.Drawing.Point(436, 241);
            this.Login_button.Name = "Login_button";
            this.Login_button.Size = new System.Drawing.Size(77, 29);
            this.Login_button.TabIndex = 5;
            this.Login_button.Text = "Login";
            this.Login_button.UseVisualStyleBackColor = true;
            this.Login_button.Click += new System.EventHandler(this.Login_button_Click);
            // 
            // Register_button
            // 
            this.Register_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Register_button.Location = new System.Drawing.Point(307, 241);
            this.Register_button.Name = "Register_button";
            this.Register_button.Size = new System.Drawing.Size(77, 29);
            this.Register_button.TabIndex = 6;
            this.Register_button.Text = "Register";
            this.Register_button.UseVisualStyleBackColor = true;
            this.Register_button.Click += new System.EventHandler(this.Register_button_Click);
            // 
            // InvalidLogin_label
            // 
            this.InvalidLogin_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InvalidLogin_label.AutoSize = true;
            this.InvalidLogin_label.ForeColor = System.Drawing.Color.Red;
            this.InvalidLogin_label.Location = new System.Drawing.Point(519, 200);
            this.InvalidLogin_label.Name = "InvalidLogin_label";
            this.InvalidLogin_label.Size = new System.Drawing.Size(127, 17);
            this.InvalidLogin_label.TabIndex = 24;
            this.InvalidLogin_label.Text = "Invalid login details";
            // 
            // CantConnect_label
            // 
            this.CantConnect_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CantConnect_label.AutoSize = true;
            this.CantConnect_label.ForeColor = System.Drawing.Color.Red;
            this.CantConnect_label.Location = new System.Drawing.Point(171, 290);
            this.CantConnect_label.Name = "CantConnect_label";
            this.CantConnect_label.Size = new System.Drawing.Size(455, 17);
            this.CantConnect_label.TabIndex = 25;
            this.CantConnect_label.Text = "Application cannot reach server please check internet or try again later";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.CantConnect_label);
            this.Controls.Add(this.InvalidLogin_label);
            this.Controls.Add(this.Register_button);
            this.Controls.Add(this.Login_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Password_textbox);
            this.Controls.Add(this.Username_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Login";
            this.Text = "Cloud Repo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Username_textbox;
        private System.Windows.Forms.TextBox Password_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Login_button;
        private System.Windows.Forms.Button Register_button;
        private System.Windows.Forms.Label InvalidLogin_label;
        private System.Windows.Forms.Label CantConnect_label;
    }
}

