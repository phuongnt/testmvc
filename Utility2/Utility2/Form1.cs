using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.IO;
using System.Net;

namespace Utility2
{
    public partial class Form1 : Form
    {
        KeyboardHook _keyboardHook;
        string KeyDownValue = "";
        int count = 0;
        public Form1()
        {
            InitializeComponent();




          

            ListBox listBox1 = new ListBox();
            listBox1.Location = new Point(10, 10);
            listBox1.Size = new Size(200, 200);

            //this.Controls.Add(listBox1);

            _keyboardHook = new KeyboardHook();
            _keyboardHook.Install();

            _keyboardHook.KeyDown += (sender, e) =>
            {
                //KeyDownValue += e.KeyCode;
                //txtKeyDown.Text = KeyDownValue;
                //SaveFile(KeyDownValue);
                //listBox1.Items.Add("KeyDown: " + e.KeyCode);

                //listBox1.SelectedIndex = listBox1.Items.Count - 1;
            };

            _keyboardHook.KeyUp += (sender, e) =>
            {
                KeyDownValue += e.KeyCode;
                txtKeyDown.Text = KeyDownValue;
                SaveFile(KeyDownValue);
                //listBox1.Items.Add("KeyUp: " + e.KeyCode);

                //listBox1.SelectedIndex = listBox1.Items.Count - 1;
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var httpDownload = new HttpSession();
            var sUrl = "";
            var sPost = "";
            /////
            sUrl = txtUrl.Text;
            sPost = "";
            CookieCollection Cookie = new CookieCollection();
          
            var sContent = httpDownload.PostMethodDownload(sUrl, sPost, false, false, false, false);

            txtContent.Text = sContent;

        }

        public void SaveFile(string Content)
        {
            //FileInfo ofile = new FileInfo(Application.ExecutablePath + "\\output.txt");
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\output.txt", false);
            
            sw.Write(Content);
            sw.Close();

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            txtKeyDown.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var httpDownload = new HttpSession();
            var sUrl = txtURLPost.Text;// "http://www.hnammobile.com/api/vote?item_id=79";
            var sPost = "";
            /////
            //sUrl = txtUrl.Text;
            sPost = "";
            httpDownload.PostMethodDownload(sUrl, sPost, true, false, false, false);
            count++;
            lbCount.Text = count.ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PhotoshopFile.PsdFile pfile = new PhotoshopFile.PsdFile();
            pfile.Load("D:/1.psd");
            var a = 3;
        }

    }
}
