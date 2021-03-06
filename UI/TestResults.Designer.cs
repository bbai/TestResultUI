﻿namespace UI
{
    partial class TestResults
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            TPsettings.Reset();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestResults));
            this.DbLoginGroupBox = new System.Windows.Forms.GroupBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.PortTxt = new System.Windows.Forms.TextBox();
            this.PortLbl = new System.Windows.Forms.Label();
            this.DefaultBtn = new System.Windows.Forms.Button();
            this.ReadyLbl = new System.Windows.Forms.Label();
            this.CollectionNameTxt = new System.Windows.Forms.TextBox();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.CollectionNameLbl = new System.Windows.Forms.Label();
            this.DbNameLbl = new System.Windows.Forms.Label();
            this.DbNameTxt = new System.Windows.Forms.TextBox();
            this.DbAddressTxt = new System.Windows.Forms.TextBox();
            this.DbAddressLbl = new System.Windows.Forms.Label();
            this.GetDataByDaysBtn = new System.Windows.Forms.Button();
            this.DaysTxt = new System.Windows.Forms.TextBox();
            this.DaysLbl = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.failureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acceptedFailureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seeStatusMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeListView1 = new SynapticEffect.Forms.TreeListView();
            this.SelectDataGroupBox = new System.Windows.Forms.GroupBox();
            this.GetTestRunBtn = new System.Windows.Forms.Button();
            this.TestRunLbl = new System.Windows.Forms.Label();
            this.TestRunComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ViewResultsTab = new System.Windows.Forms.TabPage();
            this.CompareResultsTab = new System.Windows.Forms.TabPage();
            this.EmailLbl = new System.Windows.Forms.Label();
            this.EmailMsgTxt = new System.Windows.Forms.RichTextBox();
            this.compareTreeListView = new SynapticEffect.Forms.TreeListView();
            this.ComparePickGroupBox = new System.Windows.Forms.GroupBox();
            this.CompareSubmitBtn = new System.Windows.Forms.Button();
            this.CompareTestComboBox = new System.Windows.Forms.ComboBox();
            this.TestLbl = new System.Windows.Forms.Label();
            this.BaseLbl = new System.Windows.Forms.Label();
            this.BaseComboBox = new System.Windows.Forms.ComboBox();
            this.DbLoginGroupBox.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SelectDataGroupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.ViewResultsTab.SuspendLayout();
            this.CompareResultsTab.SuspendLayout();
            this.ComparePickGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DbLoginGroupBox
            // 
            this.DbLoginGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DbLoginGroupBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DbLoginGroupBox.Controls.Add(this.ConnectBtn);
            this.DbLoginGroupBox.Controls.Add(this.PortTxt);
            this.DbLoginGroupBox.Controls.Add(this.PortLbl);
            this.DbLoginGroupBox.Controls.Add(this.DefaultBtn);
            this.DbLoginGroupBox.Controls.Add(this.ReadyLbl);
            this.DbLoginGroupBox.Controls.Add(this.CollectionNameTxt);
            this.DbLoginGroupBox.Controls.Add(this.StatusLbl);
            this.DbLoginGroupBox.Controls.Add(this.CollectionNameLbl);
            this.DbLoginGroupBox.Controls.Add(this.DbNameLbl);
            this.DbLoginGroupBox.Controls.Add(this.DbNameTxt);
            this.DbLoginGroupBox.Controls.Add(this.DbAddressTxt);
            this.DbLoginGroupBox.Controls.Add(this.DbAddressLbl);
            this.DbLoginGroupBox.Location = new System.Drawing.Point(11, 12);
            this.DbLoginGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DbLoginGroupBox.Name = "DbLoginGroupBox";
            this.DbLoginGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DbLoginGroupBox.Size = new System.Drawing.Size(1406, 88);
            this.DbLoginGroupBox.TabIndex = 10;
            this.DbLoginGroupBox.TabStop = false;
            this.DbLoginGroupBox.Text = "Database Login";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(1059, 50);
            this.ConnectBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(84, 31);
            this.ConnectBtn.TabIndex = 5;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // PortTxt
            // 
            this.PortTxt.Location = new System.Drawing.Point(289, 34);
            this.PortTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PortTxt.Name = "PortTxt";
            this.PortTxt.Size = new System.Drawing.Size(77, 26);
            this.PortTxt.TabIndex = 2;
            // 
            // PortLbl
            // 
            this.PortLbl.AutoSize = true;
            this.PortLbl.Location = new System.Drawing.Point(242, 40);
            this.PortLbl.Name = "PortLbl";
            this.PortLbl.Size = new System.Drawing.Size(42, 20);
            this.PortLbl.TabIndex = 11;
            this.PortLbl.Text = "Port:";
            // 
            // DefaultBtn
            // 
            this.DefaultBtn.Location = new System.Drawing.Point(1059, 12);
            this.DefaultBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DefaultBtn.Name = "DefaultBtn";
            this.DefaultBtn.Size = new System.Drawing.Size(84, 31);
            this.DefaultBtn.TabIndex = 0;
            this.DefaultBtn.Text = "Default";
            this.DefaultBtn.UseVisualStyleBackColor = true;
            this.DefaultBtn.Click += new System.EventHandler(this.DefaultBtn_Click);
            // 
            // ReadyLbl
            // 
            this.ReadyLbl.AutoSize = true;
            this.ReadyLbl.Location = new System.Drawing.Point(1223, 35);
            this.ReadyLbl.Name = "ReadyLbl";
            this.ReadyLbl.Size = new System.Drawing.Size(55, 20);
            this.ReadyLbl.TabIndex = 12;
            this.ReadyLbl.Text = "Ready";
            // 
            // CollectionNameTxt
            // 
            this.CollectionNameTxt.Location = new System.Drawing.Point(794, 32);
            this.CollectionNameTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CollectionNameTxt.Name = "CollectionNameTxt";
            this.CollectionNameTxt.Size = new System.Drawing.Size(242, 26);
            this.CollectionNameTxt.TabIndex = 4;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Location = new System.Drawing.Point(1167, 35);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(60, 20);
            this.StatusLbl.TabIndex = 13;
            this.StatusLbl.Text = "Status:";
            // 
            // CollectionNameLbl
            // 
            this.CollectionNameLbl.AutoSize = true;
            this.CollectionNameLbl.Location = new System.Drawing.Point(647, 36);
            this.CollectionNameLbl.Name = "CollectionNameLbl";
            this.CollectionNameLbl.Size = new System.Drawing.Size(128, 20);
            this.CollectionNameLbl.TabIndex = 14;
            this.CollectionNameLbl.Text = "Collection Name:";
            // 
            // DbNameLbl
            // 
            this.DbNameLbl.AutoSize = true;
            this.DbNameLbl.Location = new System.Drawing.Point(389, 39);
            this.DbNameLbl.Name = "DbNameLbl";
            this.DbNameLbl.Size = new System.Drawing.Size(82, 20);
            this.DbNameLbl.TabIndex = 15;
            this.DbNameLbl.Text = "DB Name:";
            // 
            // DbNameTxt
            // 
            this.DbNameTxt.Location = new System.Drawing.Point(477, 34);
            this.DbNameTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DbNameTxt.Name = "DbNameTxt";
            this.DbNameTxt.Size = new System.Drawing.Size(149, 26);
            this.DbNameTxt.TabIndex = 3;
            // 
            // DbAddressTxt
            // 
            this.DbAddressTxt.Location = new System.Drawing.Point(114, 35);
            this.DbAddressTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DbAddressTxt.Name = "DbAddressTxt";
            this.DbAddressTxt.Size = new System.Drawing.Size(110, 26);
            this.DbAddressTxt.TabIndex = 1;
            // 
            // DbAddressLbl
            // 
            this.DbAddressLbl.AutoSize = true;
            this.DbAddressLbl.Location = new System.Drawing.Point(9, 40);
            this.DbAddressLbl.Name = "DbAddressLbl";
            this.DbAddressLbl.Size = new System.Drawing.Size(99, 20);
            this.DbAddressLbl.TabIndex = 16;
            this.DbAddressLbl.Text = "DB Address:";
            // 
            // GetDataByDaysBtn
            // 
            this.GetDataByDaysBtn.Enabled = false;
            this.GetDataByDaysBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetDataByDaysBtn.Location = new System.Drawing.Point(1260, 29);
            this.GetDataByDaysBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GetDataByDaysBtn.Name = "GetDataByDaysBtn";
            this.GetDataByDaysBtn.Size = new System.Drawing.Size(90, 31);
            this.GetDataByDaysBtn.TabIndex = 9;
            this.GetDataByDaysBtn.Text = "Get Data";
            this.GetDataByDaysBtn.UseVisualStyleBackColor = true;
            this.GetDataByDaysBtn.Click += new System.EventHandler(this.GetDataByDaysBtn_Click);
            // 
            // DaysTxt
            // 
            this.DaysTxt.Location = new System.Drawing.Point(1151, 34);
            this.DaysTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DaysTxt.Name = "DaysTxt";
            this.DaysTxt.Size = new System.Drawing.Size(72, 28);
            this.DaysTxt.TabIndex = 8;
            // 
            // DaysLbl
            // 
            this.DaysLbl.AutoSize = true;
            this.DaysLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DaysLbl.Location = new System.Drawing.Point(1077, 38);
            this.DaysLbl.Name = "DaysLbl";
            this.DaysLbl.Size = new System.Drawing.Size(56, 22);
            this.DaysLbl.TabIndex = 17;
            this.DaysLbl.Text = "Days:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failureToolStripMenuItem,
            this.acceptedFailureToolStripMenuItem,
            this.bugToolStripMenuItem,
            this.seeStatusMessageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(294, 124);
            // 
            // failureToolStripMenuItem
            // 
            this.failureToolStripMenuItem.Name = "failureToolStripMenuItem";
            this.failureToolStripMenuItem.Size = new System.Drawing.Size(293, 30);
            this.failureToolStripMenuItem.Text = "Mark as Failure";
            this.failureToolStripMenuItem.Click += new System.EventHandler(this.failureToolStripMenuItem_Click);
            // 
            // acceptedFailureToolStripMenuItem
            // 
            this.acceptedFailureToolStripMenuItem.Name = "acceptedFailureToolStripMenuItem";
            this.acceptedFailureToolStripMenuItem.Size = new System.Drawing.Size(293, 30);
            this.acceptedFailureToolStripMenuItem.Text = "Mark as Accepted Failure...";
            this.acceptedFailureToolStripMenuItem.Click += new System.EventHandler(this.acceptedFailureToolStripMenuItem_Click);
            // 
            // bugToolStripMenuItem
            // 
            this.bugToolStripMenuItem.Name = "bugToolStripMenuItem";
            this.bugToolStripMenuItem.Size = new System.Drawing.Size(293, 30);
            this.bugToolStripMenuItem.Text = "Mark as Bug...";
            this.bugToolStripMenuItem.Click += new System.EventHandler(this.bugToolStripMenuItem_Click);
            // 
            // seeStatusMessageToolStripMenuItem
            // 
            this.seeStatusMessageToolStripMenuItem.Name = "seeStatusMessageToolStripMenuItem";
            this.seeStatusMessageToolStripMenuItem.Size = new System.Drawing.Size(293, 30);
            this.seeStatusMessageToolStripMenuItem.Text = "See Status Message";
            this.seeStatusMessageToolStripMenuItem.Click += new System.EventHandler(this.seeStatusMessageToolStripMenuItem_Click);
            // 
            // treeListView1
            // 
            this.treeListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.treeListView1.ColumnSortColor = System.Drawing.Color.Gainsboro;
            this.treeListView1.ColumnTrackColor = System.Drawing.Color.WhiteSmoke;
            this.treeListView1.GridLineColor = System.Drawing.Color.WhiteSmoke;
            this.treeListView1.HeaderMenu = null;
            this.treeListView1.ItemHeight = 20;
            this.treeListView1.ItemMenu = null;
            this.treeListView1.LabelEdit = false;
            this.treeListView1.Location = new System.Drawing.Point(0, 94);
            this.treeListView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.RowSelectColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(144)))), ((int)(((byte)(24)))));
            this.treeListView1.RowTrackColor = System.Drawing.Color.Empty;
            this.treeListView1.Size = new System.Drawing.Size(1398, 726);
            this.treeListView1.SmallImageList = null;
            this.treeListView1.StateImageList = null;
            this.treeListView1.TabIndex = 18;
            this.treeListView1.Text = "treeListView1";
            this.treeListView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeListView1_MouseClick);
            // 
            // SelectDataGroupBox
            // 
            this.SelectDataGroupBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SelectDataGroupBox.Controls.Add(this.GetTestRunBtn);
            this.SelectDataGroupBox.Controls.Add(this.TestRunLbl);
            this.SelectDataGroupBox.Controls.Add(this.TestRunComboBox);
            this.SelectDataGroupBox.Controls.Add(this.DaysTxt);
            this.SelectDataGroupBox.Controls.Add(this.DaysLbl);
            this.SelectDataGroupBox.Controls.Add(this.GetDataByDaysBtn);
            this.SelectDataGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectDataGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(144)))), ((int)(((byte)(24)))));
            this.SelectDataGroupBox.Location = new System.Drawing.Point(0, 0);
            this.SelectDataGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SelectDataGroupBox.Name = "SelectDataGroupBox";
            this.SelectDataGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SelectDataGroupBox.Size = new System.Drawing.Size(1398, 81);
            this.SelectDataGroupBox.TabIndex = 19;
            this.SelectDataGroupBox.TabStop = false;
            this.SelectDataGroupBox.Text = "Choose Run or Date Range";
            // 
            // GetTestRunBtn
            // 
            this.GetTestRunBtn.Enabled = false;
            this.GetTestRunBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetTestRunBtn.Location = new System.Drawing.Point(898, 31);
            this.GetTestRunBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GetTestRunBtn.Name = "GetTestRunBtn";
            this.GetTestRunBtn.Size = new System.Drawing.Size(90, 31);
            this.GetTestRunBtn.TabIndex = 7;
            this.GetTestRunBtn.Text = "Get Data";
            this.GetTestRunBtn.UseVisualStyleBackColor = true;
            this.GetTestRunBtn.Click += new System.EventHandler(this.GetTestRunBtn_Click);
            // 
            // TestRunLbl
            // 
            this.TestRunLbl.AutoSize = true;
            this.TestRunLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestRunLbl.Location = new System.Drawing.Point(9, 36);
            this.TestRunLbl.Name = "TestRunLbl";
            this.TestRunLbl.Size = new System.Drawing.Size(89, 22);
            this.TestRunLbl.TabIndex = 20;
            this.TestRunLbl.Text = "Test Run:";
            // 
            // TestRunComboBox
            // 
            this.TestRunComboBox.FormattingEnabled = true;
            this.TestRunComboBox.Location = new System.Drawing.Point(114, 32);
            this.TestRunComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TestRunComboBox.Name = "TestRunComboBox";
            this.TestRunComboBox.Size = new System.Drawing.Size(754, 30);
            this.TestRunComboBox.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ViewResultsTab);
            this.tabControl1.Controls.Add(this.CompareResultsTab);
            this.tabControl1.Location = new System.Drawing.Point(11, 112);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1406, 856);
            this.tabControl1.TabIndex = 21;
            // 
            // ViewResultsTab
            // 
            this.ViewResultsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(144)))), ((int)(((byte)(24)))));
            this.ViewResultsTab.Controls.Add(this.SelectDataGroupBox);
            this.ViewResultsTab.Controls.Add(this.treeListView1);
            this.ViewResultsTab.Location = new System.Drawing.Point(4, 29);
            this.ViewResultsTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ViewResultsTab.Name = "ViewResultsTab";
            this.ViewResultsTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ViewResultsTab.Size = new System.Drawing.Size(1398, 823);
            this.ViewResultsTab.TabIndex = 0;
            this.ViewResultsTab.Text = "View Test Results";
            // 
            // CompareResultsTab
            // 
            this.CompareResultsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(144)))), ((int)(((byte)(24)))));
            this.CompareResultsTab.Controls.Add(this.EmailLbl);
            this.CompareResultsTab.Controls.Add(this.EmailMsgTxt);
            this.CompareResultsTab.Controls.Add(this.compareTreeListView);
            this.CompareResultsTab.Controls.Add(this.ComparePickGroupBox);
            this.CompareResultsTab.Location = new System.Drawing.Point(4, 29);
            this.CompareResultsTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CompareResultsTab.Name = "CompareResultsTab";
            this.CompareResultsTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CompareResultsTab.Size = new System.Drawing.Size(1398, 823);
            this.CompareResultsTab.TabIndex = 1;
            this.CompareResultsTab.Text = "Compare Test Results";
            // 
            // EmailLbl
            // 
            this.EmailLbl.AutoSize = true;
            this.EmailLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.EmailLbl.Location = new System.Drawing.Point(1, 495);
            this.EmailLbl.Name = "EmailLbl";
            this.EmailLbl.Size = new System.Drawing.Size(133, 22);
            this.EmailLbl.TabIndex = 21;
            this.EmailLbl.Text = "Emailed Report";
            // 
            // EmailMsgTxt
            // 
            this.EmailMsgTxt.Location = new System.Drawing.Point(0, 520);
            this.EmailMsgTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EmailMsgTxt.Name = "EmailMsgTxt";
            this.EmailMsgTxt.ReadOnly = true;
            this.EmailMsgTxt.Size = new System.Drawing.Size(1401, 299);
            this.EmailMsgTxt.TabIndex = 20;
            this.EmailMsgTxt.Text = "";
            // 
            // compareTreeListView
            // 
            this.compareTreeListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.compareTreeListView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.compareTreeListView.ColumnSortColor = System.Drawing.Color.Gainsboro;
            this.compareTreeListView.ColumnTrackColor = System.Drawing.Color.WhiteSmoke;
            this.compareTreeListView.GridLineColor = System.Drawing.Color.WhiteSmoke;
            this.compareTreeListView.HeaderMenu = null;
            this.compareTreeListView.ItemHeight = 20;
            this.compareTreeListView.ItemMenu = null;
            this.compareTreeListView.LabelEdit = false;
            this.compareTreeListView.Location = new System.Drawing.Point(0, 112);
            this.compareTreeListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.compareTreeListView.Name = "compareTreeListView";
            this.compareTreeListView.RowSelectColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(144)))), ((int)(((byte)(24)))));
            this.compareTreeListView.RowTrackColor = System.Drawing.Color.Empty;
            this.compareTreeListView.Size = new System.Drawing.Size(1398, 375);
            this.compareTreeListView.SmallImageList = null;
            this.compareTreeListView.StateImageList = null;
            this.compareTreeListView.TabIndex = 19;
            this.compareTreeListView.Text = "treeListView2";
            // 
            // ComparePickGroupBox
            // 
            this.ComparePickGroupBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ComparePickGroupBox.Controls.Add(this.CompareSubmitBtn);
            this.ComparePickGroupBox.Controls.Add(this.CompareTestComboBox);
            this.ComparePickGroupBox.Controls.Add(this.TestLbl);
            this.ComparePickGroupBox.Controls.Add(this.BaseLbl);
            this.ComparePickGroupBox.Controls.Add(this.BaseComboBox);
            this.ComparePickGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComparePickGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(144)))), ((int)(((byte)(24)))));
            this.ComparePickGroupBox.Location = new System.Drawing.Point(0, 0);
            this.ComparePickGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComparePickGroupBox.Name = "ComparePickGroupBox";
            this.ComparePickGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComparePickGroupBox.Size = new System.Drawing.Size(1397, 100);
            this.ComparePickGroupBox.TabIndex = 0;
            this.ComparePickGroupBox.TabStop = false;
            this.ComparePickGroupBox.Text = "Choose Base and Test Run";
            // 
            // CompareSubmitBtn
            // 
            this.CompareSubmitBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CompareSubmitBtn.Enabled = false;
            this.CompareSubmitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompareSubmitBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(144)))), ((int)(((byte)(24)))));
            this.CompareSubmitBtn.Location = new System.Drawing.Point(1252, 41);
            this.CompareSubmitBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CompareSubmitBtn.Name = "CompareSubmitBtn";
            this.CompareSubmitBtn.Size = new System.Drawing.Size(84, 31);
            this.CompareSubmitBtn.TabIndex = 4;
            this.CompareSubmitBtn.Text = "Get Data";
            this.CompareSubmitBtn.UseVisualStyleBackColor = false;
            this.CompareSubmitBtn.Click += new System.EventHandler(this.CompareSubmitBtn_Click);
            // 
            // CompareTestComboBox
            // 
            this.CompareTestComboBox.FormattingEnabled = true;
            this.CompareTestComboBox.Location = new System.Drawing.Point(723, 41);
            this.CompareTestComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CompareTestComboBox.Name = "CompareTestComboBox";
            this.CompareTestComboBox.Size = new System.Drawing.Size(489, 30);
            this.CompareTestComboBox.TabIndex = 3;
            // 
            // TestLbl
            // 
            this.TestLbl.AutoSize = true;
            this.TestLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestLbl.Location = new System.Drawing.Point(632, 45);
            this.TestLbl.Name = "TestLbl";
            this.TestLbl.Size = new System.Drawing.Size(89, 22);
            this.TestLbl.TabIndex = 2;
            this.TestLbl.Text = "Test Run:";
            // 
            // BaseLbl
            // 
            this.BaseLbl.AutoSize = true;
            this.BaseLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseLbl.Location = new System.Drawing.Point(7, 45);
            this.BaseLbl.Name = "BaseLbl";
            this.BaseLbl.Size = new System.Drawing.Size(94, 22);
            this.BaseLbl.TabIndex = 1;
            this.BaseLbl.Text = "Base Run:";
            // 
            // BaseComboBox
            // 
            this.BaseComboBox.FormattingEnabled = true;
            this.BaseComboBox.Location = new System.Drawing.Point(100, 41);
            this.BaseComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BaseComboBox.Name = "BaseComboBox";
            this.BaseComboBox.Size = new System.Drawing.Size(489, 30);
            this.BaseComboBox.TabIndex = 0;
            // 
            // TestResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(144)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1431, 981);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.DbLoginGroupBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TestResults";
            this.Text = "Test Results";
            this.DbLoginGroupBox.ResumeLayout(false);
            this.DbLoginGroupBox.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.SelectDataGroupBox.ResumeLayout(false);
            this.SelectDataGroupBox.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ViewResultsTab.ResumeLayout(false);
            this.CompareResultsTab.ResumeLayout(false);
            this.CompareResultsTab.PerformLayout();
            this.ComparePickGroupBox.ResumeLayout(false);
            this.ComparePickGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DbLoginGroupBox;
        private System.Windows.Forms.Button GetDataByDaysBtn;
        private System.Windows.Forms.TextBox CollectionNameTxt;
        private System.Windows.Forms.TextBox DaysTxt;
        private System.Windows.Forms.Label DaysLbl;
        private System.Windows.Forms.Label DbNameLbl;
        private System.Windows.Forms.TextBox DbNameTxt;
        private System.Windows.Forms.TextBox DbAddressTxt;
        private System.Windows.Forms.Label DbAddressLbl;
        private System.Windows.Forms.Label StatusLbl;
        private System.Windows.Forms.Button DefaultBtn;
        private SynapticEffect.Forms.TreeListView treeListView1;
        private System.Windows.Forms.Label ReadyLbl;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox PortTxt;
        private System.Windows.Forms.Label PortLbl;
        private System.Windows.Forms.Label CollectionNameLbl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acceptedFailureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seeStatusMessageToolStripMenuItem;
		  private System.Windows.Forms.GroupBox SelectDataGroupBox;
		  private System.Windows.Forms.Button ConnectBtn;
		  private System.Windows.Forms.Button GetTestRunBtn;
		  private System.Windows.Forms.Label TestRunLbl;
		  private System.Windows.Forms.ComboBox TestRunComboBox;
		  private System.Windows.Forms.TabControl tabControl1;
		  private System.Windows.Forms.TabPage ViewResultsTab;
		  private System.Windows.Forms.TabPage CompareResultsTab;
		  private System.Windows.Forms.GroupBox ComparePickGroupBox;
		  private System.Windows.Forms.ComboBox CompareTestComboBox;
		  private System.Windows.Forms.Label TestLbl;
		  private System.Windows.Forms.Label BaseLbl;
		  private System.Windows.Forms.ComboBox BaseComboBox;
		  private SynapticEffect.Forms.TreeListView compareTreeListView;
		  private System.Windows.Forms.Button CompareSubmitBtn;
		  private System.Windows.Forms.Label EmailLbl;
		  private System.Windows.Forms.RichTextBox EmailMsgTxt;
    }
}

