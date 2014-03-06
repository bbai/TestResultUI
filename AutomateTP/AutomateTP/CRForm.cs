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
            userStoryComboBox.Items.Add(string.Empty);
            LoginCompleteLbl.Visible = true;
        }
        private string GetBugName()
        {
            return NameTxtBox.Text;
        }
        private string GetBugLocation()
        {
            return NAStxtBox.Text;
        }
        private string GetChosenProject()
        {
            return ProjectComboBox.SelectedText;
        }
        private string GetChosenUserStory()
        {
            return userStoryComboBox.SelectedText;
        }
        private string GetFailMessage()
        {
            return richTextBox1.Text;
        }

        private void SubmitCRBtn_Click(object sender, EventArgs e)
        {
            TargetProcessHelper.MakeCR(GetChosenProject(), GetChosenUserStory(), 
                GetBugName(), GetBugLocation(), GetFailMessage());
        }
    }
}
