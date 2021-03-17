namespace MyPing
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.transCountColumn = new System.Data.DataColumn();
            this.recvCountColumn = new System.Data.DataColumn();
            this.lostColumn = new System.Data.DataColumn();
            this.minTimeColumn = new System.Data.DataColumn();
            this.averageTimeColumn = new System.Data.DataColumn();
            this.maxTimeColumn = new System.Data.DataColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelIPUps = new System.Windows.Forms.Label();
            this.labelIPCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(0, 651);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(908, 55);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制";
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(325, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(291, 35);
            this.button2.TabIndex = 4;
            this.button2.Text = "生成报告";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(3, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(322, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "停止测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "PingTest";
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
            this.packLengthColumn,
            this.transCountColumn,
            this.recvCountColumn,
            this.lostColumn,
            this.minTimeColumn,
            this.averageTimeColumn,
            this.maxTimeColumn});
            this.dataTable1.TableName = "IPTest";
            // 
            // noColumn
            // 
            this.noColumn.AutoIncrement = true;
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
            // transCountColumn
            // 
            this.transCountColumn.ColumnName = "发送计数";
            this.transCountColumn.DataType = typeof(int);
            // 
            // recvCountColumn
            // 
            this.recvCountColumn.ColumnName = "接收计数";
            this.recvCountColumn.DataType = typeof(int);
            // 
            // lostColumn
            // 
            this.lostColumn.ColumnName = "丢包率";
            // 
            // minTimeColumn
            // 
            this.minTimeColumn.ColumnName = "最小时间";
            this.minTimeColumn.DataType = typeof(int);
            // 
            // averageTimeColumn
            // 
            this.averageTimeColumn.ColumnName = "平均时间";
            // 
            // maxTimeColumn
            // 
            this.maxTimeColumn.ColumnName = "最大时间";
            this.maxTimeColumn.DataType = typeof(int);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1207, 642);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.VirtualMode = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.labelIPUps);
            this.groupBox3.Controls.Add(this.labelIPCount);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(926, 651);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(281, 55);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "统计";
            // 
            // labelIPUps
            // 
            this.labelIPUps.AutoSize = true;
            this.labelIPUps.Location = new System.Drawing.Point(203, 26);
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
            this.label8.Location = new System.Drawing.Point(141, 26);
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
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "5"});
            this.comboBox1.Location = new System.Drawing.Point(851, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(54, 24);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(682, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "列表刷新间隔(s):";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 706);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dataGridView1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Text = "测试窗口";
            this.Activated += new System.EventHandler(this.Form2_Activated);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Data.DataColumn noColumn;
        private System.Data.DataColumn IPColumn;
        private System.Data.DataColumn hostNameColumn;
        private System.Data.DataColumn macColumn;
        private System.Data.DataColumn statusColumn;
        private System.Data.DataColumn replyTimeColumn;
        private System.Data.DataColumn ttlColumn;
        private System.Data.DataColumn packLengthColumn;
        private System.Data.DataColumn transCountColumn;
        private System.Data.DataColumn recvCountColumn;
        private System.Data.DataColumn lostColumn;
        private System.Data.DataColumn minTimeColumn;
        private System.Data.DataColumn averageTimeColumn;
        private System.Data.DataColumn maxTimeColumn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelIPUps;
        private System.Windows.Forms.Label labelIPCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}