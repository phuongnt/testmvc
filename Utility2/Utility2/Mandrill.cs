using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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

            var sPost = "{\"key\": \"64a5889c-e31d-4dc4-8fd0-edcc0f45f37d\"}";// "key=64a5889c-e31d-4dc4-8fd0-edcc0f45f37d";

            string sUrl1 = "https://mandrillapp.com/api/1.0/tags/all-time-series.json";
            string sUrl2 = "https://mandrillapp.com/api/1.0/users/info.json";
            httpDownload.sContentType = "application/json";
            httpDownload._iTimeOut = 3000;
            httpDownload.sAccept = "application/json";
         //   WebHeaderCollection.KeysCollection test = new System.Collections.Specialized.NameObjectCollectionBase.KeysCollection();
           
            //httpDownload.Headers.Add("Accept", "application/json"); 
            //httpDownload.Headers["Content-Type"] = "application/json";
            
            httpDownload.PostMethodDownload(sUrl2, sPost, true, false, true, true);
            
        }
        public string PostMethodDownload(string sUrl, string sPost)
        {
            WebRequest request = WebRequest.Create(sUrl);
            request.Method = "POST";
            string postData = sPost;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";          
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
    }
}
