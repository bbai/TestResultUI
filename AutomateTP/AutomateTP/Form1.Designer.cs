namespace AutomateTP
{
    partial class Form1
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
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.ProjectLbl = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.FailureMsgLbl = new System.Windows.Forms.Label();
            this.NASlbl = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Location = new System.Drawing.Point(159, 382);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(87, 23);
            this.SubmitBtn.TabIndex = 0;
            this.SubmitBtn.Text = "SubmitCR";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            // 
            // ProjectLbl
            // 
            this.ProjectLbl.AutoSize = true;
            this.ProjectLbl.Location = new System.Drawing.Point(13, 13);
            this.ProjectLbl.Name = "ProjectLbl";
            this.ProjectLbl.Size = new System.Drawing.Size(52, 17);
            this.ProjectLbl.TabIndex = 1;
            this.ProjectLbl.Text = "Project";
            this.ProjectLbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Location = new System.Drawing.Point(13, 48);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(45, 17);
            this.NameLbl.TabIndex = 2;
            this.NameLbl.Text = "Name";
            // 
            // FailureMsgLbl
            // 
            this.FailureMsgLbl.AutoSize = true;
            this.FailureMsgLbl.Location = new System.Drawing.Point(13, 124);
            this.FailureMsgLbl.Name = "FailureMsgLbl";
            this.FailureMsgLbl.Size = new System.Drawing.Size(112, 17);
            this.FailureMsgLbl.TabIndex = 3;
            this.FailureMsgLbl.Text = "Failure Message";
            // 
            // NASlbl
            // 
            this.NASlbl.AutoSize = true;
            this.NASlbl.Location = new System.Drawing.Point(13, 86);
            this.NASlbl.Name = "NASlbl";
            this.NASlbl.Size = new System.Drawing.Size(94, 17);
            this.NASlbl.TabIndex = 4;
            this.NASlbl.Text = "NAS Location";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(19, 148);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(369, 228);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(270, 22);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(113, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(270, 22);
            this.textBox2.TabIndex = 7;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(113, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(270, 24);
            this.comboBox1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 417);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.NASlbl);
            this.Controls.Add(this.FailureMsgLbl);
            this.Controls.Add(this.NameLbl);
            this.Controls.Add(this.ProjectLbl);
            this.Controls.Add(this.SubmitBtn);
            this.Name = "Form1";
            this.Text = "Enter CR Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Label ProjectLbl;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Label FailureMsgLbl;
        private System.Windows.Forms.Label NASlbl;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

