using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using MineStatLib;
using System.ComponentModel;

namespace MCPeaches_Launcher
{
    internal class ServerStatus
    {
        MineStat serverStatus;
        string serverAddress;
        Label statsOnline;
        Label statsPlayers;
        WebClient webClient;
        public ServerStatus(MineStat serverStatus, string serverAddress, Label statsOnline, Label statsPlayers)
        {
            this.serverStatus = serverStatus;
            this.serverAddress = serverAddress;
            this.statsOnline = statsOnline; 
            this.statsPlayers = statsPlayers;
            webClient = new WebClient();    
        }
        public void getServerStats()
        {
            serverStatus = new MineStat(serverAddress, 25565, 2);
            if (serverStatus.ServerUp)
            {
                setServerStatText(1);
            }
            else
            {
                try
                {
                    setServerStatText(0);
                }
                catch (Exception)
                {
                    setServerStatText(-1);
                }
            }
        }
        public MineStat setServerStatText(int progress)
        {
            switch (progress)
            {
                case -1:
                    {
                        statsOnline.Text = "Check Network";
                        statsOnline.ForeColor = Color.Orange;
                        statsPlayers.Text = "Players Online:";
                        break;
                    }
                case 0:
                    {
                        statsOnline.Text = "Server Offline";
                        statsOnline.ForeColor = Color.Red;
                        statsPlayers.Text = "Players Online:";
                        break;
                    }
                case 1:
                    {
                        statsOnline.Text = "Server Online";
                        statsOnline.ForeColor = Color.Lime;
                        statsPlayers.Text = "Players Online:\n" + serverStatus.CurrentPlayers + "/" + serverStatus.MaximumPlayers;
                        break;
                    }
            }
            return serverStatus;
        }
        public void ServerStatsWorker(object sender)
        {
            var worker = sender as BackgroundWorker;
            while (true)
            {
                serverStatus = new MineStat(serverAddress, 25565);
                if (serverStatus.ServerUp)
                {
                    worker.ReportProgress(1);
                }
                else
                {
                    try
                    {
                        webClient.OpenRead("https://google.com");

                        worker.ReportProgress(0);


                    }
                    catch (Exception)
                    {
                        worker.ReportProgress(-1);

                    }
                }
                Thread.Sleep(5000);
            }
        }
    }
}
