using System;
using System.Drawing;
using Unify.Networking;
using System.Windows.Forms;

namespace Sonic_06_Mod_Manager
{
    public partial class UpdaterChoice : Form
    {
        string versionNumber = string.Empty;

        public UpdaterChoice(string versionNumber) {
            InitializeComponent();
            this.versionNumber = versionNumber;

            if (ModManager.christmas)
                Icon = Properties.Resources.icon_christmas;

            if (Properties.Settings.Default.theme)
                BackColor = Color.FromArgb(28, 28, 28);
        }

        private void btn_Update_Click(object sender, EventArgs e) {
            Updater.CheckForUpdates(versionNumber,
                                    "https://segacarnival.com/hyper/updates/sonic-06-mod-manager/latest-master.exe",
                                    "https://segacarnival.com/hyper/updates/sonic-06-mod-manager/latest_master.txt",
                                    "user");
        }

        private void btn_ModUpdater_Click(object sender, EventArgs e) { new ModUpdater().ShowDialog(); }

        private void btn_Reset_Click(object sender, EventArgs e) { Close(); }
    }
}
