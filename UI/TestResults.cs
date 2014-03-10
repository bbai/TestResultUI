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
        public TestResults()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "10.0.3.26";
            textBox2.Text = "UnitTestDB";
            textBox3.Text = "UnitTestResults";
            textBox5.Text = "27017";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Days.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (treeListView1.Columns.Count != 5)
                {
                    treeListView1.Columns.Clear();
                    ToggleColumnHeader tch = new ToggleColumnHeader();
                    tch.Text = "Title";
                    treeListView1.Columns.Add(tch);
                    tch = new ToggleColumnHeader();
                    tch.Text = "Success";
                    treeListView1.Columns.Add(tch);
                    tch = new ToggleColumnHeader();
                    tch.Text = "Fail";
                    treeListView1.Columns.Add(tch);
                    tch = new ToggleColumnHeader();
                    tch.Text = "Last Runtime Version";
                    treeListView1.Columns.Add(tch);
                    tch = new ToggleColumnHeader();
                    tch.Text = "Failure Message";
                    treeListView1.Columns.Add(tch);
                }
                TreeListNode tln = new TreeListNode();
                tln.Text = "Test Run";
                tln.ImageIndex = 1;
                tln.SubItems.Add(Convert.ToString(results[0] - results[1]));
                tln.SubItems.Add(Convert.ToString(results[1]));
                TreeListNode allConfig = new TreeListNode();

                if (mongo.AnalyzeData() == true)
                {
                    successAllConfigTable = mongo.successAllConfigTable;
                    failAllConfigTable = mongo.failAllConfigTable;
                    var successKeys = successAllConfigTable.Keys;
                    var failKeys = failAllConfigTable.Keys;
                    int totalSuccessAllConfigCount = 0;
                    int totalFailAllConfigCount = 0;
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
                            automation.SubItems.Add((string)list[0]);
                            project.Nodes.Add(automation);
                        }

                        int successCount = table.Count;
                        totalSuccessAllConfigCount += successCount;


                        if (failAllConfigTable.ContainsKey(projectName) == true)
                        {
                            Hashtable failTable = (Hashtable)failAllConfigTable[projectName];
                            var failTableKeys = failTable.Keys;
                            foreach (string key in failTableKeys)
                            {
                                TreeListNode automation = new TreeListNode();
                                ArrayList list = (ArrayList)failTable[key];
                                automation.Text = key;
                                automation.SubItems.Add(" ");
                                automation.SubItems.Add("\u2714");
                                automation.SubItems.Add((string)list[0]);
                                automation.SubItems.Add((string)list[1]);
                                project.Nodes.Add(automation);
                            }
                            totalFailAllConfigCount += failTable.Count;
                            project.SubItems.Add(Convert.ToString(successCount));
                            project.SubItems.Add(Convert.ToString(failTable.Count));
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
                                automation.SubItems.Add("\u2714");
                                automation.SubItems.Add((string)list[0]);
                                automation.SubItems.Add((string)list[1]);
                                project.Nodes.Add(automation);
                            }
                            project.Text = projectName;
                            project.SubItems.Add("0");
                            project.SubItems.Add(Convert.ToString(failCount));
                            allConfig.Nodes.Add(project);
                        }
                    }
                    allConfig.SubItems.Add(Convert.ToString(totalSuccessAllConfigCount));
                    allConfig.SubItems.Add(Convert.ToString(totalFailAllConfigCount));
                    tln.Nodes.Add(allConfig);

                    successConfigTable = mongo.successConfigTable;
                    failConfigTable = mongo.failConfigTable;
                    var successConfigKeys = successConfigTable.Keys;


                    foreach (string configNames in successConfigKeys)
                    {
                        int successConfigCount = 0;
                        int failConfigCount = 0;
                        TreeListNode configs = new TreeListNode();
                        Hashtable table = (Hashtable)successConfigTable[configNames];
                        Hashtable failTable = (Hashtable)failConfigTable[configNames];
                        var keys = table.Keys;
                        foreach (string key in keys)
                        {
                            TreeListNode project = new TreeListNode();
                            project.Text = key;
                            Hashtable successTable = (Hashtable)table[key];
                            var tableKeys = successTable.Keys;
                            Hashtable failSetTable = (Hashtable)failTable[key];
                            var failSetTalbekeys = failSetTable.Keys;
                            foreach (string automation in tableKeys)
                            {
                                TreeListNode node = new TreeListNode();
                                ArrayList list = (ArrayList)successTable[automation];
                                node.Text = automation;
                                node.SubItems.Add("\u2714");
                                node.SubItems.Add(" ");
                                node.SubItems.Add((string)list[0]);
                                project.Nodes.Add(node);
                            }

                            if (failConfigTable.ContainsKey(configNames) == true)
                            {
                                if (failSetTable != null && failSetTable.Count > 0)
                                {
                                    foreach (string automation in failSetTalbekeys)
                                    {
                                        TreeListNode node = new TreeListNode();
                                        ArrayList list = (ArrayList)failSetTable[automation];
                                        node.Text = automation;
                                        node.SubItems.Add(" ");
                                        node.SubItems.Add("\u2714");
                                        node.SubItems.Add((string)list[0]);
                                        node.SubItems.Add((string)list[1]);
                                        project.Nodes.Add(node);
                                    }
                                }
                            }
                            project.SubItems.Add(Convert.ToString(successTable.Count));
                            successConfigCount += successTable.Count;
                            if (failSetTable != null)
                            {
                                project.SubItems.Add(Convert.ToString(failSetTable.Count));
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
                            var failConfKeys = failTable.Keys;
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
                                        node.SubItems.Add("\u2714");
                                        node.SubItems.Add((string)list[0]);
                                        node.SubItems.Add((string)list[1]);
                                        project.Nodes.Add(node);
                                    }
                                    project.SubItems.Add(Convert.ToString(failSet.Count));
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

                    var failConfigKeys = failConfigTable.Keys;
                    foreach (string configNames in failConfigKeys)
                    {
                        TreeListNode failConfig = new TreeListNode();
                        TreeListNode project = new TreeListNode();
                        Hashtable table = (Hashtable)failConfigTable[configNames];
                        if (successConfigTable.ContainsKey(configNames) == false)
                        {
                            var keys = table.Keys;
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
                                    automation.Text = key;
                                    automation.SubItems.Add(" ");
                                    automation.SubItems.Add("\u2714");
                                    automation.SubItems.Add((string)list[0]);
                                    automation.SubItems.Add((string)list[1]);
                                    project.Nodes.Add(automation);
                                }
                            }
                            failConfig.Text = configNames;
                            failConfig.SubItems.Add("0");
                            failConfig.SubItems.Add(Convert.ToString(table.Count));
                            tln.Nodes.Add(failConfig);
                        }
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
            if (node.SubItems.Count != 4)
            {
                MessageBox.Show("Please Select a Failure Node", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Marked as Failure Success!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void acceptedFailureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeListView1.SelectedNodes[0];
            if (node.SubItems.Count != 4)
            {
                MessageBox.Show("Please Select a Failure Node", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AcceptedFailure acceptedFailureDialog = new AcceptedFailure(textBox1.Text, textBox5.Text, textBox2.Text, GetSolutionName(node), node.SubItems[2].Text, GetAutomationName(node));
                acceptedFailureDialog.Show();
            }
        }

        private void bugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeListView1.SelectedNodes[0];
            if (node.SubItems.Count != 4)
            {
                MessageBox.Show("Please Select a Failure Node", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
            }
        }

        private string GetSolutionName(TreeListNode selectedNode)
        {
            TreeListNode node = (TreeListNode)selectedNode.ParentNode();
            return node.Text;
        }

        private string GetAutomationName(TreeListNode selectedNode)
        {
            return selectedNode.Text;
        }
    }
}
