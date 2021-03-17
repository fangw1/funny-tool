using System;
using System.Collections;
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

namespace MyPing
{
    class Utilitys : ViewModel
    {
        private long _totalIPs;

        public long TotalIPs
        {
            get { return _totalIPs; }
            set { _totalIPs = value; this.RaisePropertyChanged("TotalIPs"); }
        }

        private long _upIPs;

        public long UpIPs
        {
            get { return _upIPs; }
            set { _upIPs = value; this.RaisePropertyChanged("UpIPs"); }
        }

        public Utilitys()
        {
            _totalIPs = 0;
            _upIPs = 0;
        }

        public Utilitys(int totalIPs)
        {
            _totalIPs = totalIPs;
            _upIPs = 0;
        }

        public static void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // If the column is the Artist column, check the
            // value.
            if (((DataGridView)sender).Columns[e.ColumnIndex].Name == "状态")
            {
                if (e.Value != null)
                {
                    //Console.WriteLine("CellFormatting");
                    string tempStr = e.Value as string;
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        if ((string)e.Value != IPStatus.Success.ToString())
                        {
                            ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.OrangeRed;
                            //e.CellStyle.BackColor = Color.Pink;
                        }
                        else
                        {
                            ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        }
                    }

                }
            }
        }

        public static void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("SelectionChanged" + ",  Selected Rows : " + dataGridView1.SelectedRows.Count);
            List<int> rowindexs = new List<int>();
            foreach (DataGridViewCell item in ((DataGridView)sender).SelectedCells)
            {
                //Console.Write(item.RowIndex.ToString() + "  ");
                rowindexs.Add(item.RowIndex);
            }
            //Console.WriteLine();
            IEnumerable<int> distinctRowindexs = rowindexs.Distinct();

            foreach (int tmp in distinctRowindexs)
            {
                ((DataGridView)sender).Rows[tmp].Selected = true;
                //Console.Write(tmp.ToString() + "  ");
            }
            //Console.WriteLine();
        }


    }

    class ItemComparer : IComparer
    {
        private int col;
        private int factor;
        public ItemComparer()
        {
            col = 0;
        }
        public ItemComparer(int column, SortOrder order)
        {
            col = column;
            if (order == SortOrder.Ascending)
            {
                factor = 1;
            }
            else
            {
                factor = -1;
            }
        }
        public int Compare(object x, object y)
        {
            switch (col)
            {
                case 0:
                case 4:
                case 5:
                case 6:
                    return factor * (int.Parse(((ListViewItem)x).SubItems[col].Text) - int.Parse(((ListViewItem)y).SubItems[col].Text));
                case 1:
                    return factor * (int)(Form1.IpToLong(((ListViewItem)x).SubItems[col].Text) - Form1.IpToLong(((ListViewItem)y).SubItems[col].Text));

                default:
                    return factor * String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }            //Console.Write(factor);
        }
    }
    public partial class Form1
    {
        public static long IpToLong(string strIp)
        {
            long[] ip = new long[4];
            string[] temp = strIp.Split('.');
            ip[0] = long.Parse(temp[0]);
            ip[1] = long.Parse(temp[1]);
            ip[2] = long.Parse(temp[2]);
            ip[3] = long.Parse(temp[3]);
            //进行左移位处理
            return (ip[0] << 24) + (ip[1] << 16) + (ip[2] << 8) + ip[3];
        }

        public static string LongToIp(long ip)
        {
            StringBuilder sb = new StringBuilder();
            //直接右移24位
            sb.Append(ip >> 24);
            sb.Append(".");
            //将高8位置0，然后右移16
            sb.Append((ip & 0x00FFFFFF) >> 16);
            sb.Append(".");
            //将高16位置0，然后右移8位
            sb.Append((ip & 0x0000FFFF) >> 8);
            sb.Append(".");
            //将高24位置0
            sb.Append((ip & 0x000000FF));
            return sb.ToString();
        }

        public static IPAddress LongToIP(long ip)
        {
            StringBuilder sb = new StringBuilder();
            //直接右移24位
            sb.Append(ip >> 24);
            sb.Append(".");
            //将高8位置0，然后右移16
            sb.Append((ip & 0x00FFFFFF) >> 16);
            sb.Append(".");
            //将高16位置0，然后右移8位
            sb.Append((ip & 0x0000FFFF) >> 8);
            sb.Append(".");
            //将高24位置0
            sb.Append((ip & 0x000000FF));
            return IPAddress.Parse(sb.ToString());
        }

        private void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {

            Console.WriteLine(e.UserState.GetType());

            // If the operation was canceled, display a message to the user.
            if (e.Cancelled)
            {
                Console.WriteLine("Ping canceled.");

                // Let the main thread resume. 
                // UserToken is the AutoResetEvent object that the main thread 
                // is waiting for.
                ((AutoResetEvent)e.UserState).Set();
            }

            // If an error occurred, display the exception to the user.
            if (e.Error != null)
            {
                Console.WriteLine("Ping failed:");
                Console.WriteLine(e.Error.ToString());

                // Let the main thread resume. 
                ((AutoResetEvent)e.UserState).Set();
            }

            PingReply reply = e.Reply;

            DisplayReply(reply);

            // Let the main thread resume.
            ((AutoResetEvent)e.UserState).Set();
        }

        public static void DisplayReply(PingReply reply)
        {
            if (reply == null)
                return;

            Console.WriteLine("ping status: {0}", reply.Status);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Address: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
            }
        }

        public void AddListItemMethod(PingReply reply, long ip, string mac,string hostName)
        {
            try
            {
                object[] listObj = new object[8];
                if (reply == null) return;
                listObj[0] = (++num).ToString();
                if (reply.Status == IPStatus.Success)
                {
                    listObj[1] = reply.Address.ToString();
                    listObj[2] = hostName;
                    listObj[3] = mac;
                    listObj[4] = reply.Status;
                    listObj[5] = reply.RoundtripTime;
                    listObj[6] = reply.Options.Ttl;
                    listObj[7] = reply.Buffer.Length;

                }
                else
                {
                    listObj[1] = LongToIp(ip);
                    listObj[4] = reply.Status;
                }
                //ListViewItem lvi = new ListViewItem(listObj);
                dataTable1.Rows.Add(listObj);
                /*
                DataRow dr = dataTable1.NewRow();
                dr.ItemArray = listObj;
                
                dataTable1.Rows.Add(dr);
                 */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void ChangeListItemMethod(PingReply reply, long ip, string mac, string hostName)
        {
            try
            {
                object[] listObj = new object[8];
                if (reply == null) return;
                listObj[0] = (++num).ToString();
                if (reply.Status == IPStatus.Success)
                {
                    listObj[1] = reply.Address.ToString();
                    listObj[2] = hostName;
                    listObj[3] = mac;
                    listObj[4] = reply.Status;
                    listObj[5] = reply.RoundtripTime;
                    listObj[6] = reply.Options.Ttl;
                    listObj[7] = reply.Buffer.Length;

                }
                else
                {
                    listObj[1] = LongToIp(ip);
                    listObj[4] = reply.Status;
                }
                dataTable1.Rows.Add(listObj);
                for (int i = 0; i < dataTable1.Rows.Count; i++)
                { 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void ChangeButtonEnableMethod(Button btn, bool status)
        {
            btn.Enabled = status;
        }

        void ChangeListItemColorMethod(ListViewItem obj, Color color)
        {
            obj.BackColor = color;
        }

        void ChangeStatusLabelTextMethod(string text)
        {
            labelStatus.Text = text;
        }


    }
}
