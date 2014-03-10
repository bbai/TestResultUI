using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace AutomateTP
{
    public partial class CRForm : Form
    {
        public CRForm()
        {
            InitializeComponent();
            TargetProcessHelper.client = new System.Net.WebClient();
        }
        public CRForm(string user, string pw)
        {
            //add in show user they don't have to enter user/pw
            TargetProcessHelper.client.Credentials = new System.Net.NetworkCredential(user, pw);
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
                //if credentials already provided
                else if (TargetProcessHelper.client.Credentials != null)
                {
                    usernameTxtBox.Text = "Already Logged In";
                    PrepareCR();
                }
                //set new credentials
                else
                {
                    TargetProcessHelper.client.Credentials = new System.Net.NetworkCredential(usernameTxtBox.Text,
                        passwordTxtBox.Text);

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
        //currently not used. Need to find a good time to use TestResults.cs to call this one.
        public string[] SendAuth()
        {
            return new string[2]{usernameTxtBox.Text, passwordTxtBox.Text};
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
                this.Close();
            }
        }
        #endregion
    }
}
