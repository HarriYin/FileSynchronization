using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSynchronization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;

            Timer t = new Timer();
            t.Interval = 1000;
            t.Tick += T_Tick;
            t.Start();


        }

        private void T_Tick(object sender, EventArgs e)
        {
            DoWork();
        }



        private static void DoWork()
        {
            try
            {
                string folderPath_old = @"E:\\1";
                string folderPath_new = @"E:\\2";

                string filePath_old = @"E:\\1\\1.xls";
                string filePath_new = @"E:\\2\\1.xls";

                FolderExists(folderPath_old);
                FolderExists(folderPath_new);


                DateTime dt1;
                DateTime dt2;

                object a = FileExists(filePath_old);//旧文件路径
                if (a != null) dt1 = Convert.ToDateTime(a); else return;

                object b = FileExists(filePath_new);//新文件路径
                if (b != null) dt2 = Convert.ToDateTime(b); else return;



                if ((dt2 - dt1).TotalSeconds > 0)
                {
                    File.Delete(filePath_old);//删除旧文件
                    File.Copy(filePath_new, filePath_old);//复制文件
                    //File.Delete(filePath_new);
                }
                else if ((dt1 - dt2).TotalSeconds > 0)
                {
                    File.Delete(filePath_new);//删除旧文件
                    File.Copy(filePath_old, filePath_new);//复制文件
                    //File.Delete(filePath_new);
                }
                else
                {
                
                }
            }
            catch
            { }
        }

        private static void FolderExists(string spath)
        {
            if (Directory.Exists(spath))
            {

            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(spath);
                directoryInfo.Create();
            }
        }

        private static object FileExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }

            FileInfo fi = new FileInfo(filePath);
            return fi.LastWriteTime;
        }

    }
}














