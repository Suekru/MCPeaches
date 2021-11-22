using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MCPeaches_Launcher
{
    internal class Downloader
    {
        PictureBox dBarBack;
        PictureBox dBarTop;

        Label versionLbl;
        Label playBtn;

        string httpAddress;

        Action StartMinecraft;

        Double localVersion;
        Double serverVersion;
        
        List<string> unZipVersions;

        bool downloadComplete;
        bool unzipComplete;
        bool upToDate;

        WebClient downloadClient;

        
        public Downloader(PictureBox dBarBack, PictureBox dBarTop,Label versionLbl, Label playBtn, string httpAddress, Action StartMinecraft)
        {
            this.dBarBack = dBarBack;
            this.dBarTop = dBarTop;
            this.versionLbl = versionLbl;
            this.playBtn = playBtn;
            upToDate = false;
            this.httpAddress = httpAddress;
            unZipVersions = new List<string>();
            this.StartMinecraft = StartMinecraft;
            downloadClient = new WebClient();
            localVersion = 0.9;
            serverVersion = 1;
        }
        public void Update()
        {
            localVersion = Double.Parse(File.ReadAllText("version.peaches"));
            versionLbl.ForeColor = Color.White;
            versionLbl.TextAlign = ContentAlignment.BottomCenter;
            dBarBack.Visible = true;
            downloadClient = new WebClient();
            downloadClient.DownloadFileCompleted += DownloadComplete;
            downloadClient.DownloadProgressChanged += DownloadProgress;
            
        }
        public void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            dBarTop.Size = new Size(0, dBarBack.Height);
            downloadComplete = true;
        }
        public void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            dBarTop.Size = new Size(e.ProgressPercentage * (dBarBack.Width / 100), dBarBack.Height);
            var phrase = versionLbl.Text.Split('\n')[0];
            versionLbl.Text = phrase + "\n" + e.ProgressPercentage + "%";
        }

        public void DownloadWorker(object sender)
        {
            var worker = sender as BackgroundWorker;
            for (double dVersion = localVersion; dVersion < serverVersion; dVersion += 0.1d)
            {
                downloadComplete = false;
                var stringVersion = Math.Round(dVersion + 0.1d, 1).ToString();
                if (stringVersion.Length < 3)
                    stringVersion += ".0";
                unZipVersions.Add(stringVersion);
                worker.ReportProgress(0, stringVersion);
                while (!downloadComplete)
                {

                }
            }
            unzipComplete = false;
            worker.ReportProgress(1);
            for (int i = 0; i < unZipVersions.Count; i++)
            {
                ZipFile.ExtractToDirectory(".Minecraft\\" + unZipVersions[i] + ".zip", ".Minecraft", true);
                File.Delete(".Minecraft/" + unZipVersions[i] + ".zip");
                File.WriteAllText("version.peaches", unZipVersions[i]);
            }
        }
        public bool DownloadWorkerProgress(int progress, string userState)
        {
            if (progress == 0)
            {
                var stringVersion = userState;
                versionLbl.Text = "Downloading update " + stringVersion + "\n";
                downloadClient.DownloadFileAsync(new Uri(httpAddress + "/files/" + stringVersion + ".zip"), ".Minecraft\\" + stringVersion + ".zip");
                return false;
            }
            else
            {
                dBarBack.Visible = false;
                dBarTop.Visible = false;
                versionLbl.Text = "Installing...\nPlease Wait";
                return true;
            }
        }
        public void DownloadWorkerComplete()
        {
            unzipComplete = true;
            versionLbl.ForeColor = Color.Lime;
            versionLbl.Text = "Version up to date";
            dBarBack.Visible = false;
            upToDate = true;
            playBtn.Enabled = true;
            StartMinecraft.Invoke();
        }
        public void UnzipUIWorker(object sender)
        {
            var worker = sender as BackgroundWorker;
            var i = 0;
            while (!unzipComplete)
            {
                worker.ReportProgress(i);
                i++;
                if (i == 4)
                    i = 0;
                Thread.Sleep(500);
            }
        }
        public void UnzipUIProgress(int progress)
        {
            switch (progress)
            {
                case 0: versionLbl.Text = "Installing\n Please Wait"; break;
                case 1: versionLbl.Text = "Installing.\nPlease Wait"; break;
                case 2: versionLbl.Text = "Installing..\nPlease Wait"; break;
                case 3: versionLbl.Text = "Installing...\nPlease Wait"; break;
            }
        }

        public void VersionWorker(object sender)
        {
            var versionClient = new WebClient();
            var worker = sender as BackgroundWorker;
            var fetched = false;
            while (!fetched)
            {
                try
                {
                    serverVersion = Double.Parse(versionClient.DownloadString(httpAddress + "/files/version.txt").Trim());
                    if (!File.Exists("version.peaches"))
                    {
                        File.Create("version.peaches").Close();
                        File.WriteAllText("version.peaches", "0.9");
                    }
                    if (!Directory.Exists(".Minecraft"))
                    {
                        Directory.CreateDirectory(".Minecraft");
                        File.WriteAllText("version.peaches", "0.9");
                    }
                    localVersion = Double.Parse(File.ReadAllText("version.peaches"));
                    fetched = true;
                }
                catch (Exception e)
                {
                    versionLbl.Text = e.Message.ToString();
                }
            }

            if (localVersion < serverVersion)
            {
                upToDate = false;
                worker.ReportProgress(1);
            }
            if (upToDate)
            {
                worker.ReportProgress(0);
            }
        }
        public void VersionWorkerProgress(int progress)
        {
            if (progress == 0)
            {
                versionLbl.Text = "Version up to date";
                versionLbl.ForeColor = Color.Lime;
            }
            else
            {
                versionLbl.Text = "Version out of date\nPress play to update";
                versionLbl.ForeColor = Color.Orange;
            }
        }
        public bool UpToDate => upToDate;
    }
}
