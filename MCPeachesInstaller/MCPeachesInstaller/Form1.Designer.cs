namespace MCPeachesInstaller
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pathLbl = new System.Windows.Forms.Label();
            this.installPanel = new System.Windows.Forms.Panel();
            this.fileLbl = new System.Windows.Forms.Label();
            this.percentLbl = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.startMenuCheck = new System.Windows.Forms.CheckBox();
            this.desktopCheck = new System.Windows.Forms.CheckBox();
            this.installBtn = new System.Windows.Forms.Button();
            this.browseBtn = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.downloadWorker = new System.ComponentModel.BackgroundWorker();
            this.fileNameLbl = new System.Windows.Forms.Label();
            this.installPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pathLbl
            // 
            this.pathLbl.AutoSize = true;
            this.pathLbl.Location = new System.Drawing.Point(1, 6);
            this.pathLbl.Name = "pathLbl";
            this.pathLbl.Size = new System.Drawing.Size(74, 16);
            this.pathLbl.TabIndex = 0;
            this.pathLbl.Text = "Install Path:";
            // 
            // installPanel
            // 
            this.installPanel.Controls.Add(this.fileNameLbl);
            this.installPanel.Controls.Add(this.fileLbl);
            this.installPanel.Controls.Add(this.percentLbl);
            this.installPanel.Controls.Add(this.progressBar);
            this.installPanel.Controls.Add(this.startMenuCheck);
            this.installPanel.Controls.Add(this.desktopCheck);
            this.installPanel.Controls.Add(this.installBtn);
            this.installPanel.Controls.Add(this.browseBtn);
            this.installPanel.Controls.Add(this.pathBox);
            this.installPanel.Controls.Add(this.pathLbl);
            this.installPanel.Location = new System.Drawing.Point(12, 12);
            this.installPanel.Name = "installPanel";
            this.installPanel.Size = new System.Drawing.Size(608, 91);
            this.installPanel.TabIndex = 1;
            // 
            // fileLbl
            // 
            this.fileLbl.Location = new System.Drawing.Point(-3, 0);
            this.fileLbl.Name = "fileLbl";
            this.fileLbl.Size = new System.Drawing.Size(86, 23);
            this.fileLbl.TabIndex = 3;
            this.fileLbl.Text = "Fetching...";
            this.fileLbl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.fileLbl.Visible = false;
            // 
            // percentLbl
            // 
            this.percentLbl.Location = new System.Drawing.Point(249, 57);
            this.percentLbl.Name = "percentLbl";
            this.percentLbl.Size = new System.Drawing.Size(75, 23);
            this.percentLbl.TabIndex = 7;
            this.percentLbl.Text = "0%";
            this.percentLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.percentLbl.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 31);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(597, 23);
            this.progressBar.TabIndex = 6;
            this.progressBar.Visible = false;
            // 
            // startMenuCheck
            // 
            this.startMenuCheck.AutoSize = true;
            this.startMenuCheck.Checked = true;
            this.startMenuCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.startMenuCheck.Location = new System.Drawing.Point(0, 68);
            this.startMenuCheck.Name = "startMenuCheck";
            this.startMenuCheck.Size = new System.Drawing.Size(140, 20);
            this.startMenuCheck.TabIndex = 5;
            this.startMenuCheck.Text = "Start Menu Shorcut";
            this.startMenuCheck.UseVisualStyleBackColor = true;
            // 
            // desktopCheck
            // 
            this.desktopCheck.AutoSize = true;
            this.desktopCheck.Checked = true;
            this.desktopCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.desktopCheck.Location = new System.Drawing.Point(232, 68);
            this.desktopCheck.Name = "desktopCheck";
            this.desktopCheck.Size = new System.Drawing.Size(128, 20);
            this.desktopCheck.TabIndex = 4;
            this.desktopCheck.Text = "Desktop Shorcut";
            this.desktopCheck.UseVisualStyleBackColor = true;
            // 
            // installBtn
            // 
            this.installBtn.Location = new System.Drawing.Point(530, 65);
            this.installBtn.Name = "installBtn";
            this.installBtn.Size = new System.Drawing.Size(75, 23);
            this.installBtn.TabIndex = 3;
            this.installBtn.Text = "Install";
            this.installBtn.UseVisualStyleBackColor = true;
            this.installBtn.Click += new System.EventHandler(this.installBtn_Click);
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(575, 2);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(28, 23);
            this.browseBtn.TabIndex = 2;
            this.browseBtn.Text = "...";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(81, 3);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(488, 22);
            this.pathBox.TabIndex = 1;
            this.pathBox.Text = "C:\\Program Files (x86)\\MCPeaches";
            // 
            // panel1
            // 
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(16, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 94);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
            // 
            // downloadWorker
            // 
            this.downloadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.downloadWorker_DoWork);
            this.downloadWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.downloadWorker_ProgressChanged);
            this.downloadWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.downloadWorker_RunWorkerCompleted);
            // 
            // fileNameLbl
            // 
            this.fileNameLbl.Location = new System.Drawing.Point(81, 3);
            this.fileNameLbl.Name = "fileNameLbl";
            this.fileNameLbl.Size = new System.Drawing.Size(409, 23);
            this.fileNameLbl.TabIndex = 3;
            this.fileNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fileNameLbl.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 115);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.installPanel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 162);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 162);
            this.Name = "Form1";
            this.Text = "MCPeaches Installer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.installPanel.ResumeLayout(false);
            this.installPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label pathLbl;
        private System.Windows.Forms.Panel installPanel;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Button installBtn;
        private System.Windows.Forms.CheckBox startMenuCheck;
        private System.Windows.Forms.CheckBox desktopCheck;
        private System.Windows.Forms.Label percentLbl;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker downloadWorker;
        private System.Windows.Forms.Label fileLbl;
        private System.Windows.Forms.Label fileNameLbl;
    }
}

