using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mongo;

namespace UI
{
    public delegate void AcceptedFailureDialogClosed(string buttonClicked);
    public partial class AcceptedFailure : Form
    {
        public event AcceptedFailureDialogClosed OnFormClosed;
        private FailureHelper mFailureTracker;
        public string CloseReason = string.Empty;
        public AcceptedFailure(FailureHelper failureTracker)
        {
            mFailureTracker = failureTracker;
            InitializeComponent();
				this.AcceptButton = OkayBtn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Count() == 0)
            {
                MessageBox.Show("Please Enter Message!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool status = mFailureTracker.ProcessFailure(textBox1.Text);
                if (status == true)
                {
                    MessageBox.Show("Marking as Accepted Failure Success!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                OnFormClosed("OK");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OnFormClosed("Cancel");
            this.Close();
        }
    }
}
