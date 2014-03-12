using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
	 public partial class StatusMessage : Form
	 {
		  public StatusMessage(string msg)
		  {
				InitializeComponent();
				if (msg.Contains("http"))
				{
					 CRlinkLbl.Text = msg;
					 CRlinkLbl.Visible = true;
				}
				else
				{
					 msgTxt.Text = msg;
					 msgTxt.Visible = true;
				}
		  }

		  private void CRlinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		  {
				System.Diagnostics.Process.Start(CRlinkLbl.Text);
				this.Close();
		  }

		  private void OkayBtn_Click(object sender, EventArgs e)
		  {
				this.Close();
		  }
	 }
}
