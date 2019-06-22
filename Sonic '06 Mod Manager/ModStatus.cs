using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sonic_06_Mod_Manager
{
    public partial class ModStatus : Form
    {
        public ModStatus()
        {
            InitializeComponent();
        }

        private void ModStatus_Load(object sender, EventArgs e)
        {
            if (ModManager.installState == "install")
            {
                Text = "Installing Mods...";
                lbl_unpackState.Text = "Installing Mods. Please wait...";
                pnl_windowCheck.BackColor = Color.Honeydew; BackColor = Color.Honeydew;
                Width = 276;
                Height = 138;
            }
            else if (ModManager.installState == "cleanup")
            {
                Text = "Cleaning Up...";
                lbl_unpackState.Text = "Cleaning Up. Please wait...";
                pnl_windowCheck.BackColor = Color.Honeydew; BackColor = Color.Honeydew;
                Width = 264;
                Height = 138;
            }
        }
    }
}
