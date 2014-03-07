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
    public partial class LogBugCR : Form
    {
        public LogBugCR()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            //add logic to save CrNumTxt.text as the message
            if (CrNumTxt.TextLength == 5)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter the CR number relating to this bug.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
