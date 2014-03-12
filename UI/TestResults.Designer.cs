namespace UI
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
				this.DbLoginGroupBox.SuspendLayout();
				this.contextMenuStrip1.SuspendLayout();
				this.SelectDataGroupBox.SuspendLayout();
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
				this.DbLoginGroupBox.Location = new System.Drawing.Point(10, 10);
				this.DbLoginGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
				this.DbLoginGroupBox.Name = "DbLoginGroupBox";
				this.DbLoginGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
				this.DbLoginGroupBox.Size = new System.Drawing.Size(1250, 70);
				this.DbLoginGroupBox.TabIndex = 10;
				this.DbLoginGroupBox.TabStop = false;
				this.DbLoginGroupBox.Text = "Database Login";
				// 
				// ConnectBtn
				// 
				this.ConnectBtn.Location = new System.Drawing.Point(941, 40);
				this.ConnectBtn.Name = "ConnectBtn";
				this.ConnectBtn.Size = new System.Drawing.Size(75, 25);
				this.ConnectBtn.TabIndex = 5;
				this.ConnectBtn.Text = "Connect";
				this.ConnectBtn.UseVisualStyleBackColor = true;
				this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
				// 
				// PortTxt
				// 
				this.PortTxt.Location = new System.Drawing.Point(257, 27);
				this.PortTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
				this.PortTxt.Name = "PortTxt";
				this.PortTxt.Size = new System.Drawing.Size(69, 22);
				this.PortTxt.TabIndex = 2;
				// 
				// PortLbl
				// 
				this.PortLbl.AutoSize = true;
				this.PortLbl.Location = new System.Drawing.Point(215, 32);
				this.PortLbl.Name = "PortLbl";
				this.PortLbl.Size = new System.Drawing.Size(38, 17);
				this.PortLbl.TabIndex = 11;
				this.PortLbl.Text = "Port:";
				// 
				// DefaultBtn
				// 
				this.DefaultBtn.Location = new System.Drawing.Point(941, 10);
				this.DefaultBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
				this.DefaultBtn.Name = "DefaultBtn";
				this.DefaultBtn.Size = new System.Drawing.Size(75, 25);
				this.DefaultBtn.TabIndex = 0;
				this.DefaultBtn.Text = "Default";
				this.DefaultBtn.UseVisualStyleBackColor = true;
				this.DefaultBtn.Click += new System.EventHandler(this.DefaultBtn_Click);
				// 
				// ReadyLbl
				// 
				this.ReadyLbl.AutoSize = true;
				this.ReadyLbl.Location = new System.Drawing.Point(1087, 28);
				this.ReadyLbl.Name = "ReadyLbl";
				this.ReadyLbl.Size = new System.Drawing.Size(49, 17);
				this.ReadyLbl.TabIndex = 12;
				this.ReadyLbl.Text = "Ready";
				// 
				// CollectionNameTxt
				// 
				this.CollectionNameTxt.Location = new System.Drawing.Point(706, 26);
				this.CollectionNameTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
				this.CollectionNameTxt.Name = "CollectionNameTxt";
				this.CollectionNameTxt.Size = new System.Drawing.Size(216, 22);
				this.CollectionNameTxt.TabIndex = 4;
				// 
				// StatusLbl
				// 
				this.StatusLbl.AutoSize = true;
				this.StatusLbl.Location = new System.Drawing.Point(1037, 28);
				this.StatusLbl.Name = "StatusLbl";
				this.StatusLbl.Size = new System.Drawing.Size(52, 17);
				this.StatusLbl.TabIndex = 13;
				this.StatusLbl.Text = "Status:";
				// 
				// CollectionNameLbl
				// 
				this.CollectionNameLbl.AutoSize = true;
				this.CollectionNameLbl.Location = new System.Drawing.Point(575, 29);
				this.CollectionNameLbl.Name = "CollectionNameLbl";
				this.CollectionNameLbl.Size = new System.Drawing.Size(114, 17);
				this.CollectionNameLbl.TabIndex = 14;
				this.CollectionNameLbl.Text = "Collection Name:";
				// 
				// DbNameLbl
				// 
				this.DbNameLbl.AutoSize = true;
				this.DbNameLbl.Location = new System.Drawing.Point(346, 31);
				this.DbNameLbl.Name = "DbNameLbl";
				this.DbNameLbl.Size = new System.Drawing.Size(72, 17);
				this.DbNameLbl.TabIndex = 15;
				this.DbNameLbl.Text = "DB Name:";
				// 
				// DbNameTxt
				// 
				this.DbNameTxt.Location = new System.Drawing.Point(424, 27);
				this.DbNameTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
				this.DbNameTxt.Name = "DbNameTxt";
				this.DbNameTxt.Size = new System.Drawing.Size(133, 22);
				this.DbNameTxt.TabIndex = 3;
				// 
				// DbAddressTxt
				// 
				this.DbAddressTxt.Location = new System.Drawing.Point(101, 28);
				this.DbAddressTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
				this.DbAddressTxt.Name = "DbAddressTxt";
				this.DbAddressTxt.Size = new System.Drawing.Size(98, 22);
				this.DbAddressTxt.TabIndex = 1;
				// 
				// DbAddressLbl
				// 
				this.DbAddressLbl.AutoSize = true;
				this.DbAddressLbl.Location = new System.Drawing.Point(8, 32);
				this.DbAddressLbl.Name = "DbAddressLbl";
				this.DbAddressLbl.Size = new System.Drawing.Size(87, 17);
				this.DbAddressLbl.TabIndex = 16;
				this.DbAddressLbl.Text = "DB Address:";
				// 
				// GetDataByDaysBtn
				// 
				this.GetDataByDaysBtn.Enabled = false;
				this.GetDataByDaysBtn.Location = new System.Drawing.Point(1148, 23);
				this.GetDataByDaysBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
				this.GetDataByDaysBtn.Name = "GetDataByDaysBtn";
				this.GetDataByDaysBtn.Size = new System.Drawing.Size(80, 25);
				this.GetDataByDaysBtn.TabIndex = 9;
				this.GetDataByDaysBtn.Text = "Get Data";
				this.GetDataByDaysBtn.UseVisualStyleBackColor = true;
				this.GetDataByDaysBtn.Click += new System.EventHandler(this.GetDataByDaysBtn_Click);
				// 
				// DaysTxt
				// 
				this.DaysTxt.Location = new System.Drawing.Point(1051, 27);
				this.DaysTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
				this.DaysTxt.Name = "DaysTxt";
				this.DaysTxt.Size = new System.Drawing.Size(64, 22);
				this.DaysTxt.TabIndex = 8;
				// 
				// DaysLbl
				// 
				this.DaysLbl.AutoSize = true;
				this.DaysLbl.Location = new System.Drawing.Point(985, 30);
				this.DaysLbl.Name = "DaysLbl";
				this.DaysLbl.Size = new System.Drawing.Size(44, 17);
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
				this.contextMenuStrip1.Size = new System.Drawing.Size(254, 100);
				// 
				// failureToolStripMenuItem
				// 
				this.failureToolStripMenuItem.Name = "failureToolStripMenuItem";
				this.failureToolStripMenuItem.Size = new System.Drawing.Size(253, 24);
				this.failureToolStripMenuItem.Text = "Mark as Failure";
				this.failureToolStripMenuItem.Click += new System.EventHandler(this.failureToolStripMenuItem_Click);
				// 
				// acceptedFailureToolStripMenuItem
				// 
				this.acceptedFailureToolStripMenuItem.Name = "acceptedFailureToolStripMenuItem";
				this.acceptedFailureToolStripMenuItem.Size = new System.Drawing.Size(253, 24);
				this.acceptedFailureToolStripMenuItem.Text = "Mark as Accepted Failure...";
				this.acceptedFailureToolStripMenuItem.Click += new System.EventHandler(this.acceptedFailureToolStripMenuItem_Click);
				// 
				// bugToolStripMenuItem
				// 
				this.bugToolStripMenuItem.Name = "bugToolStripMenuItem";
				this.bugToolStripMenuItem.Size = new System.Drawing.Size(253, 24);
				this.bugToolStripMenuItem.Text = "Mark as Bug...";
				this.bugToolStripMenuItem.Click += new System.EventHandler(this.bugToolStripMenuItem_Click);
				// 
				// seeStatusMessageToolStripMenuItem
				// 
				this.seeStatusMessageToolStripMenuItem.Name = "seeStatusMessageToolStripMenuItem";
				this.seeStatusMessageToolStripMenuItem.Size = new System.Drawing.Size(253, 24);
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
				this.treeListView1.Location = new System.Drawing.Point(10, 165);
				this.treeListView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
				this.treeListView1.Name = "treeListView1";
				this.treeListView1.RowSelectColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(144)))), ((int)(((byte)(24)))));
				this.treeListView1.RowTrackColor = System.Drawing.Color.Empty;
				this.treeListView1.Size = new System.Drawing.Size(1250, 580);
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
				this.SelectDataGroupBox.Location = new System.Drawing.Point(10, 90);
				this.SelectDataGroupBox.Name = "SelectDataGroupBox";
				this.SelectDataGroupBox.Size = new System.Drawing.Size(1250, 65);
				this.SelectDataGroupBox.TabIndex = 19;
				this.SelectDataGroupBox.TabStop = false;
				this.SelectDataGroupBox.Text = "Choose Run or Date Range";
				// 
				// GetTestRunBtn
				// 
				this.GetTestRunBtn.Enabled = false;
				this.GetTestRunBtn.Location = new System.Drawing.Point(798, 25);
				this.GetTestRunBtn.Name = "GetTestRunBtn";
				this.GetTestRunBtn.Size = new System.Drawing.Size(80, 25);
				this.GetTestRunBtn.TabIndex = 7;
				this.GetTestRunBtn.Text = "Get Data";
				this.GetTestRunBtn.UseVisualStyleBackColor = true;
				this.GetTestRunBtn.Click += new System.EventHandler(this.GetTestRunBtn_Click);
				// 
				// TestRunLbl
				// 
				this.TestRunLbl.AutoSize = true;
				this.TestRunLbl.Location = new System.Drawing.Point(8, 29);
				this.TestRunLbl.Name = "TestRunLbl";
				this.TestRunLbl.Size = new System.Drawing.Size(70, 17);
				this.TestRunLbl.TabIndex = 20;
				this.TestRunLbl.Text = "Test Run:";
				// 
				// TestRunComboBox
				// 
				this.TestRunComboBox.FormattingEnabled = true;
				this.TestRunComboBox.Location = new System.Drawing.Point(101, 26);
				this.TestRunComboBox.Name = "TestRunComboBox";
				this.TestRunComboBox.Size = new System.Drawing.Size(671, 24);
				this.TestRunComboBox.TabIndex = 6;
				// 
				// TestResults
				// 
				this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(144)))), ((int)(((byte)(24)))));
				this.ClientSize = new System.Drawing.Size(1272, 755);
				this.Controls.Add(this.SelectDataGroupBox);
				this.Controls.Add(this.treeListView1);
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
    }
}

