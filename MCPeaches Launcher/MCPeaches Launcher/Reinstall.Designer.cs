namespace MCPeaches_Launcher
{
    partial class Reinstall
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
            this.warningLbl = new System.Windows.Forms.Label();
            this.messageLbl = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // warningLbl
            // 
            this.warningLbl.Location = new System.Drawing.Point(12, 19);
            this.warningLbl.Name = "warningLbl";
            this.warningLbl.Size = new System.Drawing.Size(458, 25);
            this.warningLbl.TabIndex = 0;
            this.warningLbl.Text = "WARNING!";
            this.warningLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // messageLbl
            // 
            this.messageLbl.Location = new System.Drawing.Point(12, 61);
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.Size = new System.Drawing.Size(458, 72);
            this.messageLbl.TabIndex = 1;
            this.messageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(132, 165);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(94, 29);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // acceptBtn
            // 
            this.acceptBtn.Location = new System.Drawing.Point(243, 165);
            this.acceptBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(94, 29);
            this.acceptBtn.TabIndex = 3;
            this.acceptBtn.Text = "Accept";
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // Reinstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 202);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.messageLbl);
            this.Controls.Add(this.warningLbl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 249);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 249);
            this.Name = "Reinstall";
            this.Text = "Reinstall";
            this.ResumeLayout(false);

        }

        #endregion

        private Label warningLbl;
        private Label messageLbl;
        private Button cancelBtn;
        private Button acceptBtn;
    }
}