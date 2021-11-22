using System.Net;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;

namespace MCPeachesUpdater
{
    public partial class Form1 : Form
    {
        private string saveLocation;
        WebClient downloadClient;
        string[] fileLinks;
        int fileIndex;
        bool fileDownloaded;
        string version;
        public Form1()
        {
            InitializeComponent();
            downloadWorker.WorkerReportsProgress = true;
            downloadWorker.WorkerSupportsCancellation = true;
            saveLocation = Path.GetDirectoryName(Application.ExecutablePath) + "\\";
            downloadClient = new WebClient();
            downloadClient.DownloadFileCompleted += DownloadComplete;
            downloadClient.DownloadProgressChanged += DownloadProgress;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            downloadWorker.RunWorkerAsync();
        }
        public void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            fileDownloaded = true;
            Thread.Sleep(100);
        }
        public void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            percentLbl.Text = e.ProgressPercentage + "%";
        }
        private void downloadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var fetched = false;

            while (!fetched)
            {
                try
                {
                    version = downloadClient.DownloadString("http://mcpeaches.zapto.org/files/launcherVersion.txt");
                    fileLinks = downloadClient.DownloadString("http://mcpeaches.zapto.org/files/launcher/download_list.txt").Split("\n");
                    fetched = true;
                }
                catch (Exception) { }
            }

            while (fileIndex < fileLinks.Length && fileLinks[fileIndex].Trim(' ') != String.Empty)
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
            var splitted = fileLinks[fileIndex].Split('/');
            var fileName = splitted[splitted.Length - 1].Replace("%20", " ").Trim('\r');
            downloadClient.DownloadFileAsync(new Uri(fileLinks[fileIndex]), saveLocation + fileName);
            fileLbl.Text = fileName;
            fileCount.Text = e.ProgressPercentage + "/" + fileLinks.Length;
        }

        private void downloadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            File.WriteAllText("launcherVersion.peaches", version);
            Process.Start("MCPeaches Launcher.exe");
            Application.Exit();
        }
        public static bool IsFileReady(string filename)
        {
            // If the file can be opened for exclusive access it means that the file
            // is no longer locked by another process.
            try
            {
                using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                    return inputStream.Length > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var window = MessageBox.Show("Closing while updating the app could break your install" +
                " which would require you to reinstall the launcher?\nClick no to continue updating","Are you sure?", MessageBoxButtons.YesNo);

            e.Cancel = (window == DialogResult.No);
        }
    }
}