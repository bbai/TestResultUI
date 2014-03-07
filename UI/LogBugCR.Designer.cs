namespace UI
{
    partial class LogBugCR
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.failureMsgTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CrNumTxt = new System.Windows.Forms.TextBox();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(450, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please  go to target.openspan.com/tp to log a CR for this bug with the \r\nfollowin" +
    "g information:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nameTxt);
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 61);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.failureMsgTxt);
            this.groupBox2.Location = new System.Drawing.Point(12, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 131);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Description";
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(6, 25);
            this.nameTxt.Multiline = true;
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.ReadOnly = true;
            this.nameTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.nameTxt.Size = new System.Drawing.Size(411, 25);
            this.nameTxt.TabIndex = 0;
            // 
            // failureMsgTxt
            // 
            this.failureMsgTxt.Location = new System.Drawing.Point(7, 22);
            this.failureMsgTxt.Multiline = true;
            this.failureMsgTxt.Name = "failureMsgTxt";
            this.failureMsgTxt.ReadOnly = true;
            this.failureMsgTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.failureMsgTxt.Size = new System.Drawing.Size(410, 103);
            this.failureMsgTxt.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter the CR Number and click close.";
            // 
            // CrNumTxt
            // 
            this.CrNumTxt.Location = new System.Drawing.Point(18, 305);
            this.CrNumTxt.Name = "CrNumTxt";
            this.CrNumTxt.Size = new System.Drawing.Size(114, 22);
            this.CrNumTxt.TabIndex = 5;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Enabled = false;
            this.CloseBtn.Location = new System.Drawing.Point(19, 337);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(80, 23);
            this.CloseBtn.TabIndex = 6;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // LogBugCR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 377);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.CrNumTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "LogBugCR";
            this.Text = "Add CR# Message";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox failureMsgTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CrNumTxt;
        private System.Windows.Forms.Button CloseBtn;
    }
}