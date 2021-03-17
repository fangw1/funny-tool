using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Data;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MyPing
{
    public partial class Form1 : Form
    {

        Ping pingSender;
        AutoResetEvent waiter = new AutoResetEvent(false);
        long startIP, endIP, count;
        int upCount, num;
        public delegate void AddListItem(PingReply reply, long ip, string mac,string hostName);
        public AddListItem AddListItemDelegate;
        public delegate void ChangeButtonEnable(Button btn, bool status);
        public ChangeButtonEnable ChangeButtonEnableDelegate;
        public delegate void ChangeListItemColor(ListViewItem obj, Color color);
        public ChangeListItemColor ChangeListItemColorDelegate;
        public delegate void ChangeStatusLabelText(string text);
        public ChangeStatusLabelText ChangeStatusLabelTextDelegate;

        Utilitys utility = new Utilitys();
        [DllImport("ws2_32.dll")]
        private static extern int inet_addr(string cp);
        [DllImport("IPHLPAPI.dll")]
        private static extern int SendARP(Int32 DestIP, Int32 SrcIP, ref Int64 pMacAddr, ref Int32 PhyAddrLen);
        public Form1()
        {
            InitializeComponent();
            pingSender = new Ping();
            upCount = 0;
            AddListItemDelegate = new AddListItem(AddListItemMethod);
            ChangeButtonEnableDelegate = new ChangeButtonEnable(ChangeButtonEnableMethod);
            ChangeListItemColorDelegate = new ChangeListItemColor(ChangeListItemColorMethod);
            ChangeStatusLabelTextDelegate = new ChangeStatusLabelText(ChangeStatusLabelTextMethod);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(Utilitys.dataGridView_CellFormatting);
            this.dataGridView1.SelectionChanged += new System.EventHandler(Utilitys.dataGridView_SelectionChanged);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Ping
            /*
            PingOptions po = new PingOptions(64, true);
            PingReply pr = pingScaner.Send(IPAddress.Loopback, 1000, new byte[64], po);
  //          PingReply pr = pingScaner.Send(IPAddress.Parse("114.80.143.158"), 1000, new byte[64], po);
            Console.WriteLine(pr.Address + "---" + pr.Status + "---" + pr.RoundtripTime);
            */


            // When the PingCompleted event is raised,
            // the PingCompletedCallback method is called.
            pingSender.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            // Wait 12 seconds for a reply.
            int timeout = 1000;

            // Set options for transmission:
            // The data can go through 64 gateways or routers
            // before it is destroyed, and the data packet
            // cannot be fragmented.
            PingOptions options = new PingOptions(64, true);

            Console.WriteLine("Time to live: {0}", options.Ttl);
            Console.WriteLine("Don't fragment: {0}", options.DontFragment);

            // Send the ping asynchronously.
            // Use the waiter as the user token.
            // When the callback completes, it can wake up this thread.
            pingSender.SendAsync(IPAddress.Loopback, timeout, new byte[64], options, waiter);

            // Prevent this example application from ending.
            // A real application should do something useful
            // when possible.
            #endregion

            waiter.WaitOne();
            Console.WriteLine("Ping example completed.");

        }
        /// <summary>
        /// 获取远程主机mac地址：不能跨网段
        /// </summary>
        /// <param name="hostip">远程主机IP</param>
        /// <returns>mac</returns>
        private string GetMacAddress(string hostip)//获取远程IP（不能跨网段）的MAC地址
        {
            string Mac = "";
            try
            {
                Int32 ldest = inet_addr(hostip); //将IP地址从 点数格式转换成无符号长整型
                Int64 macinfo = new Int64();
                Int32 len = 6;
                SendARP(ldest, 0, ref macinfo, ref len);
                string TmpMac = Convert.ToString(macinfo, 16).PadLeft(12, '0');//转换成16进制　　注意有些没有十二位
                Mac = TmpMac.Substring(0, 2).ToUpper();//
                for (int i = 2; i < TmpMac.Length; i = i + 2)
                {
                    Mac = TmpMac.Substring(i, 2).ToUpper() + "-" + Mac;
                }
            }
            catch (Exception Mye)
            {
                Mac = "获取远程主机的MAC错误：" + Mye.Message;
            }
            return Mac;
        }
        /// <summary>
        /// 获取远程主机名
        /// </summary>
        /// <param name="hostip">远程主机IP</param>
        /// <returns>远程主机名</returns>
        private string GetHostName(string hostip)
        {
            string HostName = "";
            string cmd = "nslookup " + hostip;
            //cmd = @"nbtstat -a " + "192.168.11.169";
            cmd = cmd.Trim().TrimEnd('&') + "&exit";//说明：不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序
            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(cmd);
            p.StandardInput.AutoFlush = true;
            string output = p.StandardOutput.ReadToEnd();
            string RegexStr = string.Empty;
            RegexStr = "名称:";
            Regex regex = new Regex(@"(?<=名称:).+(?=\r\nAddress:)");
            Match result = regex.Match(output);
            if (result.Success)
            {
                HostName = result.Value;//此为匹配出的值
            }
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();
            return HostName;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //utility.TotalIPs++;
            dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.OrangeRed;
            Console.WriteLine(dataGridView1.SelectedCells.Count);
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {

            IPAddress ipStart, ipEnd;
            utility.UpIPs = 0;    //计数清零
            num = 0;        //接收计数清零

            // listView1.Items.Clear();
            dataTable1.Clear();
            if (IPAddress.TryParse(textBoxIPStart.Text, out ipStart) && IPAddress.TryParse(textBoxIPEnd.Text, out ipEnd))
            {
                try
                {
                    startIP = IpToLong(textBoxIPStart.Text);
                    endIP = IpToLong(textBoxIPEnd.Text);
                    count = utility.TotalIPs = endIP - startIP + 1;      //总数清零

                    if (utility.TotalIPs >= 0)
                    {
                        ChangeStatusLabelTextMethod("扫描中...");
                        buttonScan.Enabled = false;
                        buttonTest.Enabled = false;
                        buttonTestSelected.Enabled = false;
                        buttonCut.Enabled = false;
                        buttonSave.Enabled = false;

                        for (long i = startIP; i <= endIP; i++)
                        {
                            Ping pingScaner = new Ping();
                            pingScaner.PingCompleted += new PingCompletedEventHandler(pingScaner_PingCompleted);
                            int timeout = 5000;
                            PingOptions options = new PingOptions(64, true);

                            pingScaner.SendAsync(LongToIP(i), timeout, new byte[64], options, i);
                        }
                    }
                    else
                    {
                        throw new Exception("请检查输入！");
                    }
                }
                catch (Exception ex)
                {
                    buttonScan.Enabled = true;
                    //        MessageBox.Show(ex.Message);
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("请检查输入！");
            }
        }

        void pingScaner_PingCompleted(object sender, PingCompletedEventArgs e)
        {
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

            PingReply reply = e.Reply;  //获取回复对象

            try
            {
                if (--count <= 0)
                {
                    ChangeStatusLabelTextDelegate("扫描完成");
                    ChangeButtonEnableDelegate(buttonScan, true);
                    ChangeButtonEnableDelegate(buttonCut, true);
                    ChangeButtonEnableDelegate(buttonTest, true);
                    ChangeButtonEnableDelegate(buttonSave, true);
                    ChangeButtonEnableDelegate(buttonTestSelected, true);
                }
                //Console.WriteLine(count);
                //                 if ((long)e.UserState == IpToLong(reply.Address.ToString()))
                //                 {
                string mac = "";
                string hostName = "";
                if (reply.Status == IPStatus.Success)
                {

                    mac = GetMacAddress(reply.Address.ToString());
                    hostName = GetHostName(reply.Address.ToString());
                    utility.UpIPs++;
                    /*
                    Console.WriteLine(upCount);
                    Console.WriteLine(count.ToString());
                    Console.WriteLine(reply.Address.ToString());
                    Console.WriteLine(reply.Status.ToString());
                    Console.WriteLine(Dns.GetHostByAddress(reply.Address).HostName);
                    Console.WriteLine(reply.RoundtripTime.ToString());
                    Console.WriteLine(reply.Options.Ttl.ToString());
                    Console.WriteLine(reply.Buffer.Length.ToString());
                     */
                }
                this.Invoke(AddListItemDelegate, reply, (long)e.UserState, mac, hostName);

                /*
                Console.Write(LongToIp((long)e.UserState)+"       ");
                DisplayReply(reply);
                */
                

               
                //                 }
                //                 else        //目标地址和源地址不一致视为通信失败
                //                 {
                // 
                //                     //Console.WriteLine(LongToIp((long)e.UserState) + "-------" + reply.Address.ToString());
                //                 }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                try
                {
                    list.Add(dataTable1.Rows[item.Index]["IP"] as string + ","
                        + dataTable1.Rows[item.Index]["主机名"] as string + ","
                        + dataTable1.Rows[item.Index]["MAC地址"] as string);
                }
                catch (Exception) { }//可能会遇到最后一行没有内容的行，忽略
            }

            Form2 fm2 = new Form2();
            try
            {
                fm2.list = list;
                fm2.packetLength = int.Parse(textBoxPackLength.Text);
                fm2.ttl = int.Parse(textBoxTTL.Text);
                fm2.interval = int.Parse(textBoxInterval.Text);
                fm2.timeThreshold = int.Parse(textBoxThreshold.Text);
                fm2.dontFragment = checkBoxDontFragment.Checked;
                fm2.Show(this);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonTestSelected_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                list.Add(dataTable1.Rows[item.Index]["IP"] as string + ","
                    + dataTable1.Rows[item.Index]["主机名"] as string + ","
                    + dataTable1.Rows[item.Index]["MAC地址"] as string);
            }

            Form2 fm2 = new Form2();
            try
            {
                fm2.list = list;
                fm2.packetLength = int.Parse(textBoxPackLength.Text);
                fm2.ttl = int.Parse(textBoxTTL.Text);
                fm2.interval = int.Parse(textBoxInterval.Text);
                fm2.timeThreshold = int.Parse(textBoxThreshold.Text);
                fm2.dontFragment = checkBoxDontFragment.Checked;
                fm2.Show(this);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonCut_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < dataGridView1.Rows.Count - 1)
            {
                if (dataGridView1.Rows[i].Cells["状态"].Value.ToString() != IPStatus.Success.ToString())
                {
                    dataGridView1.Rows.RemoveAt(i);
                    //dataGridView1.Update();
                }
                else
                {
                    i++;
                }
            }
            //utility.TotalIPs = dataGridView1.Rows.Count;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string saveFileName;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;
            sfd.DefaultExt = "xlsx";
            sfd.Filter = "Excel files (*.xlsx)|*.xlsx|Txt files (*.txt)|*.txt";
            sfd.FilterIndex = 0;
            sfd.FileName = DateTime.Now.ToString("yyyy-MM-dd HH：mm：ss") + " 扫描结果";
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
            //string[,] heads = new string[1, 8] { { "序号", "IP", "主机名", "MAC地址", "状态", "回复时间", "TTL", "包长" } };
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
            ExcelUtilitys.SaveExcelFiles(savePath, CopyData(), "IP扫描结果", false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dataTable = dataSet1.Tables[0];
            dataGridView1.DataSource = dataTable1;

            //textBox1.DataBindings.Add("Text", utility, "TotalIPs");
            labelIPCount.DataBindings.Add("Text", utility, "TotalIPs");
            labelIPUps.DataBindings.Add("Text", utility, "UpIPs");

        }


        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /*
            Console.WriteLine(e.ColumnIndex);
            DataView dv = dataTable.DefaultView;
            //dv.Sort = "IP ASC";
            dataTable = dv.ToTable();
            GC.Collect();
             */
            //Console.WriteLine(dataGridView1.Rows.Count);
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //Console.Write(sender.GetType());
            if (((ListView)sender).Sorting == SortOrder.Ascending)
            {
                ((ListView)sender).Sorting = SortOrder.Descending;
            }
            else
            {
                ((ListView)sender).Sorting = SortOrder.Ascending;
            }
            ((ListView)sender).ListViewItemSorter = new ItemComparer(e.Column, ((ListView)sender).Sorting);

            //listView1.Sort();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Excel.Application xlsapp;
            Excel.Workbook xlsbook;
            Excel.Worksheet xlssheet;
            Excel.Range range;

            Console.WriteLine(ExcelUtilitys.IndexToColumnString(26));
            xlsapp = new Excel.Application();
            if (xlsapp == null) throw new Exception("工作簿初始化失败！");
            else
            {
                string[] aaa = new string[16000];
                try
                {
                    for (int i = 0; i < aaa.Length; i++)
                    {
                        aaa[i] = ExcelUtilitys.IndexToColumnString(i + 1);
                    }

                    xlsapp.Visible = true;
                    xlsbook = xlsapp.Workbooks.Add();
                    xlssheet = (Excel.Worksheet)xlsbook.Sheets[1];

                    int row = 1;
                    int col = aaa.Length;
                    range = xlssheet.get_Range("A1", ExcelUtilitys.IndexToColumnString(col) + row.ToString());
                    //range = xlssheet.get_Range(xlssheet.Cells[2, 1], xlssheet.Cells[num + 1, listView1.Columns.Count]);
                    range.Value = aaa;
                    xlssheet.Columns.AutoFit();
                    //xlsbook.SaveAs(savePath);
                    xlsbook.Close(false);
                    xlsapp.Quit();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }


    }
}
