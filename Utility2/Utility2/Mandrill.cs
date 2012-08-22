using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility2
{
    public partial class Mandrill : Form
    {
        public Mandrill()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var httpDownload = new HttpSession();

            var sPost = "key=64a5889c-e31d-4dc4-8fd0-edcc0f45f37d";

            string sUrl1 = "https://mandrillapp.com/api/1.0/tags/all-time-series.json";
            httpDownload.PostMethodDownload(sUrl1, sPost, true, false, false, true);

        }
    }
}
