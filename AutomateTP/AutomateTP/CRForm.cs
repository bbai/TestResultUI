using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutomateTP
{
    public partial class CRForm : Form
    {
        public CRForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void credentialsBtn_Click(object sender, EventArgs e)
        {
            TargetProcessHelper.authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(usernameTxtBox.Text 
                + ":" + passwordTxtBox.Text));
            ProjectComboBox.Items.AddRange(TargetProcessHelper.GetProjects().ToArray());
            userStoryComboBox.Items.AddRange(TargetProcessHelper.GetUserStories().ToArray());
            LoginCompleteLbl.Visible = true;
        }
    }
}
