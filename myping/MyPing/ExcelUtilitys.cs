using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace MyPing
{
    public class ExcelUtilitys
    {
        public static bool SaveExcelFiles(string savePath, object[,] dataMatrix2, string sheetName = null, bool visible = false)
        {
            //变量定义
            Excel.Application xlsapp;
            Excel.Workbook xlsbook;
            Excel.Worksheet xlssheet;
            Excel.Range range;


            xlsapp = new Excel.Application();
            if (xlsapp == null) throw new Exception("工作簿初始化失败！");
            else
            {
                try
                {
                    xlsapp.Visible = visible;
                    xlsbook = xlsapp.Workbooks.Add();
                    xlssheet = (Excel.Worksheet)xlsbook.Sheets[1];
                    if (sheetName != null) xlssheet.Name = sheetName;

                    int row = dataMatrix2.GetUpperBound(0) + 1;
                    int col = dataMatrix2.GetUpperBound(1) + 1;
                    range = xlssheet.get_Range("A1", IndexToColumnString(col) + row.ToString());
                    //range = xlssheet.get_Range(xlssheet.Cells[2, 1], xlssheet.Cells[num + 1, listView1.Columns.Count]);
                    range.Value = dataMatrix2;
                    xlssheet.Columns.AutoFit();
                    xlsbook.SaveAs(savePath);
                    xlsbook.Close(false);
                    xlsapp.Quit();

                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
            return true;
        }

        public static string IndexToColumnString(int column)  //从1开始
        {
            int retCharASCII =(int)'A';
            Stack<int> rest = new Stack<int>();
            if (column <= 0) throw new ArgumentOutOfRangeException("列索引值必须大于0");
            ModFunc(column, rest);
            StringBuilder sb = new StringBuilder();
            
            while (rest.Count > 0)
            {
                sb.Append((char)(retCharASCII - 1 + rest.Pop()));
            }
            //string retVal = ((char)(retCharASCII + column)).ToString();
            return sb.ToString();
        }

        private static void ModFunc(int num, Stack<int> rest = null)
        {
            int modNum = 26;
             
            int n = num % modNum;   //取余数
            int m = num / modNum;   //取整数部分
            if (n==0)   //余数为零，向前借位
            {
                n = modNum;
                num -= modNum;
                m = num / modNum;
            }
            if (rest != null) rest.Push(n);          //余数入栈
            if (m > 0) ModFunc(m, rest);  //整数部分还能再分割继续迭代,最后全部入栈
        }

    }
}
