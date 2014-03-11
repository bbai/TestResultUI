namespace UI
{
    partial class CRForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CRForm));
            this.TPgroupBox = new System.Windows.Forms.GroupBox();
            this.LoginCompleteLbl = new System.Windows.Forms.Label();
            this.credentialsBtn = new System.Windows.Forms.Button();
            this.UsernameLbl = new System.Windows.Forms.Label();
            this.passwordTxtBox = new System.Windows.Forms.TextBox();
            this.PasswordLbl = new System.Windows.Forms.Label();
            this.usernameTxtBox = new System.Windows.Forms.TextBox();
            this.ProjectLbl = new System.Windows.Forms.Label();
            this.ProjectComboBox = new System.Windows.Forms.ComboBox();
            this.NameLbl = new System.Windows.Forms.Label();
            this.FailureMsgLbl = new System.Windows.Forms.Label();
            this.NASlbl = new System.Windows.Forms.Label();
            this.NAStxtBox = new System.Windows.Forms.TextBox();
            this.NameTxtBox = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SubmitCRBtn = new System.Windows.Forms.Button();
            this.UserStoryLbl = new System.Windows.Forms.Label();
            this.userStoryComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TPgroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TPgroupBox
            // 
            this.TPgroupBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TPgroupBox.Controls.Add(this.LoginCompleteLbl);
            this.TPgroupBox.Controls.Add(this.credentialsBtn);
            this.TPgroupBox.Controls.Add(this.UsernameLbl);
            this.TPgroupBox.Controls.Add(this.passwordTxtBox);
            this.TPgroupBox.Controls.Add(this.PasswordLbl);
            this.TPgroupBox.Controls.Add(this.usernameTxtBox);
            this.TPgroupBox.Location = new System.Drawing.Point(10, 10);
            this.TPgroupBox.Name = "TPgroupBox";
            this.TPgroupBox.Size = new System.Drawing.Size(532, 130);
            this.TPgroupBox.TabIndex = 1;
            this.TPgroupBox.TabStop = false;
            this.TPgroupBox.Text = "TargetProcess Credentials";
            // 
            // LoginCompleteLbl
            // 
            this.LoginCompleteLbl.AutoSize = true;
            this.LoginCompleteLbl.Location = new System.Drawing.Point(118, 98);
            this.LoginCompleteLbl.Name = "LoginCompleteLbl";
            this.LoginCompleteLbl.Size = new System.Drawing.Size(110, 17);
            this.LoginCompleteLbl.TabIndex = 16;
            this.LoginCompleteLbl.Text = "Log In Complete";
            this.LoginCompleteLbl.Visible = false;
            // 
            // credentialsBtn
            // 
            this.credentialsBtn.Location = new System.Drawing.Point(28, 93);
            this.credentialsBtn.Name = "credentialsBtn";
            this.credentialsBtn.Size = new System.Drawing.Size(75, 27);
            this.credentialsBtn.TabIndex = 15;
            this.credentialsBtn.Text = "Log In";
            this.credentialsBtn.UseVisualStyleBackColor = true;
            this.credentialsBtn.Click += new System.EventHandler(this.credentialsBtn_Click);
            // 
            // UsernameLbl
            // 
            this.UsernameLbl.AutoSize = true;
            this.UsernameLbl.Location = new System.Drawing.Point(25, 28);
            this.UsernameLbl.Name = "UsernameLbl";
            this.UsernameLbl.Size = new System.Drawing.Size(73, 17);
            this.UsernameLbl.TabIndex = 13;
            this.UsernameLbl.Text = "Username";
            // 
            // passwordTxtBox
            // 
            this.passwordTxtBox.Location = new System.Drawing.Point(112, 64);
            this.passwordTxtBox.Name = "passwordTxtBox";
            this.passwordTxtBox.PasswordChar = '*';
            this.passwordTxtBox.Size = new System.Drawing.Size(387, 22);
            this.passwordTxtBox.TabIndex = 3;
            this.passwordTxtBox.UseSystemPasswordChar = true;
            // 
            // PasswordLbl
            // 
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.Location = new System.Drawing.Point(25, 64);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(69, 17);
            this.PasswordLbl.TabIndex = 14;
            this.PasswordLbl.Text = "Password";
            // 
            // usernameTxtBox
            // 
            this.usernameTxtBox.Location = new System.Drawing.Point(112, 28);
            this.usernameTxtBox.Name = "usernameTxtBox";
            this.usernameTxtBox.Size = new System.Drawing.Size(387, 22);
            this.usernameTxtBox.TabIndex = 2;
            // 
            // ProjectLbl
            // 
            this.ProjectLbl.AutoSize = true;
            this.ProjectLbl.Location = new System.Drawing.Point(14, 28);
            this.ProjectLbl.Name = "ProjectLbl";
            this.ProjectLbl.Size = new System.Drawing.Size(52, 17);
            this.ProjectLbl.TabIndex = 9;
            this.ProjectLbl.Text = "Project";
            // 
            // ProjectComboBox
            // 
            this.ProjectComboBox.FormattingEnabled = true;
            this.ProjectComboBox.Location = new System.Drawing.Point(114, 28);
            this.ProjectComboBox.Name = "ProjectComboBox";
            this.ProjectComboBox.Size = new System.Drawing.Size(403, 24);
            this.ProjectComboBox.TabIndex = 4;
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Location = new System.Drawing.Point(14, 108);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(45, 17);
            this.NameLbl.TabIndex = 10;
            this.NameLbl.Text = "Name";
            // 
            // FailureMsgLbl
            // 
            this.FailureMsgLbl.AutoSize = true;
            this.FailureMsgLbl.Location = new System.Drawing.Point(14, 187);
            this.FailureMsgLbl.Name = "FailureMsgLbl";
            this.FailureMsgLbl.Size = new System.Drawing.Size(112, 17);
            this.FailureMsgLbl.TabIndex = 11;
            this.FailureMsgLbl.Text = "Failure Message";
            // 
            // NASlbl
            // 
            this.NASlbl.AutoSize = true;
            this.NASlbl.Location = new System.Drawing.Point(14, 146);
            this.NASlbl.Name = "NASlbl";
            this.NASlbl.Size = new System.Drawing.Size(94, 17);
            this.NASlbl.TabIndex = 12;
            this.NASlbl.Text = "NAS Location";
            // 
            // NAStxtBox
            // 
            this.NAStxtBox.Location = new System.Drawing.Point(114, 146);
            this.NAStxtBox.Name = "NAStxtBox";
            this.NAStxtBox.Size = new System.Drawing.Size(403, 22);
            this.NAStxtBox.TabIndex = 6;
            // 
            // NameTxtBox
            // 
            this.NameTxtBox.Location = new System.Drawing.Point(114, 108);
            this.NameTxtBox.Name = "NameTxtBox";
            this.NameTxtBox.Size = new System.Drawing.Size(403, 22);
            this.NameTxtBox.TabIndex = 5;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(17, 207);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(500, 228);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // SubmitCRBtn
            // 
            this.SubmitCRBtn.Enabled = false;
            this.SubmitCRBtn.Location = new System.Drawing.Point(204, 443);
            this.SubmitCRBtn.Name = "SubmitCRBtn";
            this.SubmitCRBtn.Size = new System.Drawing.Size(87, 23);
            this.SubmitCRBtn.TabIndex = 8;
            this.SubmitCRBtn.Text = "SubmitCR";
            this.SubmitCRBtn.UseVisualStyleBackColor = true;
            this.SubmitCRBtn.Click += new System.EventHandler(this.SubmitCRBtn_Click);
            // 
            // UserStoryLbl
            // 
            this.UserStoryLbl.AutoSize = true;
            this.UserStoryLbl.Location = new System.Drawing.Point(14, 72);
            this.UserStoryLbl.Name = "UserStoryLbl";
            this.UserStoryLbl.Size = new System.Drawing.Size(75, 17);
            this.UserStoryLbl.TabIndex = 13;
            this.UserStoryLbl.Text = "User Story";
            // 
            // userStoryComboBox
            // 
            this.userStoryComboBox.FormattingEnabled = true;
            this.userStoryComboBox.Location = new System.Drawing.Point(114, 69);
            this.userStoryComboBox.Name = "userStoryComboBox";
            this.userStoryComboBox.Size = new System.Drawing.Size(403, 24);
            this.userStoryComboBox.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.ProjectLbl);
            this.groupBox1.Controls.Add(this.userStoryComboBox);
            this.groupBox1.Controls.Add(this.SubmitCRBtn);
            this.groupBox1.Controls.Add(this.UserStoryLbl);
            this.groupBox1.Controls.Add(this.NameLbl);
            this.groupBox1.Controls.Add(this.FailureMsgLbl);
            this.groupBox1.Controls.Add(this.ProjectComboBox);
            this.groupBox1.Controls.Add(this.NASlbl);
            this.groupBox1.Controls.Add(this.NameTxtBox);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.NAStxtBox);
            this.groupBox1.Location = new System.Drawing.Point(10, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 476);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // CRForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(144)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(552, 636);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TPgroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CRForm";
            this.Text = "Enter Bug Information";
            this.TPgroupBox.ResumeLayout(false);
            this.TPgroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SubmitCRBtn;
        private System.Windows.Forms.Label ProjectLbl;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Label FailureMsgLbl;
        private System.Windows.Forms.Label NASlbl;
        public System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.TextBox NAStxtBox;
        public System.Windows.Forms.TextBox NameTxtBox;
        private System.Windows.Forms.ComboBox ProjectComboBox;
        private System.Windows.Forms.Label UsernameLbl;
        private System.Windows.Forms.Label PasswordLbl;
        public System.Windows.Forms.TextBox usernameTxtBox;
        public System.Windows.Forms.TextBox passwordTxtBox;
        private System.Windows.Forms.GroupBox TPgroupBox;
        private System.Windows.Forms.Button credentialsBtn;
        private System.Windows.Forms.Label LoginCompleteLbl;
        private System.Windows.Forms.Label UserStoryLbl;
        private System.Windows.Forms.ComboBox userStoryComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

