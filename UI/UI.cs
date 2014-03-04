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

namespace UI
{
    public partial class UI : Form
    {
        MongoDBHelper mongo;
        string days;
        public UI()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "mongodb://10.0.3.26:27017/";
            textBox2.Text = "UnitTestDB";
            textBox3.Text = "UnitTestResults";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Days.", "Error");
            }
            else
            {
                if (mongo == null || days != textBox4.Text)
                {
                    days = textBox4.Text;
                    treeListView1.Nodes.Clear();
                    mongo = new MongoDBHelper(textBox1.Text, textBox2.Text,
                            textBox3.Text, Convert.ToInt32(textBox4.Text));
                    int[] results = mongo.GetNumTotalAndFail();
                    if (treeListView1.Columns.Count != 3)
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
                    }
                    TreeListNode tln = new TreeListNode();
                    tln.Text = "Test Run";
                    tln.ImageIndex = 1;
                    tln.SubItems.Add(Convert.ToString(results[0] - results[1]));
                    tln.SubItems.Add(Convert.ToString(results[1]));
                    TreeListNode allConfig = new TreeListNode();
                    
                    if (mongo.AnalyzeData() == true)
                    {
                        Hashtable successAllConfigTable = mongo.successAllConfigTable;
                        Hashtable failAllConfigTable = mongo.failAllConfigTable;
                        var successKeys = successAllConfigTable.Keys;
                        var failKeys = failAllConfigTable.Keys;
                        int totalSuccessAllConfigCount = 0;
                        int totalFailAllConfigCount = 0;
                        foreach (string projectName in successKeys)
                        {
                            TreeListNode project = new TreeListNode();
                            project.Text = projectName;
                            ArrayList list = (ArrayList)successAllConfigTable[projectName];
                            
                            foreach (string listItem in list)
                            {
                                TreeListNode automation = new TreeListNode();
                                automation.Text = listItem;
                                automation.SubItems.Add("\u2714");
                                project.Nodes.Add(automation);
                            }

                            int successCount = list.Count;
                            totalSuccessAllConfigCount += successCount;


                            if (failAllConfigTable.ContainsKey(projectName) == true)
                            {
                                ArrayList failList = (ArrayList)failAllConfigTable[projectName];
                                foreach (string listItem in failList)
                                {
                                    TreeListNode automation = new TreeListNode();
                                    automation.Text = listItem;
                                    automation.SubItems.Add(" ");
                                    automation.SubItems.Add("\u2714");
                                    project.Nodes.Add(automation);
                                }
                                totalFailAllConfigCount += failList.Count;
                                project.SubItems.Add(Convert.ToString(successCount));
                                project.SubItems.Add(Convert.ToString(failList.Count));
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
                                ArrayList list = (ArrayList)failAllConfigTable[projectName];
                                int failCount = list.Count;
                                totalFailAllConfigCount += failCount;
                                var nodes = allConfig.Nodes;
                                TreeListNode project = new TreeListNode();
                                foreach (string listItem in list)
                                {
                                    TreeListNode automation = new TreeListNode();
                                    automation.Text = listItem;
                                    automation.SubItems.Add(" ");
                                    automation.SubItems.Add("\u2714");
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

                        Hashtable successConfigTable = mongo.successConfigTable;
                        Hashtable failConfigTable = mongo.failConfigTable;
                        var successConfigKeys = successConfigTable.Keys;


                        foreach (string configNames in successConfigKeys)
                        {
                            int successConfigCount = 0;
                            int failConfigCount = 0;
                            TreeListNode configs = new TreeListNode();
                            Hashtable table = (Hashtable)successConfigTable[configNames];
                            Hashtable failTable = (Hashtable) failConfigTable[configNames];
                            var keys = table.Keys;
                            foreach (string key in keys)
                            {
                                TreeListNode project = new TreeListNode();
                                project.Text = key;
                                HashSet<string> set = (HashSet<string>)table[key];
                                HashSet<string> failSet = (HashSet<string>)failTable[key];
                                foreach (string setItem in set)
                                {
                                    TreeListNode node = new TreeListNode();
                                    node.Text = setItem;
                                    node.SubItems.Add("\u2714");
                                    project.Nodes.Add(node);
                                }

                                if (failConfigTable.ContainsKey(configNames) == true)
                                {
                                    if (failSet != null && failSet.Count > 0)
                                    {
                                        foreach (string setItem in failSet)
                                        {
                                            TreeListNode node = new TreeListNode();
                                            node.Text = setItem;
                                            node.SubItems.Add(" ");
                                            node.SubItems.Add("\u2714");
                                            project.Nodes.Add(node);
                                        }
                                    }
                                }
                                project.SubItems.Add(Convert.ToString(set.Count));
                                successConfigCount += set.Count;
                                if (failSet != null)
                                {
                                    project.SubItems.Add(Convert.ToString(failSet.Count));
                                    failConfigCount += failSet.Count;
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
                                        HashSet<string> failSet = (HashSet<string>)failTable[key];
                                        foreach (string setItem in failSet)
                                        {
                                            TreeListNode node = new TreeListNode();
                                            node.Text = setItem;
                                            node.SubItems.Add(" ");
                                            node.SubItems.Add("\u2714");
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
                                    HashSet<string> set = (HashSet<string>) table[key];
                                    foreach (string setItem in set)
                                    {
                                        TreeListNode automation = new TreeListNode();
                                        automation.Text = setItem;
                                        automation.SubItems.Add(" ");
                                        automation.SubItems.Add("\u2714");
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
            }
            treeListView1.Focus();
        }
    }
}
