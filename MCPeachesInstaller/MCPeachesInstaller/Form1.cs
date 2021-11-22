using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;
using System.Net;

namespace MCPeachesInstaller
{
    public partial class Form1 : Form
    {
        private const string httpAddress = "http://mcpeaches.zapto.org/";
        private string saveLocation;
        private string[] urlDownloads;
        private WebClient downloadClient;
        private bool fileDownloaded;
        private int fileIndex = 0;
        public Form1()
        {
            InitializeComponent();
            pathBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MCPeaches\\";
            downloadWorker.WorkerReportsProgress = true;
            downloadClient = new WebClient();
            
        }

        private void installBtn_Click(object sender, EventArgs e)
        {
            if (installBtn.Text == "Install")
            {
                saveLocation = pathBox.Text;
                if(!Directory.Exists(saveLocation))
                    Directory.CreateDirectory(saveLocation);
                downloadClient.DownloadFileCompleted += DownloadComplete;
                downloadClient.DownloadProgressChanged += DownloadProgress;
                pathBox.Visible = false;
                pathLbl.Visible = false;
                desktopCheck.Visible = false;
                startMenuCheck.Visible = false;
                browseBtn.Visible = false;
                installBtn.Visible = false;
                installBtn.Text = "Finish";
                percentLbl.Visible = true;
                progressBar.Visible = true;
                fileLbl.Visible = true;
                fileNameLbl.Visible = true;
                downloadWorker.RunWorkerAsync();
            }
            else
            {
                Application.Exit();
            }
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                pathBox.Text = folderBrowserDialog1.SelectedPath + "\\MCPeaches";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            Location = new Point(Location.X, Location.Y - (Location.Y / 4));
            
        }
        public void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            fileDownloaded = true;
        }
        public void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            percentLbl.Text = e.ProgressPercentage + "%";
        }

        private void downloadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var fetchListed = false;
            while (!fetchListed)
                    {
                try
                {
                    urlDownloads = downloadClient.DownloadString(httpAddress + "files/launcher/download_list.txt").Split('\n');
                    fetchListed = true;
                }
                catch
                {

                }
            }
            var downloadCompleted = false;
            while (fileIndex < urlDownloads.Length && urlDownloads[fileIndex].Trim(' ') != String.Empty)
            {
                fileDownloaded = false;
                worker.ReportProgress(fileIndex + 1);
                while (!fileDownloaded)
                {

                }
                fileIndex++;
            }
        }

        private void downloadWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var splitted = urlDownloads[fileIndex].Split('/');
            var fileName = splitted[splitted.Length - 1].Replace("%20", " ").Trim('\r');
            downloadClient.DownloadFileAsync(new Uri(urlDownloads[fileIndex]), saveLocation + fileName);
            fileNameLbl.Text = saveLocation + fileName;
            fileLbl.Text = e.ProgressPercentage + "/" + urlDownloads.Count();
        }

        private void downloadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        { 
            installBtn.Visible = true;
        }
    }
}
