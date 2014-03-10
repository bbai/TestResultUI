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
    public partial class AcceptedFailure : Form
    {

        private FailureHelper mFailureTracker;

        public AcceptedFailure(FailureHelper failureTracker)
        {
            mFailureTracker = failureTracker;
            InitializeComponent();
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
                this.Close();
            }
        }
    }
}
