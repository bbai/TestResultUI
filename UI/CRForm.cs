using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Mongo;
namespace UI
{
    public partial class CRForm : Form
    {
        private FailureHelper mFailureTracker;
        private Properties.TP TPsettings;
        public CRForm(FailureHelper failureTracker)
        {
            mFailureTracker = failureTracker;
            InitializeComponent();
            TargetProcessHelper.client = new System.Net.WebClient();
            this.AcceptButton = credentialsBtn;
            TPsettings = new Properties.TP();
            usernameTxtBox.Text = TPsettings.UserName;
            passwordTxtBox.Text = TPsettings.Password;
        }
        private void credentialsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //if no info provided
                if (usernameTxtBox.Text == null || passwordTxtBox.Text == null)
                {
                    MessageBox.Show("Please enter a username and password.", "Login Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //set credentials with contents of boxes
                else
                {
                    TargetProcessHelper.client.Credentials = new System.Net.NetworkCredential(usernameTxtBox.Text,
                        passwordTxtBox.Text);
                    //save settings
                    TPsettings.UserName = usernameTxtBox.Text;
                    TPsettings.Password = passwordTxtBox.Text;
                    PrepareCR();
                }
            }
            //check that user is authorized or entered correct username/password
            catch(WebException ex)
            {
                if (ex.Message.Contains("The remote server returned an error: (401) Unauthorized."))
                {
                    MessageBox.Show("Incorrect UserName or Password", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TargetProcessHelper.client.Credentials = null;
                }
                else 
                {
                    throw;
                }               
            }
        }
        private void PrepareCR()
        {
            ProjectComboBox.Items.AddRange(TargetProcessHelper.GetProjects().ToArray());
            userStoryComboBox.Items.AddRange(TargetProcessHelper.GetUserStories().ToArray());
            userStoryComboBox.Items.Add(string.Empty);
            SubmitCRBtn.Enabled = true;
            LoginCompleteLbl.Visible = true;
        }
        //send information to TP to submitCR
        #region TPstuff
        private string GetBugName()
        {
            return NameTxtBox.Text;
        }
        private string GetBugLocation()
        {
            return NAStxtBox.Text;
        }
        private ProjectInfo GetChosenProject()
        {
            return (ProjectInfo)ProjectComboBox.SelectedItem;
        }
        private UserStoryInfo GetChosenUserStory()
        {
            return (UserStoryInfo)userStoryComboBox.SelectedItem;
        }
        private string GetFailMessage()
        {
            return richTextBox1.Text;
        }

        private void SubmitCRBtn_Click(object sender, EventArgs e)
        {
            string result = TargetProcessHelper.MakeCR(GetChosenProject(), GetChosenUserStory(), 
                GetBugName(), GetBugLocation(), GetFailMessage());
            if (result != null)
            {
                MessageBox.Show("Success! CR#" + result + " submitted.");
                mFailureTracker.ProcessFailure("http://target.openspan.com/tp/entity/" + result);
                this.Close();
            }
        }
        #endregion
    }
}
