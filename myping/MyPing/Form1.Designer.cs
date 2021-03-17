namespace MyPing
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCut = new System.Windows.Forms.Button();
            this.buttonScan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIPEnd = new System.Windows.Forms.TextBox();
            this.textBoxIPStart = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonTestSelected = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.textBoxThreshold = new System.Windows.Forms.TextBox();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTTL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPackLength = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxDontFragment = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.noColumn = new System.Data.DataColumn();
            this.IPColumn = new System.Data.DataColumn();
            this.hostNameColumn = new System.Data.DataColumn();
            this.macColumn = new System.Data.DataColumn();
            this.statusColumn = new System.Data.DataColumn();
            this.replyTimeColumn = new System.Data.DataColumn();
            this.ttlColumn = new System.Data.DataColumn();
            this.packLengthColumn = new System.Data.DataColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelIPUps = new System.Windows.Forms.Label();
            this.labelIPCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(151, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Controls.Add(this.buttonCut);
            this.groupBox1.Controls.Add(this.buttonScan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxIPEnd);
            this.groupBox1.Controls.Add(this.textBoxIPStart);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 145);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP扫描";
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(75, 106);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCut
            // 
            this.buttonCut.Enabled = false;
            this.buttonCut.Location = new System.Drawing.Point(132, 77);
            this.buttonCut.Name = "buttonCut";
            this.buttonCut.Size = new System.Drawing.Size(75, 23);
            this.buttonCut.TabIndex = 3;
            this.buttonCut.Text = "过滤";
            this.buttonCut.UseVisualStyleBackColor = true;
            this.buttonCut.Click += new System.EventHandler(this.buttonCut_Click);
            // 
            // buttonScan
            // 
            this.buttonScan.Location = new System.Drawing.Point(23, 77);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(75, 23);
            this.buttonScan.TabIndex = 3;
            this.buttonScan.Text = "扫描";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "结束IP地址";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "起始IP地址";
            // 
            // textBoxIPEnd
            // 
            this.textBoxIPEnd.Location = new System.Drawing.Point(75, 47);
            this.textBoxIPEnd.Name = "textBoxIPEnd";
            this.textBoxIPEnd.Size = new System.Drawing.Size(132, 21);
            this.textBoxIPEnd.TabIndex = 1;
            this.textBoxIPEnd.Text = "192.168.1.255";
            // 
            // textBoxIPStart
            // 
            this.textBoxIPStart.Location = new System.Drawing.Point(75, 20);
            this.textBoxIPStart.Name = "textBoxIPStart";
            this.textBoxIPStart.Size = new System.Drawing.Size(132, 21);
            this.textBoxIPStart.TabIndex = 0;
            this.textBoxIPStart.Text = "192.168.1.0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonTestSelected);
            this.groupBox2.Controls.Add(this.buttonTest);
            this.groupBox2.Controls.Add(this.textBoxThreshold);
            this.groupBox2.Controls.Add(this.textBoxInterval);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxTTL);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxPackLength);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.checkBoxDontFragment);
            this.groupBox2.Location = new System.Drawing.Point(274, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 145);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测试";
            // 
            // buttonTestSelected
            // 
            this.buttonTestSelected.Enabled = false;
            this.buttonTestSelected.Location = new System.Drawing.Point(179, 66);
            this.buttonTestSelected.Name = "buttonTestSelected";
            this.buttonTestSelected.Size = new System.Drawing.Size(75, 23);
            this.buttonTestSelected.TabIndex = 5;
            this.buttonTestSelected.Text = "测试选中";
            this.buttonTestSelected.UseVisualStyleBackColor = true;
            this.buttonTestSelected.Click += new System.EventHandler(this.buttonTestSelected_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Enabled = false;
            this.buttonTest.Location = new System.Drawing.Point(179, 99);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 5;
            this.buttonTest.Text = "测试全部";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // textBoxThreshold
            // 
            this.textBoxThreshold.Location = new System.Drawing.Point(102, 101);
            this.textBoxThreshold.Name = "textBoxThreshold";
            this.textBoxThreshold.Size = new System.Drawing.Size(59, 21);
            this.textBoxThreshold.TabIndex = 4;
            this.textBoxThreshold.Text = "1000";
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(61, 74);
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(100, 21);
            this.textBoxInterval.TabIndex = 4;
            this.textBoxInterval.Text = "2000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "超时阈值(ms)";
            // 
            // textBoxTTL
            // 
            this.textBoxTTL.Location = new System.Drawing.Point(61, 47);
            this.textBoxTTL.Name = "textBoxTTL";
            this.textBoxTTL.Size = new System.Drawing.Size(100, 21);
            this.textBoxTTL.TabIndex = 4;
            this.textBoxTTL.Text = "64";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "间隔(ms)";
            // 
            // textBoxPackLength
            // 
            this.textBoxPackLength.Location = new System.Drawing.Point(61, 20);
            this.textBoxPackLength.Name = "textBoxPackLength";
            this.textBoxPackLength.Size = new System.Drawing.Size(100, 21);
            this.textBoxPackLength.TabIndex = 3;
            this.textBoxPackLength.Text = "64";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "TTL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "包长度";
            // 
            // checkBoxDontFragment
            // 
            this.checkBoxDontFragment.AutoSize = true;
            this.checkBoxDontFragment.Checked = true;
            this.checkBoxDontFragment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDontFragment.Location = new System.Drawing.Point(179, 25);
            this.checkBoxDontFragment.Name = "checkBoxDontFragment";
            this.checkBoxDontFragment.Size = new System.Drawing.Size(60, 16);
            this.checkBoxDontFragment.TabIndex = 0;
            this.checkBoxDontFragment.Text = "不分包";
            this.checkBoxDontFragment.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 182);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(763, 493);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "ScanIPs";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.noColumn,
            this.IPColumn,
            this.hostNameColumn,
            this.macColumn,
            this.statusColumn,
            this.replyTimeColumn,
            this.ttlColumn,
            this.packLengthColumn});
            this.dataTable1.TableName = "Table1";
            // 
            // noColumn
            // 
            this.noColumn.AutoIncrementSeed = ((long)(1));
            this.noColumn.ColumnName = "序号";
            this.noColumn.DataType = typeof(int);
            // 
            // IPColumn
            // 
            this.IPColumn.ColumnName = "IP";
            // 
            // hostNameColumn
            // 
            this.hostNameColumn.ColumnName = "主机名";
            // 
            // macColumn
            // 
            this.macColumn.ColumnName = "MAC地址";
            // 
            // statusColumn
            // 
            this.statusColumn.ColumnName = "状态";
            // 
            // replyTimeColumn
            // 
            this.replyTimeColumn.ColumnName = "响应时间";
            this.replyTimeColumn.DataType = typeof(int);
            // 
            // ttlColumn
            // 
            this.ttlColumn.ColumnName = "TTL";
            this.ttlColumn.DataType = typeof(int);
            // 
            // packLengthColumn
            // 
            this.packLengthColumn.ColumnName = "包长";
            this.packLengthColumn.DataType = typeof(int);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.labelStatus);
            this.groupBox3.Controls.Add(this.labelIPUps);
            this.groupBox3.Controls.Add(this.labelIPCount);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(569, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(215, 145);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "状态";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(37, 116);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "ExcelTest";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(151, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(51, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.Fuchsia;
            this.labelStatus.Location = new System.Drawing.Point(15, 74);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(53, 12);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "等待操作";
            // 
            // labelIPUps
            // 
            this.labelIPUps.AutoSize = true;
            this.labelIPUps.Location = new System.Drawing.Point(77, 50);
            this.labelIPUps.Name = "labelIPUps";
            this.labelIPUps.Size = new System.Drawing.Size(11, 12);
            this.labelIPUps.TabIndex = 1;
            this.labelIPUps.Text = "0";
            // 
            // labelIPCount
            // 
            this.labelIPCount.AutoSize = true;
            this.labelIPCount.Location = new System.Drawing.Point(77, 26);
            this.labelIPCount.Name = "labelIPCount";
            this.labelIPCount.Size = new System.Drawing.Size(11, 12);
            this.labelIPCount.TabIndex = 1;
            this.labelIPCount.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "在线IP数:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "IP总数:";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(151, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 741);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "网络测试工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIPEnd;
        private System.Windows.Forms.TextBox textBoxIPStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.TextBox textBoxInterval;
        private System.Windows.Forms.TextBox textBoxTTL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPackLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxDontFragment;
        private System.Windows.Forms.Button buttonCut;
        private System.Windows.Forms.TextBox textBoxThreshold;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn noColumn;
        private System.Data.DataColumn IPColumn;
        private System.Data.DataColumn statusColumn;
        private System.Data.DataColumn hostNameColumn;
        private System.Data.DataColumn macColumn;
        private System.Data.DataColumn replyTimeColumn;
        private System.Data.DataColumn ttlColumn;
        private System.Data.DataColumn packLengthColumn;
        private System.Windows.Forms.Button buttonTestSelected;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelIPUps;
        private System.Windows.Forms.Label labelIPCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

