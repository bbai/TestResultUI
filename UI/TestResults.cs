using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mongo;
using SynapticEffect.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace UI
{
    public partial class TestResults : Form
    {
        MongoDBHelper mongo;
        Hashtable successAllConfigTable;
        Hashtable failAllConfigTable;
        Hashtable successConfigTable;
        Hashtable failConfigTable;
        string days;
        Properties.TP TPsettings;
        public TestResults()
        {
            InitializeComponent();
            this.AcceptButton = button1;
            TPsettings = new Properties.TP();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "10.0.3.26";
            textBox2.Text = "UnitTestDB";
            textBox3.Text = "UnitTestResults";
            textBox5.Text = "27017";
            textBox4.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Days.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
            }
            else
            {
                if (backgroundWorker1.IsBusy != true)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            mongo = new MongoDBHelper(textBox1.Text + ":" + textBox5.Text, textBox2.Text,
                    textBox3.Text, Convert.ToInt32(textBox4.Text));
            mongo.OnProgressUpdate += new ProgressUpdate(mongo_ProgressChanged);
            if (treeListView1.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    treeListView1.Nodes.Clear();
                });
            }
            else
            {
                treeListView1.Nodes.Clear();
            }
            try
            {
                mongo.AnalyzeData();
            }
            catch (MongoConnectionException ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mongo_ProgressChanged(int e)
        {
            base.Invoke((Action)delegate
            {
                label6.Text = "Processing.." + e.ToString() + "%";
            });
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
                return;
            if (mongo == null || days != textBox4.Text || treeListView1.Nodes.Count == 0)
            {
                days = textBox4.Text;
                treeListView1.Nodes.Clear();

                int[] results = mongo.GetNumTotalAndFail();
                if (treeListView1.Columns.Count != 7)
                {
                    treeListView1.Columns.Clear();
                    ToggleColumnHeader tch = new ToggleColumnHeader();
                    tch.Text = "Title";
                    tch.Width = 360;
                    treeListView1.Columns.Add(tch);
                    tch = new ToggleColumnHeader();
                    tch.Text = "Success";
                    treeListView1.Columns.Add(tch);
                    tch = new ToggleColumnHeader();
                    tch.Text = "Fail";
                    treeListView1.Columns.Add(tch);
                    tch = new ToggleColumnHeader();
                    tch.Text = "Accepted";
                    treeListView1.Columns.Add(tch);
                    tch = new ToggleColumnHeader();
                    tch.Text = "Bugs";
                    treeListView1.Columns.Add(tch);
                    tch = new ToggleColumnHeader();
                    tch.Text = "Last Runtime Version";
                    treeListView1.Columns.Add(tch);
                    tch = new ToggleColumnHeader();
                    tch.Text = "Failure Message";
                    tch.Width = 400;
                    treeListView1.Columns.Add(tch);
                }
                TreeListNode tln = new TreeListNode();
                tln.Text = "Test Run";
                tln.ImageIndex = 1;
                tln.SubItems.Add(Convert.ToString(results[0] - results[1]));
                tln.SubItems.Add(Convert.ToString(results[1]));
                TreeListNode allConfig = new TreeListNode();

                successAllConfigTable = mongo.successAllConfigTable;
                failAllConfigTable = mongo.failAllConfigTable;
                var successKey = successAllConfigTable.Keys;
                List<string> successKeys = successKey.Cast<string>().ToList();
                successKeys.Sort();
                var failKey = failAllConfigTable.Keys;
                List<string> failKeys = failKey.Cast<string>().ToList();
                failKeys.Sort();
                int totalSuccessAllConfigCount = 0;
                int totalFailAllConfigCount = 0;
                int acceptedFailureAllConfigCount = 0;
                int bugFailureAllConfigCount = 0;
                foreach (string projectName in successKeys)
                {
                    TreeListNode project = new TreeListNode();
                    project.Text = projectName;
                    Hashtable table = (Hashtable)successAllConfigTable[projectName];
                    var tableKeys = table.Keys;

                    foreach (string key in tableKeys)
                    {
                        TreeListNode automation = new TreeListNode();
                        ArrayList list = (ArrayList)table[key];
                        automation.Text = key;
                        automation.SubItems.Add("\u2714");
                        automation.SubItems.Add(" ");
                        automation.SubItems.Add(" ");
                        automation.SubItems.Add(" ");
                        automation.SubItems.Add((string)list[0]);
                        automation.Parent = project;
                        project.Nodes.Add(automation);
                    }

                    int successCount = table.Count;
                    totalSuccessAllConfigCount += successCount;


                    if (failAllConfigTable.ContainsKey(projectName) == true)
                    {
                        int acceptedFailureCount = 0;
                        int bugFailureCount = 0;
                        Hashtable failTable = (Hashtable)failAllConfigTable[projectName];
                        var failTableKeys = failTable.Keys;
                        foreach (string key in failTableKeys)
                        {
                            TreeListNode automation = new TreeListNode();
                            ArrayList list = (ArrayList)failTable[key];
                            automation.Text = key;
                            automation.SubItems.Add(" ");
                            string failureType = (string)list[0];
                            if (failureType.Equals("Failure") == true)
                            {
                                automation.SubItems.Add("\u2714");
                                automation.SubItems.Add(" ");
                                automation.SubItems.Add(" ");
                                automation.SubItems.Add((string)list[1]);
                            }
                            else if (failureType.Equals("AcceptedFailure") == true)
                            {
                                automation.SubItems.Add(" ");
                                automation.SubItems.Add("\u2714");
                                automation.SubItems.Add(" ");
                                automation.SubItems.Add((string)list[1]);
                                acceptedFailureCount++;
                            }
                            else if (failureType.Equals("Bug") == true)
                            {
                                automation.SubItems.Add(" ");
                                automation.SubItems.Add("");
                                automation.SubItems.Add("\u2714");
                                automation.SubItems.Add((string)list[1]);
                                bugFailureCount++;
                            }
                            automation.SubItems.Add((string)list[2]);
                            automation.Parent = project;
                            project.Nodes.Add(automation);
                        }
                        totalFailAllConfigCount += failTable.Count;
                        project.SubItems.Add(Convert.ToString(successCount));
                        project.SubItems.Add(Convert.ToString(failTable.Count - acceptedFailureCount - bugFailureCount));
                        project.SubItems.Add(Convert.ToString(acceptedFailureCount));
                        project.SubItems.Add(Convert.ToString(bugFailureCount));
                        acceptedFailureAllConfigCount += acceptedFailureCount;
                        bugFailureAllConfigCount += bugFailureCount;
                    }
                    else
                    {
                        project.SubItems.Add(Convert.ToString(successCount));
                        project.SubItems.Add("0");
                    }
                    allConfig.Text = "All Configs";
                    allConfig.Nodes.Add(project);
                }

                foreach (string projectName in failKeys)
                {
                    if (successAllConfigTable.ContainsKey(projectName) == false)
                    {
                        int acceptedFailCount = 0;
                        int bugFailCount = 0;
                        Hashtable failTable = (Hashtable)failAllConfigTable[projectName];
                        var failTableKeys = failTable.Keys;
                        int failCount = failTable.Count;
                        totalFailAllConfigCount += failCount;
                        TreeListNode project = new TreeListNode();
                        foreach (string key in failTableKeys)
                        {
                            TreeListNode automation = new TreeListNode();
                            ArrayList list = (ArrayList)failTable[key];
                            automation.Text = key;
                            automation.SubItems.Add(" ");
                            string failureType = (string)list[0];
                            if (failureType.Equals("Failure") == true)
                            {
                                automation.SubItems.Add("\u2714");
                                automation.SubItems.Add(" ");
                                automation.SubItems.Add(" ");
                                automation.SubItems.Add((string)list[1]);
                            }
                            else if (failureType.Equals("AcceptedFailure") == true)
                            {
                                automation.SubItems.Add(" ");
                                automation.SubItems.Add("\u2714");
                                automation.SubItems.Add(" ");
                                automation.SubItems.Add((string)list[1]);
                                acceptedFailCount++;
                            }
                            else if (failureType.Equals("Bug") == true)
                            {
                                automation.SubItems.Add(" ");
                                automation.SubItems.Add(" ");
                                automation.SubItems.Add("\u2714");
                                automation.SubItems.Add((string)list[1]);
                                bugFailCount++;
                            }
                            automation.SubItems.Add((string)list[2]);
                            automation.Parent = project;
                            project.Nodes.Add(automation);
                        }
                        project.Text = projectName;
                        project.SubItems.Add("0");
                        project.SubItems.Add(Convert.ToString(failCount - acceptedFailCount - bugFailCount));
                        project.SubItems.Add(Convert.ToString(acceptedFailCount));
                        project.SubItems.Add(Convert.ToString(bugFailCount));
                        acceptedFailureAllConfigCount += acceptedFailCount;
                        bugFailureAllConfigCount += bugFailCount;
                        allConfig.Nodes.Add(project);
                    }
                }
                allConfig.SubItems.Add(Convert.ToString(totalSuccessAllConfigCount));
                allConfig.SubItems.Add(Convert.ToString(totalFailAllConfigCount - acceptedFailureAllConfigCount - bugFailureAllConfigCount));
                allConfig.SubItems.Add(Convert.ToString(acceptedFailureAllConfigCount));
                allConfig.SubItems.Add(Convert.ToString(bugFailureAllConfigCount));
                tln.Nodes.Add(allConfig);

                successConfigTable = mongo.successConfigTable;
                failConfigTable = mongo.failConfigTable;
                var successConfigKey = successConfigTable.Keys;
                List<string> successConfigKeys = successConfigKey.Cast<string>().ToList();
                successConfigKeys.Sort();

                foreach (string configNames in successConfigKeys)
                {
                    int successConfigCount = 0;
                    int failConfigCount = 0;
                    int acceptedConfigCount = 0;
                    int bugConfigCount = 0;
                    TreeListNode configs = new TreeListNode();
                    Hashtable table = (Hashtable)successConfigTable[configNames];
                    Hashtable failTable = (Hashtable)failConfigTable[configNames];
                    var keyTable = table.Keys;
                    List<string> keys = keyTable.Cast<string>().ToList();
                    keys.Sort();
                    foreach (string key in keys)
                    {
                        int acceptedFailCount = 0;
                        int bugFailCount = 0;
                        TreeListNode project = new TreeListNode();
                        project.Text = key;
                        Hashtable successTable = (Hashtable)table[key];
                        var tableKeys = successTable.Keys;
                        Hashtable failSetTable = new Hashtable();
                        if (failTable.Count != 0)
                        {
                            failSetTable = (Hashtable)failTable[key];
                        }
                        
                        foreach (string automation in tableKeys)
                        {
                            TreeListNode node = new TreeListNode();
                            ArrayList list = (ArrayList)successTable[automation];
                            node.Text = automation;
                            node.SubItems.Add("\u2714");
                            node.SubItems.Add(" ");
                            node.SubItems.Add(" ");
                            node.SubItems.Add(" ");
                            node.SubItems.Add((string)list[0]);
                            node.Parent = project;
                            project.Nodes.Add(node);
                        }
                        if (failConfigTable.ContainsKey(configNames) == true)
                        {
                            if (failSetTable != null && failSetTable.Count > 0)
                            {
                                var failSetTalbekeys = failSetTable.Keys;
                                foreach (string automation in failSetTalbekeys)
                                {
                                    TreeListNode node = new TreeListNode();
                                    ArrayList list = (ArrayList)failSetTable[automation];
                                    node.Text = automation;
                                    node.SubItems.Add(" ");
                                    string failureType = (string)list[0];
                                    if (failureType.Equals("Failure") == true)
                                    {
                                        node.SubItems.Add("\u2714");
                                        node.SubItems.Add(" ");
                                        node.SubItems.Add(" ");
                                        node.SubItems.Add((string)list[1]);
                                    }
                                    else if (failureType.Equals("AcceptedFailure") == true)
                                    {
                                        node.SubItems.Add(" ");
                                        node.SubItems.Add("\u2714");
                                        node.SubItems.Add(" ");
                                        node.SubItems.Add((string)list[1]);
                                        acceptedFailCount++;
                                    }
                                    else if (failureType.Equals("Bug") == true)
                                    {
                                        node.SubItems.Add(" ");
                                        node.SubItems.Add("");
                                        node.SubItems.Add("\u2714");
                                        node.SubItems.Add((string)list[1]);
                                        bugFailCount++;
                                    }
                                    node.SubItems.Add((string)list[2]);
                                    node.Parent = project;
                                    project.Nodes.Add(node);
                                }
                            }
                        }
                        project.SubItems.Add(Convert.ToString(successTable.Count));
                        successConfigCount += successTable.Count;
                        if (failSetTable != null)
                        {
                            project.SubItems.Add(Convert.ToString(failSetTable.Count - acceptedFailCount - bugFailCount));
                            project.SubItems.Add(Convert.ToString(acceptedFailCount));
                            project.SubItems.Add(Convert.ToString(bugFailCount));
                            acceptedConfigCount += acceptedFailCount;
                            bugConfigCount += bugFailCount;
                            failConfigCount += failSetTable.Count;
                        }
                        else
                        {
                            project.SubItems.Add("0");
                        }
                        configs.Nodes.Add(project);
                    }

                    if (failConfigTable.ContainsKey(configNames) == true)
                    {
                        int acceptedFailCount = 0;
                        int bugFailCount = 0;
                        var failConfKey = failTable.Keys;
                        List<string> failConfKeys = failConfKey.Cast<string>().ToList();
                        failConfKeys.Sort();
                        foreach (string key in failConfKeys)
                        {
                            if (table.ContainsKey(key) == false)
                            {
                                TreeListNode project = new TreeListNode();
                                project.Text = key;
                                Hashtable failSet = (Hashtable)failTable[key];
                                var failSetKeys = failSet.Keys;
                                foreach (string automation in failSetKeys)
                                {
                                    TreeListNode node = new TreeListNode();
                                    ArrayList list = (ArrayList)failSet[automation];
                                    node.Text = automation;
                                    node.SubItems.Add(" ");
                                    string failureType = (string)list[0];
                                    if (failureType.Equals("Failure") == true)
                                    {
                                        node.SubItems.Add("\u2714");
                                        node.SubItems.Add(" ");
                                        node.SubItems.Add(" ");
                                        node.SubItems.Add((string)list[1]);
                                    }
                                    else if (failureType.Equals("AcceptedFailure") == true)
                                    {
                                        node.SubItems.Add(" ");
                                        node.SubItems.Add("\u2714");
                                        node.SubItems.Add(" ");
                                        node.SubItems.Add((string)list[1]);
                                        acceptedFailCount++;
                                    }
                                    else if (failureType.Equals("Bug") == true)
                                    {
                                        node.SubItems.Add(" ");
                                        node.SubItems.Add("");
                                        node.SubItems.Add("\u2714");
                                        node.SubItems.Add((string)list[1]);
                                        bugConfigCount++;
                                    }
                                    node.SubItems.Add((string)list[2]);
                                    node.Parent = project;
                                    project.Nodes.Add(node);
                                }
                                project.SubItems.Add(Convert.ToString(failSet.Count - acceptedFailCount - bugFailCount));
                                project.SubItems.Add(Convert.ToString(acceptedFailCount));
                                project.SubItems.Add(Convert.ToString(bugFailCount));
                                acceptedConfigCount += acceptedFailCount;
                                bugConfigCount += bugFailCount;
                                failConfigCount += failSet.Count;
                                configs.Nodes.Add(project);
                            }
                        }
                    }
                    configs.Text = configNames;
                    configs.SubItems.Add(Convert.ToString(successConfigCount));
                    configs.SubItems.Add(Convert.ToString(failConfigCount));
                    tln.Nodes.Add(configs);
                }

                var failConfigKey = failConfigTable.Keys;
                List<string> failConfigKeys = failConfigKey.Cast<string>().ToList();
                failConfigKeys.Sort();
                foreach (string configNames in failConfigKeys)
                {
                    int acceptedFailCount = 0;
                    int bugFailCount = 0;
                    TreeListNode failConfig = new TreeListNode();
                    TreeListNode project = new TreeListNode();
                    Hashtable table = (Hashtable)failConfigTable[configNames];
                    if (successConfigTable.ContainsKey(configNames) == false)
                    {
                        var keyTable = table.Keys;
                        List<string> keys = keyTable.Cast<string>().ToList();
                        keys.Sort();
                        foreach (string key in keys)
                        {
                            project.Text = key;
                            project.SubItems.Add("0");
                            project.SubItems.Add(Convert.ToString(table.Count));
                            Hashtable set = (Hashtable)table[key];
                            var setKeys = set.Keys;
                            foreach (string setKey in setKeys)
                            {
                                TreeListNode automation = new TreeListNode();
                                ArrayList list = (ArrayList)set[setKey];
                                automation.Text = setKey;
                                automation.SubItems.Add(" ");
                                string failureType = (string)list[0];
                                if (failureType.Equals("Failure") == true)
                                {
                                    automation.SubItems.Add("\u2714");
                                    automation.SubItems.Add(" ");
                                    automation.SubItems.Add(" ");
                                    automation.SubItems.Add((string)list[1]);
                                }
                                else if (failureType.Equals("AcceptedFailure") == true)
                                {
                                    automation.SubItems.Add(" ");
                                    automation.SubItems.Add("\u2714");
                                    automation.SubItems.Add(" ");
                                    automation.SubItems.Add((string)list[1]);
                                    acceptedFailCount++;
                                }
                                else if (failureType.Equals("Bug") == true)
                                {
                                    automation.SubItems.Add(" ");
                                    automation.SubItems.Add("");
                                    automation.SubItems.Add("\u2714");
                                    automation.SubItems.Add((string)list[1]);
                                    bugFailCount++;
                                }
                                automation.SubItems.Add((string)list[2]);
                                automation.Parent = project;
                                project.Nodes.Add(automation);
                            }
                            failConfig.Nodes.Add(project);
                        }
                        failConfig.Text = configNames;
                        failConfig.SubItems.Add("0");
                        failConfig.SubItems.Add(Convert.ToString(table.Count));
                        failConfig.SubItems.Add(Convert.ToString(acceptedFailCount));
                        failConfig.SubItems.Add(Convert.ToString(bugFailCount));
                        tln.Nodes.Add(failConfig);
                    }
                }
                treeListView1.Nodes.Add(tln);
            }
            treeListView1.Focus();
            label6.Text = "Done!";
        }

        private void treeListView1_MouseClick(object sender, MouseEventArgs e)
        {
            var selectedNodes = treeListView1.SelectedNodes;
            if (e.Button == MouseButtons.Right && selectedNodes.Count == 1)
            {
                foreach (TreeListNode node in selectedNodes)
                {
                    if (node.FirstChild() == null)
                        this.contextMenuStrip1.Show(this.treeListView1, e.Location);
                }
            }
        }

        private void failureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeListView1.SelectedNodes[0];
            if (node.SubItems.Count != 6)
            {
                MessageBox.Show("Please Select a Failure Node", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FailureHelper failureTracker = new FailureHelper(textBox1.Text, textBox5.Text, textBox2.Text,
                    GetSolutionName(), GetRuntimeVersion(), GetAutomationName(), "False", "Failure");
                failureTracker.ProcessFailure("Unknown");
                MessageBox.Show("Successfully marked as Failure!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void acceptedFailureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeListView1.SelectedNodes[0];
            if (node.SubItems.Count != 6)
            {
                MessageBox.Show("Please Select a Failure Node", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FailureHelper failureTracker = new FailureHelper(textBox1.Text, textBox5.Text, textBox2.Text, GetSolutionName(), GetRuntimeVersion(), GetAutomationName(), "False", "AcceptedFailure");
                AcceptedFailure acceptedFailureDialog = new AcceptedFailure(failureTracker);
                acceptedFailureDialog.Show();
                //acceptedFailureDialog.FormClosed += new EventHandler(AcceptedFailureDialog_Closed);
                node.SubItems[1].Text = " ";
                node.SubItems[2].Text = "\u2714";
                TreeListNode parent = (TreeListNode)node.ParentNode();
                parent.SubItems[2].Text = Convert.ToString(Convert.ToInt32(parent.SubItems[2].Text) + 1);
                treeListView1.Focus();
            }
        }

        private void AcceptedFailureDialog_Closed(object sender)
        {
        }

        private void bugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeListView1.SelectedNodes[0];
            //if it's a failure it will have 4 subitems (for now)
            if (node.SubItems.Count != 6)
            {
                MessageBox.Show("Please Select a Failure Node", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CRForm crform;
                FailureHelper failureTracker = new FailureHelper(textBox1.Text, textBox5.Text, textBox2.Text, GetSolutionName(), GetRuntimeVersion(), GetAutomationName(), "False", "Bug");
                crform = new CRForm(failureTracker);
                crform.Show();
                FillCrForm(crform);
            }
        }

        //make CR helper functions
        #region CrFunctions

        private string GetRuntimeVersion()
        {
            TreeListNode selectedNode = this.treeListView1.SelectedNodes[0];
            return selectedNode.SubItems[4].Text;
        }
        private string GetSolutionName()
        {
            TreeListNode selectedNode = this.treeListView1.SelectedNodes[0];
            TreeListNode node = (TreeListNode)selectedNode.ParentNode();
            return node.Text;
        }
        private string GetAutomationName()
        {
            TreeListNode selectedNode = this.treeListView1.SelectedNodes[0];
            return selectedNode.Text;
        }
        private string GetFailureMsg()
        {
            TreeListNode selectedNode = treeListView1.SelectedNodes[0];
            var subItem = selectedNode.SubItems[5];
            return subItem.Text;
        }
        private void FillCrForm(CRForm LogBugCRDialog)
        {
            string solution = GetSolutionName();
            char[] delimeters = { '_' };
            string[] text = solution.Split(delimeters);
            string platform = text[0];
            LogBugCRDialog.NameTxtBox.Text = solution + " " + GetAutomationName();
            LogBugCRDialog.NAStxtBox.Text = @"\\10.0.1.23\Dev_QA\Automated Tests\Tests\" +
                platform + @"\" + solution + "_Debug.OpenSpan";
            LogBugCRDialog.richTextBox1.Text = GetFailureMsg();
        }
        #endregion

        private void seeStatusMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FailureHelper failureTracker = new FailureHelper(textBox1.Text, textBox5.Text, textBox2.Text, GetSolutionName(), GetRuntimeVersion(), GetAutomationName(), "False", "Bug");
            string msg = failureTracker.GetStatusMsg(GetSolutionName(), GetRuntimeVersion(), GetAutomationName());
            DialogResult result = MessageBox.Show(msg, "Do you want to copy the message?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Clipboard.SetText(msg);
            }
        }
    }
}
