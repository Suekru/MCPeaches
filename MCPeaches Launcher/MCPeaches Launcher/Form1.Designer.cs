namespace MCPeaches_Launcher
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.ShadedBar = new System.Windows.Forms.PictureBox();
            this.statsOnline = new System.Windows.Forms.Label();
            this.statsPlayers = new System.Windows.Forms.Label();
            this.newsPanel = new System.Windows.Forms.Panel();
            this.newsFetchLbl = new System.Windows.Forms.Label();
            this.sliderBar = new System.Windows.Forms.PictureBox();
            this.sliderAnchor = new System.Windows.Forms.PictureBox();
            this.ramMbLbl = new System.Windows.Forms.Label();
            this.GetServerStatsWorker = new System.ComponentModel.BackgroundWorker();
            this.GetNewsWorker = new System.ComponentModel.BackgroundWorker();
            this.versionLbl = new System.Windows.Forms.Label();
            this.VersionWorker = new System.ComponentModel.BackgroundWorker();
            this.dBarBack = new System.Windows.Forms.PictureBox();
            this.dBarTop = new System.Windows.Forms.PictureBox();
            this.UnzipUIWorker = new System.ComponentModel.BackgroundWorker();
            this.DownloadWorker = new System.ComponentModel.BackgroundWorker();
            this.exitBtn = new System.Windows.Forms.PictureBox();
            this.minBtn = new System.Windows.Forms.PictureBox();
            this.playBtn = new System.Windows.Forms.Label();
            this.reDownloadBtn = new System.Windows.Forms.PictureBox();
            this.LauncherUpdateWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ShadedBar)).BeginInit();
            this.newsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderAnchor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBarBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBarTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reDownloadBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Image = global::MCPeaches_Launcher.Properties.Resources.shade;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 0;
            // 
            // ShadedBar
            // 
            this.ShadedBar.BackColor = System.Drawing.Color.Transparent;
            this.ShadedBar.BackgroundImage = global::MCPeaches_Launcher.Properties.Resources.shade;
            this.ShadedBar.Location = new System.Drawing.Point(0, 0);
            this.ShadedBar.Name = "ShadedBar";
            this.ShadedBar.Size = new System.Drawing.Size(982, 40);
            this.ShadedBar.TabIndex = 1;
            this.ShadedBar.TabStop = false;
            this.ShadedBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShadedBar_MouseDown);
            this.ShadedBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShadedBar_MouseMove);
            this.ShadedBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ShadedBar_MouseUp);
            // 
            // statsOnline
            // 
            this.statsOnline.BackColor = System.Drawing.Color.Transparent;
            this.statsOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statsOnline.ForeColor = System.Drawing.Color.White;
            this.statsOnline.Location = new System.Drawing.Point(702, 113);
            this.statsOnline.Name = "statsOnline";
            this.statsOnline.Size = new System.Drawing.Size(268, 25);
            this.statsOnline.TabIndex = 5;
            this.statsOnline.Text = "Fetching...";
            this.statsOnline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statsPlayers
            // 
            this.statsPlayers.BackColor = System.Drawing.Color.Transparent;
            this.statsPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statsPlayers.ForeColor = System.Drawing.Color.White;
            this.statsPlayers.Location = new System.Drawing.Point(702, 154);
            this.statsPlayers.Name = "statsPlayers";
            this.statsPlayers.Size = new System.Drawing.Size(268, 62);
            this.statsPlayers.TabIndex = 6;
            this.statsPlayers.Text = "Players Online: ";
            this.statsPlayers.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // newsPanel
            // 
            this.newsPanel.AutoScroll = true;
            this.newsPanel.BackColor = System.Drawing.Color.Transparent;
            this.newsPanel.BackgroundImage = global::MCPeaches_Launcher.Properties.Resources.newsShade;
            this.newsPanel.Controls.Add(this.newsFetchLbl);
            this.newsPanel.Location = new System.Drawing.Point(0, 40);
            this.newsPanel.Name = "newsPanel";
            this.newsPanel.Size = new System.Drawing.Size(696, 465);
            this.newsPanel.TabIndex = 8;
            // 
            // newsFetchLbl
            // 
            this.newsFetchLbl.AutoSize = true;
            this.newsFetchLbl.BackColor = System.Drawing.Color.Transparent;
            this.newsFetchLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newsFetchLbl.ForeColor = System.Drawing.Color.White;
            this.newsFetchLbl.Location = new System.Drawing.Point(286, 215);
            this.newsFetchLbl.Name = "newsFetchLbl";
            this.newsFetchLbl.Size = new System.Drawing.Size(124, 29);
            this.newsFetchLbl.TabIndex = 12;
            this.newsFetchLbl.Text = "Fetching...";
            this.newsFetchLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sliderBar
            // 
            this.sliderBar.BackColor = System.Drawing.Color.Transparent;
            this.sliderBar.BackgroundImage = global::MCPeaches_Launcher.Properties.Resources.shade;
            this.sliderBar.Location = new System.Drawing.Point(702, 450);
            this.sliderBar.Name = "sliderBar";
            this.sliderBar.Size = new System.Drawing.Size(268, 10);
            this.sliderBar.TabIndex = 9;
            this.sliderBar.TabStop = false;
            // 
            // sliderAnchor
            // 
            this.sliderAnchor.BackColor = System.Drawing.Color.Transparent;
            this.sliderAnchor.BackgroundImage = global::MCPeaches_Launcher.Properties.Resources.circle;
            this.sliderAnchor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sliderAnchor.Location = new System.Drawing.Point(700, 445);
            this.sliderAnchor.Name = "sliderAnchor";
            this.sliderAnchor.Size = new System.Drawing.Size(20, 20);
            this.sliderAnchor.TabIndex = 10;
            this.sliderAnchor.TabStop = false;
            this.sliderAnchor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sliderAnchor_MouseDown);
            this.sliderAnchor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sliderAnchor_MouseMove);
            this.sliderAnchor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sliderAnchor_MouseUp);
            // 
            // ramMbLbl
            // 
            this.ramMbLbl.BackColor = System.Drawing.Color.Transparent;
            this.ramMbLbl.ForeColor = System.Drawing.Color.White;
            this.ramMbLbl.Location = new System.Drawing.Point(715, 468);
            this.ramMbLbl.Name = "ramMbLbl";
            this.ramMbLbl.Size = new System.Drawing.Size(255, 26);
            this.ramMbLbl.TabIndex = 11;
            this.ramMbLbl.Text = "0/0";
            this.ramMbLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GetServerStatsWorker
            // 
            this.GetServerStatsWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GetServerStatsWorker_DoWork);
            this.GetServerStatsWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.GetServerStatsWorker_ProgressChanged);
            // 
            // GetNewsWorker
            // 
            this.GetNewsWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GetNewsWorker_DoWork);
            this.GetNewsWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.GetNewsWorker_RunWorkerCompleted);
            // 
            // versionLbl
            // 
            this.versionLbl.BackColor = System.Drawing.Color.Transparent;
            this.versionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.versionLbl.ForeColor = System.Drawing.Color.White;
            this.versionLbl.Location = new System.Drawing.Point(702, 43);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(268, 42);
            this.versionLbl.TabIndex = 12;
            this.versionLbl.Text = "Fetching...";
            this.versionLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // VersionWorker
            // 
            this.VersionWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.VersionWorker_DoWork);
            this.VersionWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.VersionWorker_ProgressChanged);
            // 
            // dBarBack
            // 
            this.dBarBack.BackColor = System.Drawing.Color.Transparent;
            this.dBarBack.BackgroundImage = global::MCPeaches_Launcher.Properties.Resources.shade;
            this.dBarBack.Location = new System.Drawing.Point(732, 100);
            this.dBarBack.Name = "dBarBack";
            this.dBarBack.Size = new System.Drawing.Size(200, 10);
            this.dBarBack.TabIndex = 13;
            this.dBarBack.TabStop = false;
            this.dBarBack.Visible = false;
            // 
            // dBarTop
            // 
            this.dBarTop.BackColor = System.Drawing.Color.Transparent;
            this.dBarTop.BackgroundImage = global::MCPeaches_Launcher.Properties.Resources.downloadColor;
            this.dBarTop.Location = new System.Drawing.Point(732, 100);
            this.dBarTop.Name = "dBarTop";
            this.dBarTop.Size = new System.Drawing.Size(0, 10);
            this.dBarTop.TabIndex = 14;
            this.dBarTop.TabStop = false;
            // 
            // UnzipUIWorker
            // 
            this.UnzipUIWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UnzipUIWorker_DoWork);
            this.UnzipUIWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.UnzipUIWorker_ProgressChanged);
            // 
            // DownloadWorker
            // 
            this.DownloadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DownloadWorker_DoWork);
            this.DownloadWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.DownloadWorker_ProgressChanged);
            this.DownloadWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DownloadWorker_RunWorkerCompleted);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.BackgroundImage = global::MCPeaches_Launcher.Properties.Resources.Close;
            this.exitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitBtn.Location = new System.Drawing.Point(942, 0);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(40, 40);
            this.exitBtn.TabIndex = 15;
            this.exitBtn.TabStop = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            this.exitBtn.MouseEnter += new System.EventHandler(this.exitBtn_MouseEnter);
            this.exitBtn.MouseLeave += new System.EventHandler(this.exitBtn_MouseLeave);
            // 
            // minBtn
            // 
            this.minBtn.BackColor = System.Drawing.Color.Transparent;
            this.minBtn.BackgroundImage = global::MCPeaches_Launcher.Properties.Resources.min;
            this.minBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minBtn.Location = new System.Drawing.Point(902, 0);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(40, 40);
            this.minBtn.TabIndex = 16;
            this.minBtn.TabStop = false;
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click);
            this.minBtn.MouseEnter += new System.EventHandler(this.minBtn_MouseEnter);
            this.minBtn.MouseLeave += new System.EventHandler(this.minBtn_MouseLeave);
            // 
            // playBtn
            // 
            this.playBtn.AutoSize = true;
            this.playBtn.BackColor = System.Drawing.Color.Transparent;
            this.playBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playBtn.ForeColor = System.Drawing.Color.White;
            this.playBtn.Location = new System.Drawing.Point(765, 364);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(109, 46);
            this.playBtn.TabIndex = 17;
            this.playBtn.Text = "Play!";
            this.playBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            this.playBtn.MouseEnter += new System.EventHandler(this.playBtn_MouseEnter);
            this.playBtn.MouseLeave += new System.EventHandler(this.playBtn_MouseLeave);
            // 
            // reDownloadBtn
            // 
            this.reDownloadBtn.BackColor = System.Drawing.Color.Transparent;
            this.reDownloadBtn.BackgroundImage = global::MCPeaches_Launcher.Properties.Resources.download;
            this.reDownloadBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reDownloadBtn.Location = new System.Drawing.Point(700, 466);
            this.reDownloadBtn.Name = "reDownloadBtn";
            this.reDownloadBtn.Size = new System.Drawing.Size(30, 30);
            this.reDownloadBtn.TabIndex = 18;
            this.reDownloadBtn.TabStop = false;
            this.reDownloadBtn.Click += new System.EventHandler(this.reDownloadBtn_Click);
            this.reDownloadBtn.MouseEnter += new System.EventHandler(this.reDownloadBtn_MouseEnter);
            this.reDownloadBtn.MouseLeave += new System.EventHandler(this.reDownloadBtn_MouseLeave);
            // 
            // LauncherUpdateWorker
            // 
            this.LauncherUpdateWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LauncherUpdateWorker_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::MCPeaches_Launcher.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 503);
            this.Controls.Add(this.reDownloadBtn);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.minBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.dBarTop);
            this.Controls.Add(this.dBarBack);
            this.Controls.Add(this.versionLbl);
            this.Controls.Add(this.ramMbLbl);
            this.Controls.Add(this.sliderAnchor);
            this.Controls.Add(this.sliderBar);
            this.Controls.Add(this.newsPanel);
            this.Controls.Add(this.statsPlayers);
            this.Controls.Add(this.statsOnline);
            this.Controls.Add(this.ShadedBar);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "MCPeaches";
            ((System.ComponentModel.ISupportInitialize)(this.ShadedBar)).EndInit();
            this.newsPanel.ResumeLayout(false);
            this.newsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderAnchor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBarBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBarTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reDownloadBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private PictureBox ShadedBar;
        private Label statsOnline;
        private Label statsPlayers;
        private Panel newsPanel;
        private PictureBox sliderBar;
        private PictureBox sliderAnchor;
        private Label ramMbLbl;
        private System.ComponentModel.BackgroundWorker GetServerStatsWorker;
        private System.ComponentModel.BackgroundWorker GetNewsWorker;
        private Label newsFetchLbl;
        private Label versionLbl;
        private System.ComponentModel.BackgroundWorker VersionWorker;
        private PictureBox dBarBack;
        private PictureBox dBarTop;
        private System.ComponentModel.BackgroundWorker UnzipUIWorker;
        private System.ComponentModel.BackgroundWorker DownloadWorker;
        private PictureBox exitBtn;
        private PictureBox minBtn;
        private Label playBtn;
        private PictureBox reDownloadBtn;
        private System.ComponentModel.BackgroundWorker LauncherUpdateWorker;
    }
}