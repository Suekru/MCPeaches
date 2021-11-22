using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using MineStatLib;


namespace MCPeaches_Launcher
{
    internal class News
    {
        private string[] newsTxt;
        private Form launcher;
        private Panel newsPanel;
        private Label newsFetchLbl;
        private MineStat serverStatus;
        private Font copperplate;
        public News(Form launcher, Panel newsPanel, Label newsFetchLbl, MineStat serverStatus, Font copperplate)
        {
            this.launcher = launcher;
            this.newsPanel = newsPanel;
            this.newsFetchLbl = newsFetchLbl;
            this.serverStatus = serverStatus;
            this.copperplate = copperplate;
        }
        public void FetchNews()
        {
            var labels = new List<Label>();
            var paragraphTags = 0;
            var paragraph = "";
            var labelTexts = new List<String>();
            var labelTextsType = new List<char>();
            newsFetchLbl.Visible = false;
            foreach (var line in newsTxt)
            {
                if (line == "#end")
                    break;
                if (line.Trim().Length > 0)
                {
                    if (line[0] == '<')
                    {
                        labels.Add(new Label());
                        labelTexts.Add(line.Trim('<').ToUpper());
                        labelTextsType.Add('h');
                    }
                    else if (line[0] == '#')
                    {
                        paragraphTags++;
                        paragraph += line.Trim('#') + '\n';
                    }
                    else if (line[line.Length - 1] == '#')
                    {
                        paragraphTags++;
                        paragraph += line.Trim('#') + '\n';
                        labelTexts.Add(paragraph);
                        labelTextsType.Add('p');
                        paragraph = "";
                    }
                    else
                    {
                        paragraph += line + '\n';
                    }
                    if (paragraphTags == 2)
                        labels.Add(new Label());
                }
                else paragraph += '\n';
            } //end of foreach

            if (labels.Count != labelTexts.Count)
            {
                var label = new Label();
                launcher.Controls.Add(label);
                label.Location = new Point(10, 15);
                label.Text = "Syntax Error in Loading News";
                label.AutoSize = true;
                label.ForeColor = Color.White;
                label.Font = new Font(copperplate.FontFamily, 16, FontStyle.Bold);
                newsPanel.Controls.Add(label);
            }
            else
            {
                var lastPosY = 0;
                var lastHeight = 0;
                for (int i = 0; i < labels.Count; i++)
                {
                    var label = labels[i];
                    launcher.Controls.Add(label);
                    label.ForeColor = Color.White;

                    if (labelTextsType[i] == 'p')
                    {
                        label.AutoSize = true;
                        label.Font = new Font("Eras Medium ITC", 12);
                        label.Location = new Point(10, lastPosY + lastHeight);


                    }
                    else if (labelTextsType[i] == 'h')
                    {
                        label.Font = new Font(copperplate.FontFamily, 18, FontStyle.Bold);
                        label.Location = new Point(10, lastPosY + lastHeight);
                        label.AutoSize = true;
                        label.Size = new Size(460, 40);
                    }
                    label.Text = labelTexts[i];
                    lastPosY = label.Top;
                    lastHeight = label.Height;
                    newsPanel.Controls.Add(label);
                }
            }
        }
        public void NewsWorker()
        {
            var webClient = new WebClient();
            var fetched = false;
            while (!fetched)
            {
                try
                {
                    newsTxt = webClient.DownloadString("http://mcpeaches.zapto.org/news.txt").Split('\n');
                    fetched = true;

                }
                catch (Exception)
                {
                    if (!serverStatus.ServerUp)
                        Thread.Sleep(5000);
                }
            }
        }
    }
}
