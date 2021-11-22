namespace MCPeachesUpdater
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.fileLbl = new System.Windows.Forms.Label();
            this.downloadWorker = new System.ComponentModel.BackgroundWorker();
            this.percentLbl = new System.Windows.Forms.Label();
            this.fileCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 72);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(658, 29);
            this.progressBar.TabIndex = 0;
            // 
            // fileLbl
            // 
            this.fileLbl.Location = new System.Drawing.Point(12, 33);
            this.fileLbl.Name = "fileLbl";
            this.fileLbl.Size = new System.Drawing.Size(658, 25);
            this.fileLbl.TabIndex = 1;
            this.fileLbl.Text = "fetching...";
            this.fileLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // downloadWorker
            // 
            this.downloadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.downloadWorker_DoWork);
            this.downloadWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.downloadWorker_ProgressChanged);
            this.downloadWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.downloadWorker_RunWorkerCompleted);
            // 
            // percentLbl
            // 
            this.percentLbl.Location = new System.Drawing.Point(12, 104);
            this.percentLbl.Name = "percentLbl";
            this.percentLbl.Size = new System.Drawing.Size(658, 25);
            this.percentLbl.TabIndex = 2;
            this.percentLbl.Text = "0%";
            this.percentLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fileCount
            // 
            this.fileCount.Location = new System.Drawing.Point(12, 9);
            this.fileCount.Name = "fileCount";
            this.fileCount.Size = new System.Drawing.Size(658, 25);
            this.fileCount.TabIndex = 3;
            this.fileCount.Text = "0/0";
            this.fileCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 153);
            this.Controls.Add(this.fileCount);
            this.Controls.Add(this.percentLbl);
            this.Controls.Add(this.fileLbl);
            this.Controls.Add(this.progressBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 200);
            this.Name = "Form1";
            this.Text = "MCPeaches Updater";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ProgressBar progressBar;
        private Label fileLbl;
        private System.ComponentModel.BackgroundWorker downloadWorker;
        private Label percentLbl;
        private Label fileCount;
    }
}