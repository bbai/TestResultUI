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

        FailureHelper failureTracker;
        private string mProjectName;
        private string mRuntimeVersion;
        private string mAutomationName;

        public AcceptedFailure(string serverAddr, string port, string dbName, string projectName, string runtimeVersion, string automationName)
        {
            failureTracker = new FailureHelper(serverAddr + ":" + port, dbName);
            mProjectName = projectName;
            mRuntimeVersion = runtimeVersion;
            mAutomationName = automationName;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (textBox1.Text.Count() == 0)
            {
                MessageBox.Show("Please Enter Message!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            failureTracker.ProcessFailure(mProjectName, mRuntimeVersion, mAutomationName, "False", "AcceptedFailure", textBox1.Text);
            this.Close();
        }
    }
}
