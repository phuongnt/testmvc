using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Utility2
{
    public partial class DownloadFile : Form
    {

        string targetFolder = "D://DI";
        string sUrl = "";
        string ckLoadLink = "/ckfinder/core/connector/aspx/connector.aspx?command=[[0]]&type=[[1]]&currentFolder=[[2]]";
        public DownloadFile()
        {
            InitializeComponent();
        }
        public string getCookieDestinet(string sUrl1, ref CookieCollection _cookies)
        {
            string destinet = "";
            var httpDownload = new HttpSession();

            var sPost = "dnn$ctr$Signin$Signin_textboxUsername=host" +
                        "&dnn$ctr$Signin$Signin_textboxPassword=guidedes10no" +
                        "&dnn$ctr$Signin$cmdLogin=Logg%20inn";

            var sContent = httpDownload.GetMethodDownload(sUrl1, true, false, false, true);

            // step 2
            _cookies = httpDownload.Cookies;

            string strRegex = "<input\\s+type=.{1}hidden.{1}\\s+name=.{1}__VIEWSTATE.{1}\\s+id=.{1}__VIEWSTATE.{1}\\s+value=.{1}([^.\"]+)";

            Regex rxGetViewState = new Regex(strRegex);
            Match mViewState = rxGetViewState.Match(sContent);

            string sViewState = mViewState.Groups[1].Value;//.Replace("/", "%2F").Replace("=", "%3D");
            sPost += "&__VIEWSTATE=" + sViewState;
            httpDownload.PostMethodDownload(sUrl1, sPost, true, false, false, true);

            if (httpDownload.Cookies[".DESTINET"] != null)
            {
                destinet = httpDownload.Cookies[".DESTINET"].Value;
            }
            else
            {
                if (txtCookie.Text != "")
                {
                    Cookie c1 = new Cookie(".DESTINET", txtCookie.Text);
                    c1.Domain = sUrl.Replace("http://", "");
                    c1.Expired = false;
                    c1.Expires = DateTime.Now.AddMinutes(100);
                    httpDownload.Cookies.Add(c1);

                }
            }



            _cookies = httpDownload.Cookies;
            return destinet;
        }


        public void DownloadRecusive(ref HttpSession httpDownload, string ckLink, string parentFolder)
        {
            var rootXML = httpDownload.GetMethodDownload(ckLink, true, false, false, true);
            XmlDocument _doc = new XmlDocument();
            _doc.LoadXml(rootXML);
            string rootFolderName = _doc.GetElementsByTagName("CurrentFolder")[0].Attributes[0].Value;
            XmlNodeList listFolder = _doc.GetElementsByTagName("Folder");
            //download file for current folder
            string ckGetFileLink = sUrl + ckLoadLink.Replace("[[0]]", "GetFiles").Replace("[[1]]", "Portalens%20rotmappe").Replace("[[2]]", parentFolder);
            downloadFile(ref httpDownload, ckGetFileLink);

            //get folders
            for (int _i = 0; _i < listFolder.Count; ++_i)
            {
                string FolderName = listFolder[_i].Attributes[0].Value;
                WebClient webClient = new WebClient();
                DirectoryInfo dir = new DirectoryInfo(targetFolder + parentFolder.Replace("%2F", "/") + FolderName);
                if (!dir.Exists)
                {
                    dir.Create();

                }
                bool hasChild = false;
                hasChild = bool.Parse(listFolder[_i].Attributes[1].Value);

                if (hasChild)
                {
                    string tempCKForderLink = sUrl + ckLoadLink.Replace("[[0]]", "GetFolders").Replace("[[1]]", "Portalens%20rotmappe").Replace("[[2]]", parentFolder + FolderName.Replace(" ", "%20") + "%2F");
                    DownloadRecusive(ref httpDownload, tempCKForderLink, parentFolder + FolderName + "%2F");
                }
                else
                {
                    //download file for current forder if it has not child
                    string ckGetFileLink1 = sUrl + ckLoadLink.Replace("[[0]]", "GetFiles").Replace("[[1]]", "Portalens%20rotmappe").Replace("[[2]]", parentFolder + FolderName + "%2F");
                    downloadFile(ref httpDownload, ckGetFileLink1);
                }

            }

        }
        public void downloadFile(ref HttpSession httpDownload, string ckLink)
        {
            var rootXML = httpDownload.GetMethodDownload(ckLink, true, false, false, true);
            XmlDocument _doc = new XmlDocument();
            _doc.LoadXml(rootXML);
            string rootFolderName = _doc.GetElementsByTagName("CurrentFolder")[0].Attributes[0].Value;
            string fullFolderName = _doc.GetElementsByTagName("CurrentFolder")[0].Attributes[1].Value;
            XmlNodeList listFile = _doc.GetElementsByTagName("File");
            StreamWriter sw = new StreamWriter(targetFolder + rootFolderName + rootFolderName.Replace("/", "") + ".txt");



            for (int _i = 0; _i < listFile.Count; ++_i)
            //for (int _i = listFile.Count-1; _i < listFile.Count; ++_i)
            {
                try
                {
                    if (listFile[_i].Attributes[0] != null)
                    {
                        string filename = listFile[_i].Attributes[0].Value;
                        if (filename.Contains("Cache"))
                        {
                            int a = 3;
                        }
                        txtStatus.Text = "download file: " + System.Environment.NewLine +
                          sUrl + fullFolderName + filename + System.Environment.NewLine + txtStatus.Text + System.Environment.NewLine;
                        sw.WriteLine(sUrl + fullFolderName + filename);
                        Application.DoEvents();
                        if (checkOnlyGetLink.Checked == false)
                        {
                            if (!System.IO.File.Exists(targetFolder + rootFolderName + filename))
                            {
                                
                                if (checkUseIDM.Checked == true)
                                {

                                    if (rootFolderName.Length > 1)
                                    {

                                        downloadByIDM(sUrl + fullFolderName + filename, targetFolder + rootFolderName.Substring(0, rootFolderName.Length - 1));
                                    }
                                    else {
                                        downloadByIDM(sUrl + fullFolderName + filename, targetFolder);
                                    }
                                    Thread.Sleep(1000);
                                  
                                }
                                else
                                {
                                    WebClient webClient = new WebClient();
                                    webClient.DownloadFile(sUrl + fullFolderName + filename, targetFolder + rootFolderName + filename);
                                }
                 
                            }
                        }


                    }

                }
                catch (Exception ex)
                {
                    txtStatus.Text = ex.Message + System.Environment.NewLine + txtStatus.Text + System.Environment.NewLine;
                    Application.DoEvents();
                }
            }
            sw.Close();

        }
        private void btDownload_Click(object sender, EventArgs e)
        {
            if (checkUseIDM.Checked == true)
            {
                if (!System.IO.File.Exists(txtIDMLink.Text))
                {
                    MessageBox.Show("IDM errror");
                    return;
                }
            }

            timer1.Start();
            targetFolder = txtFolder.Text;
            if (!System.IO.Directory.Exists(targetFolder))
            {
                System.IO.Directory.CreateDirectory(targetFolder);
            }
            string user = "host";
            string password = "guidedes10no";
            if (txtUser.Text.Trim() != null) { password = txtUser.Text; }
            if (txtPass.Text.Trim() != null) { user = txtPass.Text; }
            sUrl = txtDomain.Text;
            var httpDownload = new HttpSession();
            CookieCollection _cookies = new CookieCollection();
            getCookieDestinet(sUrl + "/admin", ref _cookies);
            httpDownload.Cookies = _cookies;

            string rootLink = sUrl + ckLoadLink.Replace("[[0]]", "GetFolders").Replace("[[1]]", "Portalens%20rotmappe").Replace("[[2]]", "%2F");// "/ckfinder/core/connector/aspx/connector.aspx?command=GetFolders&type=Portalens%20rotmappe&currentFolder=%2F";
            DownloadRecusive(ref httpDownload, rootLink, "%2F");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtFolder.Text = folderBrowserDialog1.SelectedPath;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();

                p.StartInfo.FileName = txtFolder.Text;

                p.Start();
            }
            catch
            { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Application.DoEvents();
        }


        public void downloadByIDM(string downloadLink,string SaveToFolder)
        {
            
            string IDMURL = txtIDMLink.Text;// "C:\\Program Files (x86)\\Internet Download Manager\\IDMan.exe";
            System.Diagnostics.Process.Start(IDMURL, " /d \""+ downloadLink.Replace(" ","%20")+"\" /s /n /a /p \""+ SaveToFolder.Replace("/","\\") + "\"" );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtIDMLink.Text, " /d \"http://www.sandnes2160.no/Portals/111/1697542912/resources/Cache-C38B5C56781E6958E9C83570EE3FE7F3.jpg\" /n /a /p \"D:/con me\"");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string filename = ".txt";
            var rootFolder = txtFolder.Text;
            DirectoryInfo root = new DirectoryInfo(rootFolder);
            
            var aa = root.GetDirectories().Length;
            checkRecusive(rootFolder, "","");
           // checkByTextFile(txtFolder.Text + "\\" + filename,txtFolder.Text);

        }
        public void checkRecusive(string parentPath,string Folder,string parentFolder)
        {
          

            checkByTextFile(parentPath +  "/" + parentFolder + Folder + ".txt", parentPath + Folder);
            DirectoryInfo root = new DirectoryInfo(parentPath);
            if (root.GetDirectories().Length > 0)
            {
                foreach (DirectoryInfo item in root.GetDirectories())
                {
                    checkRecusive(parentPath + "/" + item.Name, item.Name, Folder);    
                }
                
            }

            
        }
        public void checkByTextFile(string textURL, string folder)
        {
            StreamReader sr = new StreamReader(textURL);
            while (!sr.EndOfStream)
            {
                string filename = sr.ReadLine();
                string localFilename =folder+  filename.Substring(filename.LastIndexOf("/"));
                if (!System.IO.File.Exists(localFilename))
                {
                    string IDMURL = txtIDMLink.Text;// "C:\\Program Files (x86)\\Internet Download Manager\\IDMan.exe";
                    System.Diagnostics.Process.Start(IDMURL, " /d \"" + filename.Replace(" ", "%20") + "\" /n /a /p \"" + folder.Replace("/", "\\") + "\"");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string IDMURL = txtIDMLink.Text;// "C:\\Program Files (x86)\\Internet Download Manager\\IDMan.exe";
            string linkfile = "http://www.sandnes2160.no/Portals/111/malheim skule.txt";
            System.Diagnostics.Process.Start(IDMURL, " /d \"" + linkfile + "\" /n /a /p \"" + "D:xxxx" + "\"");
        }
    }
}
