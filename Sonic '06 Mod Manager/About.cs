using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Sonic_06_Mod_Manager
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            lbl_versionNumber.Text = ModManager.versionNumber;
        }

        private void Btn_GitHub_Click(object sender, EventArgs e)
        {
            //Link to be replaced in the future when a public repository is made.
            Process.Start("https://github.com/Knuxfan24/Hacked-Together-Mod-Manager");
        }

        private void Pic_Logo_Click(object sender, EventArgs e)
        {
            var sfd_SaveLogo = new SaveFileDialog();
            sfd_SaveLogo.Title = "Save As";
            sfd_SaveLogo.Filter = "PNG|*.png";

            if (sfd_SaveLogo.ShowDialog() == DialogResult.OK)
            {
                Properties.Resources.logo_main.Save(sfd_SaveLogo.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
