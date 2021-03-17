using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace MyPing
{
    public partial class Form2 : Form
    {
        public int packetLength, ttl, interval, timeThreshold;
        public bool dontFragment;
        public List<IPAddress> ipList = new List<IPAddress>();
        public ListView.ListViewItemCollection listItems;
        public delegate void ModifyListItem(ListViewItem item, Color color, object[] param);
        public ModifyListItem ModifyListItemDelegate;
        long[] timeRecord;
        int columnCount;
        public DataTable dataTable;
        public DataView dataView;
        public List<string> list;
        Ping[] pingSenders;
        PingOptions options;
        Utilitys utility = new Utilitys();
        Stopwatch stp = new Stopwatch();


        public Form2()
        {
            InitializeComponent();
            //ModifyListItemDelegate = new ModifyListItem(ModifyListItemMethod);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(Utilitys.dataGridView_CellFormatting);
            //this.dataGridView1.SelectionChanged += new System.EventHandler(Utilitys.dataGridView_SelectionChanged);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled)
            {
                timer1.Stop();
                //Console.WriteLine("Stopped");
                button1.Text = "继续测试";
                button2.Enabled = true;
            }
            else
            {
                timer1.Start();
                //Console.WriteLine("Started");
                button1.Text = "停止测试";
                button2.Enabled = false;
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            object[] objList = new object[14];
            try
            {
                foreach (string item in list)
                {
                    string[] strList = item.Split(',');
                    objList[1] = strList[0];    //IP
                    objList[2] = strList[1];    //主机名
                    objList[3] = strList[2];    //MAC
                    objList[4] = "Failed";    //状态
                    objList[5] = Timeout.Infinite;  //响应时间
                    objList[8] = 0;             //发送计数
                    objList[9] = 0;             //接收计数
                    objList[11] = Timeout.Infinite; //最小时间
                    objList[12] = Timeout.Infinite; //平均时间
                    objList[13] = 0; //最大时间
                    dataTable1.Rows.Add(objList);
                    ipList.Add(IPAddress.Parse(strList[0]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            dataGridView1.DataSource = dataTable1.DefaultView.ToTable();
            //pingSenders = new Ping[list.Count];
            timeRecord = new long[list.Count];
            options = new PingOptions(ttl, dontFragment);
            utility.TotalIPs = list.Count;
//             for (int i = 0; i < pingSenders.Length; i++ )
//             {
//                 pingSenders[i] = new Ping();
//                 pingSenders[i].PingCompleted += new PingCompletedEventHandler(pingSender_PingCompleted);
//             }
            labelIPCount.DataBindings.Add("Text", utility, "TotalIPs");
            labelIPUps.DataBindings.Add("Text", utility, "UpIPs");
            timer1.Interval = interval;
            timer1.Start();
            timer2.Start();
            comboBox1.SelectedIndex = 2;
            this.ResumeLayout(true);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int timeout = timeThreshold;
            for (int i = 0; i < ipList.Count; i++)
            {
                Ping pingSender = new Ping();
                pingSender.PingCompleted += new PingCompletedEventHandler(pingSender_PingCompleted);
                pingSender.SendAsync(ipList[i], timeout, new byte[packetLength], options, i);
                //listView1.Items[i].SubItems[7].Text = (int.Parse(listView1.Items[i].SubItems[7].Text) + 1).ToString();//发送+1
                dataTable1.Rows[i]["发送计数"] = ((int)dataTable1.Rows[i]["发送计数"]) + 1;
            }
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            //stp.Restart();
            /*
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Refresh();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
             */ 
            //columnCount = listView1.Columns.Count;
            //Console.WriteLine("Eclipse Time: " + stp.ElapsedMilliseconds.ToString());

        }

        void pingSender_PingCompleted(object sender, PingCompletedEventArgs e)
        {
//             try
//             {
                int transCount,recvCount;
                double lost;
                Color color = Color.Transparent;
                int row = (int)e.UserState;     //指示行数
                int count = columnCount;    //指示列数
                // If the operation was canceled, display a message to the user.
                if (e.Cancelled)
                {
                    Console.WriteLine("Ping canceled.");
                }

                // If an error occurred, display the exception to the user.
                if (e.Error != null)
                {
                    Console.WriteLine("Ping failed:");
                    Console.WriteLine(e.Error.ToString());
                }

                PingReply reply = e.Reply;

                //开始解析
                if (reply.Status == IPStatus.Success)   //ping成功
                {
                    timeRecord[row] += reply.RoundtripTime; //记录响应时间
                    /*
                    if(reply.RoundtripTime>timeThreshold){
                        color=Color.Red;
                    }
                    */
                    if ((string)dataTable1.Rows[row]["状态"] != IPStatus.Success.ToString())
                    {       //不成功变为成功，在线数+1
                        utility.UpIPs++;
                    }
                    dataTable1.Rows[row]["状态"] = reply.Status.ToString();
                    dataTable1.Rows[row]["响应时间"] = reply.RoundtripTime.ToString();
                    dataTable1.Rows[row]["TTL"] = reply.Options.Ttl.ToString();
                    dataTable1.Rows[row]["包长"] = reply.Buffer.Length.ToString();
                    transCount = (int)dataTable1.Rows[row]["发送计数"];
                    recvCount = (int)dataTable1.Rows[row]["接收计数"] + 1;
                    dataTable1.Rows[row]["接收计数"] = recvCount;
                    lost = (double)(transCount - recvCount) / (double)transCount;
                    dataTable1.Rows[row]["丢包率"] = (lost * 100).ToString("f2") + "%";
                    if ((int)dataTable1.Rows[row]["最小时间"]==Timeout.Infinite)    
                    {
                        dataTable1.Rows[row]["最小时间"] = reply.RoundtripTime;
                    }
                    else if (reply.RoundtripTime < (int)dataTable1.Rows[row]["最小时间"])
                    {
                        dataTable1.Rows[row]["最小时间"] = reply.RoundtripTime;
                    }
                    if (recvCount != 0)   //计算平均时间
                    {
                        dataTable1.Rows[row]["平均时间"] = ((double)(timeRecord[row]) / (double)(recvCount)).ToString("f2");  //计算平均时间

                    }
                    if (reply.RoundtripTime > (int)dataTable1.Rows[row]["最大时间"])  //计算最大时间
                    {
                        dataTable1.Rows[row]["最大时间"] = reply.RoundtripTime;
                    }
                }
                else        //ping失败
                {
                    //color = Color.Red;
                    if ((string)dataTable1.Rows[row]["状态"] == IPStatus.Success.ToString())
                    {       //成功变为不成功，在线数-1
                        utility.UpIPs--;
                    }
                    dataTable1.Rows[row]["状态"] = reply.Status.ToString();
                    transCount = (int)dataTable1.Rows[row]["发送计数"];
                    recvCount = (int)dataTable1.Rows[row]["接收计数"];
                    lost = (double)(transCount - recvCount) / (double)transCount;
                    dataTable1.Rows[row]["丢包率"] = (lost * 100).ToString("f2") + "%";
                    if (recvCount != 0)     //计算平均时间
                    {
                        dataTable1.Rows[row]["平均时间"] = ((double)(timeRecord[row]) / (double)(recvCount)).ToString("f2");  //计算平均时间

                    }
                }
                //this.Invoke(ModifyListItemDelegate, listView1.Items[num], color, tempStr);

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.ToString());
//             }
                //GC.Collect();
        }

        void ModifyListItemMethod(ListViewItem item,Color color, object[] param)
        {
            for (int i = 0; i < item.SubItems.Count; i++)
            {
                item.SubItems[i].Text = (string)param[i];
            }
            item.BackColor = color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string saveFileName;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;
            sfd.DefaultExt = "xlsx";
            sfd.Filter = "Excel files (*.xlsx)|*.xlsx|Txt files (*.txt)|*.txt";
            sfd.FilterIndex = 0;
            sfd.FileName = DateTime.Now.ToString("yyyy-MM-dd HH：mm：ss") + " 测试结果";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                saveFileName = sfd.FileName.Trim();
                if (saveFileName != "")
                {
                    if (sfd.FilterIndex == 1) //Excel文件
                    {
                        try
                        {
                            SaveExcelFiles(saveFileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                    }
                    else if (sfd.FilterIndex == 2) //Txt文件
                    {
                        //MessageBox.Show("Save As TXT");
                        StreamWriter sw = new StreamWriter(saveFileName, false, Encoding.UTF8);
                        //sw.WriteLine("扫描总数：" + utility.TotalIPs.ToString() + ",   在线IP数：" + utility.UpIPs.ToString());
                        object[,] data = CopyData();
                        int datacount = 0;
                        foreach (object item in data)
                        {
                            sw.Write(item);
                            sw.Write(",\t");
                            if ((++datacount) % dataTable1.Columns.Count == 0) sw.WriteLine();
                        }
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
        }

        private object[,] CopyData()
        {
            int row = dataTable1.Rows.Count;
            int col = dataTable1.Columns.Count;
            object[,] data = new object[row + 2, col];
            data[0, 1] = "扫描总数：" + utility.TotalIPs.ToString();
            data[0, 2] = "在线IP数：" + utility.UpIPs.ToString();
            for (int n = 0; n < dataTable1.Columns.Count; n++)  //写入表头
            {
                data[1, n] = dataTable1.Columns[n].ColumnName;
            }
            for (int i = 0; i < row; i++)       //写入数据
            {
                for (int j = 0; j < col; j++)
                {
                    data[i + 2, j] = dataTable1.Rows[i][j];
                }
            }
            return data;
        }

        private void SaveExcelFiles(string savePath)
        {
            ExcelUtilitys.SaveExcelFiles(savePath, CopyData(), "IP测试结果", false);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataTable1.DefaultView.ToTable(); //不能直接绑定视图，避免同源问题
// 
//             dataGridView1.ResumeLayout(true);
//             dataGridView1.PerformLayout();
//             dataGridView1.Refresh();
//             dataGridView1.SuspendLayout();
//             dataGridView1.DataSource = null;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer2.Interval = int.Parse((string)comboBox1.SelectedItem) * 1000;
        }



    }
}
