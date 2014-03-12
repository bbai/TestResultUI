namespace UI
{
	 partial class StatusMessage
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
				this.CRlinkLbl = new System.Windows.Forms.LinkLabel();
				this.InfoLbl = new System.Windows.Forms.Label();
				this.OkayBtn = new System.Windows.Forms.Button();
				this.msgTxt = new System.Windows.Forms.TextBox();
				this.SuspendLayout();
				// 
				// CRlinkLbl
				// 
				this.CRlinkLbl.AutoSize = true;
				this.CRlinkLbl.Location = new System.Drawing.Point(21, 57);
				this.CRlinkLbl.Name = "CRlinkLbl";
				this.CRlinkLbl.Size = new System.Drawing.Size(72, 17);
				this.CRlinkLbl.TabIndex = 0;
				this.CRlinkLbl.TabStop = true;
				this.CRlinkLbl.Text = "linkLabel1";
				this.CRlinkLbl.Visible = false;
				this.CRlinkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CRlinkLbl_LinkClicked);
				// 
				// InfoLbl
				// 
				this.InfoLbl.AutoSize = true;
				this.InfoLbl.Location = new System.Drawing.Point(12, 9);
				this.InfoLbl.Name = "InfoLbl";
				this.InfoLbl.Size = new System.Drawing.Size(280, 17);
				this.InfoLbl.TabIndex = 1;
				this.InfoLbl.Text = "The failure status message for this node is:";
				// 
				// OkayBtn
				// 
				this.OkayBtn.Location = new System.Drawing.Point(394, 138);
				this.OkayBtn.Name = "OkayBtn";
				this.OkayBtn.Size = new System.Drawing.Size(75, 25);
				this.OkayBtn.TabIndex = 2;
				this.OkayBtn.Text = "Okay";
				this.OkayBtn.UseVisualStyleBackColor = true;
				this.OkayBtn.Click += new System.EventHandler(this.OkayBtn_Click);
				// 
				// msgTxt
				// 
				this.msgTxt.Location = new System.Drawing.Point(15, 43);
				this.msgTxt.Multiline = true;
				this.msgTxt.Name = "msgTxt";
				this.msgTxt.ReadOnly = true;
				this.msgTxt.Size = new System.Drawing.Size(454, 78);
				this.msgTxt.TabIndex = 3;
				this.msgTxt.Visible = false;
				// 
				// StatusMessage
				// 
				this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(481, 175);
				this.Controls.Add(this.msgTxt);
				this.Controls.Add(this.OkayBtn);
				this.Controls.Add(this.InfoLbl);
				this.Controls.Add(this.CRlinkLbl);
				this.Name = "StatusMessage";
				this.Text = "StatusMessage";
				this.ResumeLayout(false);
				this.PerformLayout();

		  }

		  #endregion

		  private System.Windows.Forms.LinkLabel CRlinkLbl;
		  private System.Windows.Forms.Label InfoLbl;
		  private System.Windows.Forms.Button OkayBtn;
		  private System.Windows.Forms.TextBox msgTxt;
	 }
}