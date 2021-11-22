using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCPeaches_Launcher
{
    public partial class Reinstall : Form
    {
        Action update;
        public Reinstall(Action update)
        {
            ControlBox = false;
            InitializeComponent();
            this.update = update;
            cancelBtn.Location = new Point(Width/2 - cancelBtn.Width - 10, messageLbl.Bottom + 10);
            acceptBtn.Location = new Point(Width / 2, messageLbl.Bottom + 10);
            messageLbl.Text = "This will completely reinstall MCPeaches modpack.\nAny saves, waypoints, or settings will be deleted.";
            this.Update();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            File.WriteAllText("version.peaches", "0.9");
            Directory.Delete(".Minecraft", true);
            Directory.CreateDirectory(".Minecraft");
            update.Invoke();
            this.Close();
        }
    }
}
