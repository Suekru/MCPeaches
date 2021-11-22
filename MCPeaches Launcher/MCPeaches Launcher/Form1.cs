using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using Microsoft.VisualBasic.Devices;
using MineStatLib;
using System.IO.Compression;
using System.Drawing.Text;

namespace MCPeaches_Launcher
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font copperplate;
        News news;
        ServerStatus serverStats;
        Downloader downloader;

        private const string serverAddress = "mcpeaches.zapto.org";
        private const string httpAddress = "http://mcpeaches.zapto.org";
        private const string ramFile = "SelectedRam.peaches";

        MineStat serverStatus = new MineStat(serverAddress, 25565);
        
        int totalRamMB;
        int selectedRam;

        private Point lastLocation;

        private bool mouseDown;
        private bool upToDate = true;
        private bool mouseSliderDown = false;

        public Form1()
        {
            InitializeComponent();
            byte[] fontData = Properties.Resources.Copperplate_Gothic_Bold_Regular;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.Copperplate_Gothic_Bold_Regular.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.Copperplate_Gothic_Bold_Regular.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            copperplate = new Font(fonts.Families[0], 16.0F);

            exitBtn.Size = new Size(ShadedBar.Height, ShadedBar.Height);
            exitBtn.Location = new Point(ShadedBar.Width - exitBtn.Width, 0);
            minBtn.Size = new Size(ShadedBar.Height, ShadedBar.Height);
            minBtn.Location = new Point(ShadedBar.Width - (minBtn.Width * 2), 0);
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;

            GetServerStatsWorker.WorkerReportsProgress = true;
            VersionWorker.WorkerReportsProgress = true;
            DownloadWorker.WorkerReportsProgress = true;
            UnzipUIWorker.WorkerReportsProgress = true;
            GetServerStatsWorker.RunWorkerAsync();
            GetNewsWorker.RunWorkerAsync();
            VersionWorker.RunWorkerAsync();
            LoadInfo();

            LauncherUpdateWorker.RunWorkerAsync();

            playBtn.Font = new Font(copperplate.FontFamily, 24, FontStyle.Bold);
            statsOnline.Font = copperplate;
            statsPlayers.Font = copperplate;
            statsOnline.Font = copperplate;
            versionLbl.Font = new Font(copperplate.FontFamily, 10, FontStyle.Regular);
        }

        private void LoadInfo()
        {
            var ram = new ComputerInfo().TotalPhysicalMemory;
            totalRamMB = (int)(ram / (1024 * 1024));
            totalRamMB = (int)(totalRamMB - (totalRamMB * .2));
            int step = totalRamMB / 250;
            selectedRam = 0;
            try { selectedRam = Int32.Parse(File.ReadAllText(ramFile).Trim()); }
            catch (Exception)
            {
                File.Create(ramFile).Close();
                File.WriteAllText(ramFile, totalRamMB.ToString());
                selectedRam = totalRamMB;
            }
            int sliderLocationX = 0;
            if (selectedRam >= totalRamMB)
            {
                selectedRam = totalRamMB;
                sliderLocationX = sliderBar.Right - sliderAnchor.Width;
            }
            else if (selectedRam <= 0)
            {
                selectedRam = 0;
                sliderLocationX = sliderBar.Location.X;
            }
            else sliderLocationX = (selectedRam / step) + sliderBar.Left;
            ramMbLbl.Text = selectedRam + "/" + totalRamMB;
            sliderAnchor.Location = new Point(sliderLocationX, sliderBar.Top - (sliderAnchor.Height/3));
        }

        private void sliderAnchor_MouseDown(object sender, MouseEventArgs e)
        {
            mouseSliderDown = true;
            sliderAnchor.BackgroundImage = Properties.Resources.circle_down;
        }

        private void sliderAnchor_MouseMove(object sender, MouseEventArgs e)
        {
            var clear = false;
            var pointX = Cursor.Position.X - Location.X;
            var min = sliderBar.Left;
            var max = sliderBar.Right - sliderAnchor.Width;
            if (pointX >= min && pointX <= max)
            {
                clear = true;
            }
            else if (pointX < min && mouseSliderDown)
            {
                ramMbLbl.Text = 0 + "/" + totalRamMB;
                sliderAnchor.Location = new Point(min, sliderBar.Top - (sliderAnchor.Height / 3));
            }
            else if (pointX > max && mouseSliderDown)
            {
                ramMbLbl.Text = totalRamMB + "/" + totalRamMB;
                sliderAnchor.Location = new Point(max, sliderBar.Top - (sliderAnchor.Height / 3));
            }
            if (mouseSliderDown && clear)
            {
                sliderAnchor.Location = new Point(pointX, sliderBar.Top - (sliderAnchor.Height / 3));

                if (sliderAnchor.Location.X == max)
                {
                    ramMbLbl.Text = totalRamMB + "/" + totalRamMB;
                }
                else
                {
                    setRamSlider(sliderAnchor.Location.X);
                }
                this.Update();
            }
        }

        private void setRamSlider(int locationX)
        {
            int step = (totalRamMB / sliderBar.Width);
            selectedRam = (locationX - sliderBar.Left) * step;
            if (selectedRam > totalRamMB)
                selectedRam = totalRamMB;
            ramMbLbl.Text = selectedRam + "/" + totalRamMB;
        }

        private void sliderAnchor_MouseUp(object sender, MouseEventArgs e)
        {
            mouseSliderDown = false;
            sliderAnchor.BackgroundImage = Properties.Resources.circle;
            File.WriteAllText(ramFile, ramMbLbl.Text.Split('/')[0]);
        }

        //Gets the status of the server and it's players. Background worker keeps the info up to date.
        
        private void GetServerStatsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            serverStats = new ServerStatus(serverStatus, serverAddress, statsOnline, statsPlayers);
            serverStats.ServerStatsWorker(sender);
        }
        private void GetServerStatsWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            serverStats.setServerStatText(e.ProgressPercentage);
        }
        



        //News Section
        private void GetNewsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            news = new News(this, newsPanel, newsFetchLbl, serverStatus, copperplate);
            news.NewsWorker();
        }
        private void GetNewsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            news.FetchNews();
        }
        

        //Moves Application around screen when clicking and dragging the shaded bar at the top
        private void ShadedBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void ShadedBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void ShadedBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        //Basic Controls and UI Responses

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void minBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void exitBtn_MouseEnter(object sender, EventArgs e)
        {
            exitBtn.BackgroundImage = Properties.Resources.Close_hover;
        }

        private void exitBtn_MouseLeave(object sender, EventArgs e)
        {
            exitBtn.BackgroundImage = Properties.Resources.Close;
        }

        private void minBtn_MouseEnter(object sender, EventArgs e)
        {
            minBtn.BackgroundImage = Properties.Resources.min_hover;
        }

        private void minBtn_MouseLeave(object sender, EventArgs e)
        {
            minBtn.BackgroundImage = Properties.Resources.min;
        }

        private void playBtn_MouseEnter(object sender, EventArgs e)
        {
            playBtn.Location = new Point(playBtn.Location.X - 10, playBtn.Location.Y - 5);
            playBtn.Font = new Font(copperplate.FontFamily, 28, FontStyle.Bold);
        }

        private void playBtn_MouseLeave(object sender, EventArgs e)
        {
            playBtn.Location = new Point(playBtn.Location.X + 10, playBtn.Location.Y + 5);
            playBtn.Font = new Font(copperplate.FontFamily, 24, FontStyle.Bold);
        }
        private void reDownloadBtn_MouseEnter(object sender, EventArgs e)
        {
            reDownloadBtn.BackgroundImage = Properties.Resources.download_hover;
            reDownloadBtn.Location = new Point(reDownloadBtn.Location.X, reDownloadBtn.Location.Y - 1);
            reDownloadBtn.Size = new Size(reDownloadBtn.Width + 3, reDownloadBtn.Height + 3);
        }

        private void reDownloadBtn_MouseLeave(object sender, EventArgs e)
        {
            reDownloadBtn.BackgroundImage = Properties.Resources.download;
            reDownloadBtn.Location = new Point(reDownloadBtn.Location.X, reDownloadBtn.Location.Y + 1);
            reDownloadBtn.Size = new Size(reDownloadBtn.Width - 3, reDownloadBtn.Height - 3);
        }

        private void reDownloadBtn_Click(object sender, EventArgs e)
        {
            var confirmBox = new Reinstall(StartUpdate);
            confirmBox.StartPosition = FormStartPosition.CenterParent;
            confirmBox.ShowDialog();
        }
        private void playBtn_Click(object sender, EventArgs e)
        {
            playBtn.Enabled = false;
            if (upToDate)
            {
                StartMinecraft();
            }
            else
            {
                StartUpdate();
            }
        }
        private void StartUpdate()
        {
            downloader.Update();
            DownloadWorker.RunWorkerAsync();
        }
        private void StartMinecraft()
        {
            var profileJson = ".Minecraft\\launcher_profiles.json";
            var profiles = File.ReadAllLines(profileJson);
            var foundForge = false;
            var content = "";
            foreach (var line in profiles)
            {
                if (foundForge)
                {
                    if (line.Split(':')[0].Trim() == "\"javaArgs\"")
                    {
                        content += "      \"javaArgs\" : \"-Xmx" + File.ReadAllText(ramFile) + "M -XX:+UnlockExperimentalVMOptions -XX:+UseG1GC -XX:G1NewSizePercent=20 -XX:G1ReservePercent=20 -XX:MaxGCPauseMillis=50 -XX:G1HeapRegionSize=32M\",\n";
                    }
                    else content += line + '\n';
                }
                else
                {
                    if (line.Trim() == "\"forge\" : {")
                        foundForge = true;
                    content += line + '\n';
                }
            }
            File.WriteAllText(profileJson, content);
            Thread.Sleep(1000);
            if (Int32.Parse(File.ReadAllText(ramFile)) == 0)
            {
                MessageBox.Show("Please use the slider below the play button to select ram amount. " +
                    "\nIf you're unsure, just slide it all the way to the right.", "Select Ram Usage");
            }
            else
            {
                var currentDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                content = "\".Minecraft\\Minecraft.exe\" --workDir \"" + currentDir + "\\.Minecraft\"";

                var cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine(content);
                Application.Exit();
            }
        }

        private void VersionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            downloader = new Downloader(dBarBack, dBarTop, versionLbl, playBtn, httpAddress, StartMinecraft);
            downloader.VersionWorker(sender);
            upToDate = downloader.UpToDate;
        }

        private void VersionWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            downloader.VersionWorkerProgress(e.ProgressPercentage);
        }

        private void UnzipUIWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            downloader.UnzipUIWorker(sender);
        }

        private void UnzipUIWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            downloader.UnzipUIProgress(e.ProgressPercentage);
        }

        private void DownloadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            downloader.DownloadWorker(sender);
        }

        private void DownloadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            downloader.DownloadWorkerComplete();
        }

        private void DownloadWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (downloader.DownloadWorkerProgress(e.ProgressPercentage, e.UserState as string))
                UnzipUIWorker.RunWorkerAsync();
        }
        private void LauncherUpdateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var versionClient = new WebClient();
            var localVersion = 0d;
            var onlineVersion = 0d;
            var fetched = false;
            while (!fetched)
            {
                try
                {
                    onlineVersion = Double.Parse(versionClient.DownloadString(httpAddress + "/files/launcherVersion.txt"));
                    fetched = true;
                }
                catch (Exception) { }
            }

            if (File.Exists("launcherVersion.peaches"))
            {
                localVersion = Double.Parse(File.ReadAllText("launcherVersion.peaches"));
            }
            else
            {
                File.Create("launcherVersion.peaches").Close();
                File.WriteAllText("launcherVersion.peaches", "1.0");
            }

            if(localVersion < onlineVersion)
            {
                var results = MessageBox.Show("There is an update for the MCPeaches Launcher\nWould you like to update now?", "Updater", MessageBoxButtons.YesNo);
                if(results == DialogResult.Yes)
                {
                    Process.Start("MCPeachesUpdater.exe");
                    Application.Exit();
                }
            }
        }
    }
}
