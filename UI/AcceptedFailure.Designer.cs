namespace UI
{
    partial class AcceptedFailure
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
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcceptedFailure));
				this.label1 = new System.Windows.Forms.Label();
				this.textBox1 = new System.Windows.Forms.TextBox();
				this.OkayBtn = new System.Windows.Forms.Button();
				this.CancelBtn = new System.Windows.Forms.Button();
				this.SuspendLayout();
				// 
				// label1
				// 
				this.label1.AutoSize = true;
				this.label1.Location = new System.Drawing.Point(11, 15);
				this.label1.Name = "label1";
				this.label1.Size = new System.Drawing.Size(311, 17);
				this.label1.TabIndex = 0;
				this.label1.Text = "Please Enter Reason for Accepting This Failure:";
				// 
				// textBox1
				// 
				this.textBox1.Location = new System.Drawing.Point(11, 47);
				this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
				this.textBox1.Name = "textBox1";
				this.textBox1.Size = new System.Drawing.Size(426, 22);
				this.textBox1.TabIndex = 1;
				// 
				// OkayBtn
				// 
				this.OkayBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				this.OkayBtn.Location = new System.Drawing.Point(146, 79);
				this.OkayBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
				this.OkayBtn.Name = "OkayBtn";
				this.OkayBtn.Size = new System.Drawing.Size(73, 26);
				this.OkayBtn.TabIndex = 2;
				this.OkayBtn.Text = "Okay";
				this.OkayBtn.UseVisualStyleBackColor = false;
				this.OkayBtn.Click += new System.EventHandler(this.button1_Click);
				// 
				// CancelBtn
				// 
				this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				this.CancelBtn.Location = new System.Drawing.Point(239, 79);
				this.CancelBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
				this.CancelBtn.Name = "CancelBtn";
				this.CancelBtn.Size = new System.Drawing.Size(73, 26);
				this.CancelBtn.TabIndex = 3;
				this.CancelBtn.Text = "Cancel";
				this.CancelBtn.UseVisualStyleBackColor = false;
				this.CancelBtn.Click += new System.EventHandler(this.button2_Click);
				// 
				// AcceptedFailure
				// 
				this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.CancelButton = this.CancelBtn;
				this.ClientSize = new System.Drawing.Size(458, 131);
				this.ControlBox = false;
				this.Controls.Add(this.CancelBtn);
				this.Controls.Add(this.OkayBtn);
				this.Controls.Add(this.textBox1);
				this.Controls.Add(this.label1);
				this.ForeColor = System.Drawing.Color.Black;
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
				this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
				this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
				this.MaximizeBox = false;
				this.MinimizeBox = false;
				this.Name = "AcceptedFailure";
				this.Text = "Accepted Failure Message";
				this.ResumeLayout(false);
				this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button OkayBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}