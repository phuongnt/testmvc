using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Psd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Endogine.Codecs.Photoshop.Document psd = new Endogine.Codecs.Photoshop.Document("D:/2.psd");
            int a = 0;
            foreach (var item in psd.Layers)
            {

                Bitmap bm = psd.Layers[a].Bitmap;
                if (bm != null)
                {

                    bm.Save("D://ps//hehe" + "_" + a.ToString() + ".jpg");
                }
                a++;
            }
        }
    }
}
